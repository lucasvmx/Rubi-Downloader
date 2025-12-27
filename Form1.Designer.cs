namespace Rubi_Downloader
{
	partial class mainForm
	{
		/// <summary>
		/// Variável de designer necessária.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpar os recursos que estão sendo usados.
		/// </summary>
		/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código gerado pelo Windows Form Designer

		/// <summary>
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
			this.caixaTextoLinks = new System.Windows.Forms.RichTextBox();
			this.botaoBaixar = new System.Windows.Forms.Button();
			this.headerLabel = new System.Windows.Forms.Label();
			this.botaoAjuda = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.iconeAjuda = new System.Windows.Forms.PictureBox();
			this.iconeBaixar = new System.Windows.Forms.PictureBox();
			this.botaoEscolherPasta = new System.Windows.Forms.Button();
			this.iconeEscolherPasta = new System.Windows.Forms.PictureBox();
			this.botaoVerArquivos = new System.Windows.Forms.Button();
			this.iconeArquivosBaixados = new System.Windows.Forms.PictureBox();
			this.checkBoxMp4 = new System.Windows.Forms.CheckBox();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.iconeAjuda)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.iconeBaixar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.iconeEscolherPasta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.iconeArquivosBaixados)).BeginInit();
			this.SuspendLayout();
			// 
			// caixaTextoLinks
			// 
			this.caixaTextoLinks.BackColor = System.Drawing.Color.LightSteelBlue;
			this.caixaTextoLinks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.caixaTextoLinks.DetectUrls = false;
			this.caixaTextoLinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.caixaTextoLinks.ForeColor = System.Drawing.Color.Maroon;
			this.caixaTextoLinks.Location = new System.Drawing.Point(12, 60);
			this.caixaTextoLinks.Name = "caixaTextoLinks";
			this.caixaTextoLinks.Size = new System.Drawing.Size(1091, 403);
			this.caixaTextoLinks.TabIndex = 0;
			this.caixaTextoLinks.Text = "";
			this.caixaTextoLinks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.caixaTextoLinks_KeyPress);
			// 
			// botaoBaixar
			// 
			this.botaoBaixar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.botaoBaixar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.botaoBaixar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.botaoBaixar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
			this.botaoBaixar.Location = new System.Drawing.Point(12, 482);
			this.botaoBaixar.Name = "botaoBaixar";
			this.botaoBaixar.Size = new System.Drawing.Size(160, 89);
			this.botaoBaixar.TabIndex = 1;
			this.botaoBaixar.Text = "Baixar";
			this.botaoBaixar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.botaoBaixar.UseVisualStyleBackColor = false;
			this.botaoBaixar.Click += new System.EventHandler(this.botaoBaixar_Click);
			// 
			// headerLabel
			// 
			this.headerLabel.AutoSize = true;
			this.headerLabel.BackColor = System.Drawing.SystemColors.Control;
			this.headerLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.headerLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.headerLabel.ForeColor = System.Drawing.Color.Maroon;
			this.headerLabel.Location = new System.Drawing.Point(294, 20);
			this.headerLabel.Name = "headerLabel";
			this.headerLabel.Size = new System.Drawing.Size(490, 23);
			this.headerLabel.TabIndex = 2;
			this.headerLabel.Text = "Cole os links dos vídeos no campo a seguir (um link por linha)";
			this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// botaoAjuda
			// 
			this.botaoAjuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.botaoAjuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.botaoAjuda.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.botaoAjuda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(183)))), ((int)(((byte)(211)))));
			this.botaoAjuda.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.botaoAjuda.Location = new System.Drawing.Point(187, 482);
			this.botaoAjuda.Name = "botaoAjuda";
			this.botaoAjuda.Size = new System.Drawing.Size(172, 89);
			this.botaoAjuda.TabIndex = 3;
			this.botaoAjuda.Text = "Ajuda";
			this.botaoAjuda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.botaoAjuda.UseVisualStyleBackColor = false;
			this.botaoAjuda.Click += new System.EventHandler(this.botaoAjuda_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 590);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1115, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// iconeAjuda
			// 
			this.iconeAjuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.iconeAjuda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconeAjuda.BackgroundImage")));
			this.iconeAjuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.iconeAjuda.Location = new System.Drawing.Point(209, 493);
			this.iconeAjuda.Name = "iconeAjuda";
			this.iconeAjuda.Size = new System.Drawing.Size(69, 65);
			this.iconeAjuda.TabIndex = 5;
			this.iconeAjuda.TabStop = false;
			this.iconeAjuda.Click += new System.EventHandler(this.iconeAjuda_Click);
			// 
			// iconeBaixar
			// 
			this.iconeBaixar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.iconeBaixar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconeBaixar.BackgroundImage")));
			this.iconeBaixar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.iconeBaixar.Location = new System.Drawing.Point(29, 493);
			this.iconeBaixar.Name = "iconeBaixar";
			this.iconeBaixar.Size = new System.Drawing.Size(69, 65);
			this.iconeBaixar.TabIndex = 6;
			this.iconeBaixar.TabStop = false;
			this.iconeBaixar.Click += new System.EventHandler(this.iconeBaixar_Click);
			// 
			// botaoEscolherPasta
			// 
			this.botaoEscolherPasta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.botaoEscolherPasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.botaoEscolherPasta.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.botaoEscolherPasta.ForeColor = System.Drawing.Color.Black;
			this.botaoEscolherPasta.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.botaoEscolherPasta.Location = new System.Drawing.Point(376, 482);
			this.botaoEscolherPasta.Name = "botaoEscolherPasta";
			this.botaoEscolherPasta.Size = new System.Drawing.Size(252, 89);
			this.botaoEscolherPasta.TabIndex = 7;
			this.botaoEscolherPasta.Text = "Escolher Pasta";
			this.botaoEscolherPasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.botaoEscolherPasta.UseVisualStyleBackColor = false;
			this.botaoEscolherPasta.Click += new System.EventHandler(this.botaoEscolherPasta_Click);
			// 
			// iconeEscolherPasta
			// 
			this.iconeEscolherPasta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.iconeEscolherPasta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconeEscolherPasta.BackgroundImage")));
			this.iconeEscolherPasta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.iconeEscolherPasta.Location = new System.Drawing.Point(400, 493);
			this.iconeEscolherPasta.Name = "iconeEscolherPasta";
			this.iconeEscolherPasta.Size = new System.Drawing.Size(69, 65);
			this.iconeEscolherPasta.TabIndex = 8;
			this.iconeEscolherPasta.TabStop = false;
			this.iconeEscolherPasta.Click += new System.EventHandler(this.iconeEscolherPasta_Click);
			// 
			// botaoVerArquivos
			// 
			this.botaoVerArquivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.botaoVerArquivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.botaoVerArquivos.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.botaoVerArquivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(69)))), ((int)(((byte)(237)))));
			this.botaoVerArquivos.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.botaoVerArquivos.Location = new System.Drawing.Point(634, 482);
			this.botaoVerArquivos.Name = "botaoVerArquivos";
			this.botaoVerArquivos.Size = new System.Drawing.Size(299, 89);
			this.botaoVerArquivos.TabIndex = 9;
			this.botaoVerArquivos.Text = "Ver arquivos baixados";
			this.botaoVerArquivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.botaoVerArquivos.UseVisualStyleBackColor = false;
			this.botaoVerArquivos.Click += new System.EventHandler(this.botaoVerArquivos_Click);
			// 
			// iconeArquivosBaixados
			// 
			this.iconeArquivosBaixados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.iconeArquivosBaixados.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconeArquivosBaixados.BackgroundImage")));
			this.iconeArquivosBaixados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.iconeArquivosBaixados.Location = new System.Drawing.Point(667, 493);
			this.iconeArquivosBaixados.Name = "iconeArquivosBaixados";
			this.iconeArquivosBaixados.Size = new System.Drawing.Size(69, 65);
			this.iconeArquivosBaixados.TabIndex = 10;
			this.iconeArquivosBaixados.TabStop = false;
			this.iconeArquivosBaixados.Click += new System.EventHandler(this.iconeArquivosBaixados_Click);
			// 
			// checkBoxMp4
			// 
			this.checkBoxMp4.AutoSize = true;
			this.checkBoxMp4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxMp4.ForeColor = System.Drawing.Color.Maroon;
			this.checkBoxMp4.Location = new System.Drawing.Point(966, 482);
			this.checkBoxMp4.Name = "checkBoxMp4";
			this.checkBoxMp4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.checkBoxMp4.Size = new System.Drawing.Size(137, 19);
			this.checkBoxMp4.TabIndex = 11;
			this.checkBoxMp4.Text = "Converter para MP4";
			this.checkBoxMp4.UseVisualStyleBackColor = true;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1115, 612);
			this.Controls.Add(this.checkBoxMp4);
			this.Controls.Add(this.iconeArquivosBaixados);
			this.Controls.Add(this.botaoVerArquivos);
			this.Controls.Add(this.iconeEscolherPasta);
			this.Controls.Add(this.botaoEscolherPasta);
			this.Controls.Add(this.iconeBaixar);
			this.Controls.Add(this.iconeAjuda);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.botaoAjuda);
			this.Controls.Add(this.headerLabel);
			this.Controls.Add(this.botaoBaixar);
			this.Controls.Add(this.caixaTextoLinks);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "mainForm";
			this.Text = "Rubi Downloader";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.iconeAjuda)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.iconeBaixar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.iconeEscolherPasta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.iconeArquivosBaixados)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox caixaTextoLinks;
		private System.Windows.Forms.Button botaoBaixar;
		private System.Windows.Forms.Label headerLabel;
		private System.Windows.Forms.Button botaoAjuda;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.PictureBox iconeAjuda;
		private System.Windows.Forms.PictureBox iconeBaixar;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Button botaoEscolherPasta;
		private System.Windows.Forms.PictureBox iconeEscolherPasta;
		private System.Windows.Forms.Button botaoVerArquivos;
		private System.Windows.Forms.PictureBox iconeArquivosBaixados;
		private System.Windows.Forms.CheckBox checkBoxMp4;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
	}
}

