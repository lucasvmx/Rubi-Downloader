using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rubi_Downloader
{
	public partial class mainForm : Form
	{
		private int failedDownloads = 0;
		private int successfulDownloads = 0;
		private static readonly object _logLock = new object();
		private string outputFolder = @"Videos";

		public mainForm()
		{
			InitializeComponent();

			toolStripStatusLabel1.Text = "Pronto";

			// Cria a pasta onde os vídeos serão salvos
			try
			{
				Directory.CreateDirectory(outputFolder);
			} catch(Exception)
			{

			}
		}

		// ================================
		// UTILITÁRIOS
		// ================================
		private bool haveDuplicatedLinks(string[] links)
		{
			var set = new HashSet<string>();

			foreach (var valor in links)
			{
				if (!set.Add(valor))
				{
					return true;
				}
			}

			return false;
		}

		private bool isValidYoutubeLink(string link)
		{
			return link.StartsWith("https://www.youtube.com", StringComparison.OrdinalIgnoreCase);
		}

		// ================================
		// BOTÃO BAIXAR (ASYNC)
		// ================================
		private async void botaoBaixar_Click(object sender, EventArgs e)
		{
			string[] linksInput = caixaTextoLinks.Lines
				.Where(l => !string.IsNullOrWhiteSpace(l))
				.ToArray();

			if (linksInput.Length == 0)
			{
				MessageBox.Show("Nenhum link informado.", "Aviso",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (haveDuplicatedLinks(linksInput))
			{
				MessageBox.Show("Links duplicados encontrados.", "Erro",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			failedDownloads = 0;
			successfulDownloads = 0;

			updateStatusLabel($"Links: {linksInput.Length}");
			setDefinedProgressBar(linksInput.Length);

			var tasks = new List<Task>();

			foreach (string link in linksInput)
			{
				if (!isValidYoutubeLink(link))
				{
					updateStatusLabel($"Link inválido: {link}");
					IncrementarProgresso();
					continue;
				}

				tasks.Add(DownloadFileAsync(link));
			}

			// Aguarda TODOS os downloads finalizarem
			await Task.WhenAll(tasks);

			updateStatusLabel(
				$"Finalizado | Sucesso: {successfulDownloads} | Falhas: {failedDownloads}"
			);

			MessageBox.Show(
				"Todos os downloads foram processados!",
				"Concluído",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}

		// ================================
		// DOWNLOAD ASSÍNCRONO
		// ================================
		private Task DownloadFileAsync(string url)
		{
			return Task.Run(() =>
			{
				try
				{
					var process = new Process
					{
						StartInfo = new ProcessStartInfo
						{
							FileName = "yt-dlp.exe",
							Arguments = $"-t mp4 -t mkv -k -o \"{outputFolder}\\%(title)s.%(ext)s\" {url}",
							UseShellExecute = false,
							RedirectStandardOutput = true,
							RedirectStandardError = true,
							CreateNoWindow = true
						}
					};

					process.OutputDataReceived += (s, e) =>
					{
						if (!string.IsNullOrEmpty(e.Data))
						{
							lock(_logLock)
							{
								File.AppendAllText(
									"download_log.txt",
									$"Link: {url} | Mensagem: {e.Data}{Environment.NewLine}"
								);

								updateStatusLabel($"Baixando: {url}");
							}
						}
					};

					process.ErrorDataReceived += (s, e) =>
					{
						if (!string.IsNullOrEmpty(e.Data))
						{
							lock(_logLock)
							{
								File.AppendAllText(
									"download_error_log.txt",
									$"Erro no link: {url} | Mensagem: {e.Data}{Environment.NewLine}"
								);
							}
						}
					};

					process.Start();
					process.BeginOutputReadLine();
					process.BeginErrorReadLine();
					process.WaitForExit();

					if (process.ExitCode == 0)
					{
						successfulDownloads++;
						updateStatusLabel($"Download concluído: {url}");
					}
					else
					{
						failedDownloads++;
						updateStatusLabel($"Erro no download: {url}");
					}
				}
				catch (Exception ex)
				{
					failedDownloads++;
					updateStatusLabel($"Erro ao iniciar download: {ex.Message}");
				}
				finally
				{
					IncrementarProgresso();
				}
			});
		}

		// ================================
		// UI HELPERS (THREAD-SAFE)
		// ================================
		private void setDefinedProgressBar(int maxValue)
		{
			BeginInvoke(new Action(() =>
			{
				toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
				toolStripProgressBar1.Maximum = maxValue;
				toolStripProgressBar1.Value = 0;
			}));
		}

		private void IncrementarProgresso()
		{
			BeginInvoke(new Action(() =>
			{
				if (toolStripProgressBar1.Value < toolStripProgressBar1.Maximum)
				{
					toolStripProgressBar1.Value++;
				}
			}));
		}

		private void updateStatusLabel(string message)
		{
			BeginInvoke(new Action(() =>
			{
				toolStripStatusLabel1.Text = message;
			}));
		}

		// ================================
		// AJUDA / ÍCONES
		// ================================
		private void botaoAjuda_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"Instruções de uso:\n\n" +
				"1. Insira os links do YouTube, um por linha.\n" +
				"2. Clique em 'Baixar'.\n" +
				"3. Aguarde o processamento.\n\n" +
				"Certifique-se de que o yt-dlp.exe esteja na mesma pasta do aplicativo.",
				"Ajuda",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}

		private void iconeBaixar_Click(object sender, EventArgs e)
		{
			botaoBaixar_Click(sender, e);
		}

		private void iconeAjuda_Click(object sender, EventArgs e)
		{
			botaoAjuda_Click(sender, e);
		}
	}
}
