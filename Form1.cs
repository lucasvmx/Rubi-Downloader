using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Drawing;
using System.Threading;

namespace Rubi_Downloader
{
	public partial class mainForm : Form
	{
		private int failedDownloads = 0;
		private int successfulDownloads = 0;
		private static readonly object _logLock = new object();
		private static readonly object _taskLock = new object();
		private string outputFolder = @"Data\Videos";
		private string logsFolder = @"Data\Logs";

		private string errorFile = "download_error_log.txt";
		private string logsFile = "download_log.txt";

		public mainForm()
		{
			InitializeComponent();

			toolStripStatusLabel1.ForeColor = Color.Blue;
			toolStripStatusLabel1.Text = $"Pasta de saída definida: {Path.Combine(Directory.GetCurrentDirectory(), outputFolder)}";

			// Cria a pasta onde os vídeos serão salvos
			try
			{
				Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), outputFolder));
				Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), logsFolder));

				// Se o arquivo de configuração existir, carrega as configurações
				if(File.Exists("config.xml"))
				{
					LoadConfig();
				}
					
				// Limpa logs antigos
				errorFile = Path.Combine(Directory.GetCurrentDirectory(), logsFolder, errorFile);
				logsFile = Path.Combine(Directory.GetCurrentDirectory(), logsFolder, logsFile);

				File.Delete(errorFile);
				File.Delete(logsFile);
			}
			catch (Exception)
			{

			}
		}

		private void SaveConfig()
		{
			var config = new Config
			{
				OutputFolder = outputFolder
			};
			var xmlDoc = new XmlDocument();
			var root = xmlDoc.CreateElement("Config");
			var outputFolderElement = xmlDoc.CreateElement("OutputFolder");
			outputFolderElement.InnerText = config.OutputFolder;
			root.AppendChild(outputFolderElement);
			xmlDoc.AppendChild(root);
			xmlDoc.Save("config.xml");
		}

		private void LoadConfig()
		{
			if (!File.Exists("config.xml"))
				return;
			var xmlDoc = new XmlDocument();
			xmlDoc.Load("config.xml");
			var outputFolderElement = xmlDoc.SelectSingleNode("/Config/OutputFolder");
			if (outputFolderElement != null)
			{
				outputFolder = outputFolderElement.InnerText;
				updateStatusLabel($"Pasta de saída definida: {outputFolder}");
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

			updateStatusLabel($"Links inseridos: {linksInput.Length}");
			setDefinedProgressBar(linksInput.Length);
			setStatusLabelColor(Color.Blue);

			var tasks = new List<Task>();
			List<Task> convertTasks = new List<Task>();

			foreach (string link in linksInput)
			{
				if (!isValidYoutubeLink(link))
				{
					setStatusLabelColor(Color.Red);
					updateStatusLabel($"Link inválido: {link}");
					IncrementarProgresso();
					continue;
				}

				tasks.Add(DownloadFileAsync(link));
			}

			// Aguarda TODOS os downloads finalizarem
			await Task.WhenAll(tasks);

			setStatusLabelColor(Color.Green);
			updateStatusLabel(
				$"Finalizado | Sucesso: {successfulDownloads} | Falhas: {failedDownloads}"
			);

			if(checkBoxMp4.Checked)
			{
				// Itera sobre os arquivos baixados para conversão
				var downloadedFiles = Directory.GetFiles(outputFolder, "*.webm");
				string ffmpegPath = Path.Combine(Directory.GetCurrentDirectory(), "bin", "ffmpeg.exe");

				// Para cada arquivo .webm, cria uma tarefa de conversão
				foreach (string file in downloadedFiles)
				{
					convertTasks.Add(ConvertWebmToMp4(
						ffmpegPath,
						file,
						Path.ChangeExtension(file, ".mp4")
					));

					await Task.WhenAll(convertTasks);
				}

				setStatusLabelColor(Color.Green);
				updateStatusLabel("Todas as conversões concluídas.");
			}

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
									logsFile,
									$"Link: {url} | Mensagem: {e.Data}{Environment.NewLine}"
								);

								setStatusLabelColor(Color.Blue);
								updateStatusLabel($"{url}: {e.Data}");
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
									errorFile,
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
						setStatusLabelColor(Color.Green);
						updateStatusLabel($"Download concluído: {url}");
					}
					else
					{
						failedDownloads++;
						setStatusLabelColor(Color.Red);
						updateStatusLabel($"Erro no download: {url}");
					}
				}
				catch (Exception ex)
				{
					failedDownloads++;
					setStatusLabelColor(Color.Red);
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
				"3. Clique em \"Baixar\" para iniciar o download.\n" +
				"4. Se a opção \"Converter para MP4\" estiver marcada, o programa converterá automaticamente os arquivos quando necessário. " +
				"Esse processo pode levar vários minutos, especialmente para vídeos longos ou de alta qualidade.\n" +
				"5. Aguarde a conclusão do processamento.",
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
					setStatusLabelColor(Color.Blue);
					updateStatusLabel($"Pasta de saída definida: {outputFolder}");

					// Salva a configuração
					try
					{
						SaveConfig();
					} catch
					{
						MessageBox.Show("Erro ao salvar configuração.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					
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

		private void setStatusLabelColor(Color color)
		{
			BeginInvoke(new Action(() =>
			{
				toolStripStatusLabel1.ForeColor = color;
			}));
		}

		private Task ConvertWebmToMp4(string ffmpegPath,string inputWebm, string outputMp4)
		{
			// Não permite múltiplas conversões simultâneas
			lock (_taskLock) 
			{
				updateStatusLabel($"Iniciando conversão: {Path.GetFileName(inputWebm)}");
			}

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
					{
						setStatusLabelColor(Color.Blue);
						updateStatusLabel(e.Data);

						lock (_logLock)
						{
							File.AppendAllText(
								logsFile,
								$"Conversão: {Path.GetFileName(inputWebm)} | Mensagem: {e.Data}{Environment.NewLine}"
							);
						}
					}
				};

				process.ErrorDataReceived += (s, e) =>
				{
					if (!string.IsNullOrWhiteSpace(e.Data))
					{
						setStatusLabelColor(Color.Blue);
						updateStatusLabel(e.Data);

						lock (_logLock)
						{
							File.AppendAllText(
								errorFile,
								$"Conversão: {Path.GetFileName(inputWebm)} | Mensagem: {e.Data}{Environment.NewLine}"
							);
						}
					}
				};

				process.Start();
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();

				updateStatusLabel($"Convertendo: {Path.GetFileName(inputWebm)} (Aguarde pois pode demorar um pouco)");
				process.WaitForExit();

				if (process.ExitCode != 0)
					throw new Exception($"ffmpeg falhou (ExitCode={process.ExitCode})");
			});
		}

		private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Process.GetProcessesByName("yt-dlp").ToList().ForEach(p => p.Kill());

			// finaliza o ffmpeg.exe se estiver rodando
			Process.GetProcessesByName("ffmpeg").ToList().ForEach(p => p.Kill());
		}
	}

	public class Config
	{
		public string OutputFolder { get; set; }
	}
}
