using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

			toolStripStatusLabel1.Text = $"Pasta de saída definida: {Path.Combine(Directory.GetCurrentDirectory(), outputFolder)}";

			// Cria a pasta onde os vídeos serão salvos
			try
			{
				Directory.CreateDirectory(outputFolder);

				// Limpa logs antigos
				File.Delete("download_log.txt");
				File.Delete("download_error_log.txt");
			}
			catch (Exception)
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
			List<Task> convertTasks = new List<Task>();

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

			// Itera sobre os arquivos baixados para conversão
			var downloadedFiles = Directory.GetFiles(outputFolder, "*.webm");
			string ffmpegPath = Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg", "bin", "ffmpeg.exe");

			// Para cada arquivo .webm, cria uma tarefa de conversão
			foreach (string file in downloadedFiles)
			{
				convertTasks.Add(ConvertWebmToMp4(
					ffmpegPath,
					file,
					Path.ChangeExtension(file, ".mp4")
				));
			}

			await Task.WhenAll(convertTasks);
			updateStatusLabel("Todas as conversões concluídas.");

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
							Arguments = $"-o \"{outputFolder}\\%(title)s.%(ext)s\" {url}",
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
							lock (_logLock)
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
							lock (_logLock)
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
				"2. Selecione a pasta de saída (opcional).\n" +
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

		private void botaoEscolherPasta_Click(object sender, EventArgs e)
		{
			using (var folderDialog = new FolderBrowserDialog())
			{
				folderDialog.Description = "ESCOLHA A PASTA ONDE OS VÍDEOS SERÃO SALVOS";
				folderDialog.ShowNewFolderButton = true;

				if (folderDialog.ShowDialog() == DialogResult.OK)
				{
					outputFolder = folderDialog.SelectedPath;
					updateStatusLabel($"Pasta de saída definida: {outputFolder}");

					MessageBox.Show($"Pasta de saída: {outputFolder}", "Mudança de pasta", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void iconeEscolherPasta_Click(object sender, EventArgs e)
		{
			botaoEscolherPasta_Click(sender, e);
		}

		private void iconeArquivosBaixados_Click(object sender, EventArgs e)
		{
			botaoVerArquivos_Click(sender, e);
		}

		private void botaoVerArquivos_Click(object sender, EventArgs e)
		{
			OpenFolderInExplorer(outputFolder);
		}

		private void OpenFolderInExplorer(string folderPath)
		{
			if (!Directory.Exists(folderPath))
				return;

			Process.Start(new ProcessStartInfo
			{
				FileName = "explorer.exe",
				Arguments = folderPath,
				UseShellExecute = true
			});
		}

		private Task ConvertWebmToMp4(string ffmpegPath,string inputWebm, string outputMp4)
		{
			return Task.Run(() =>
			{
				var args =
				$"-i \"{inputWebm}\" " +
				"-c:v libx264 " +
				"-c:a aac " +
				"-movflags +faststart " +
				$"\"{outputMp4}\"";

				var process = new Process
				{
					StartInfo = new ProcessStartInfo
					{
						FileName = ffmpegPath,   // ex: "ffmpeg.exe" ou caminho completo
						Arguments = args,
						RedirectStandardOutput = true,
						RedirectStandardError = true,
						UseShellExecute = false,
						CreateNoWindow = true
					}
				};

				process.OutputDataReceived += (s, e) =>
				{
					if (!string.IsNullOrWhiteSpace(e.Data))
						Console.WriteLine(e.Data);
				};

				process.ErrorDataReceived += (s, e) =>
				{
					if (!string.IsNullOrWhiteSpace(e.Data))
						Console.WriteLine(e.Data);
				};

				process.Start();
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();

				updateStatusLabel($"Convertendo: {Path.GetFileName(inputWebm)} (Aguarde, pode demorar um pouco)");
				process.WaitForExit();

				if (process.ExitCode != 0)
					throw new Exception($"ffmpeg falhou (ExitCode={process.ExitCode})");
			});
		}
	}
}
