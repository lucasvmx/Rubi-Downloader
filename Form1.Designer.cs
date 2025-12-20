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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
			this.caixaTextoLinks = new System.Windows.Forms.RichTextBox();
			this.botaoBaixar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.botaoAjuda = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.iconeAjuda = new System.Windows.Forms.PictureBox();
			this.iconeBaixar = new System.Windows.Forms.PictureBox();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.iconeAjuda)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.iconeBaixar)).BeginInit();
			this.SuspendLayout();
			// 
			// caixaTextoLinks
			// 
			this.caixaTextoLinks.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.caixaTextoLinks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.caixaTextoLinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.caixaTextoLinks.ForeColor = System.Drawing.Color.Blue;
			this.caixaTextoLinks.Location = new System.Drawing.Point(12, 102);
			this.caixaTextoLinks.Name = "caixaTextoLinks";
			this.caixaTextoLinks.Size = new System.Drawing.Size(1091, 364);
			this.caixaTextoLinks.TabIndex = 0;
			this.caixaTextoLinks.Text = "";
			// 
			// botaoBaixar
			// 
			this.botaoBaixar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.botaoBaixar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.botaoBaixar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
			this.botaoBaixar.Location = new System.Drawing.Point(12, 482);
			this.botaoBaixar.Name = "botaoBaixar";
			this.botaoBaixar.Size = new System.Drawing.Size(264, 89);
			this.botaoBaixar.TabIndex = 1;
			this.botaoBaixar.Text = "Baixar";
			this.botaoBaixar.UseVisualStyleBackColor = true;
			this.botaoBaixar.Click += new System.EventHandler(this.botaoBaixar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(321, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(529, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Cole os links dos vídeos no campo a seguir (um link por linha)";
			// 
			// botaoAjuda
			// 
			this.botaoAjuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.botaoAjuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.botaoAjuda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(183)))), ((int)(((byte)(211)))));
			this.botaoAjuda.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.botaoAjuda.Location = new System.Drawing.Point(313, 482);
			this.botaoAjuda.Name = "botaoAjuda";
			this.botaoAjuda.Size = new System.Drawing.Size(264, 89);
			this.botaoAjuda.TabIndex = 3;
			this.botaoAjuda.Text = "Ajuda";
			this.botaoAjuda.UseVisualStyleBackColor = true;
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
			this.iconeAjuda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconeAjuda.BackgroundImage")));
			this.iconeAjuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.iconeAjuda.Location = new System.Drawing.Point(329, 493);
			this.iconeAjuda.Name = "iconeAjuda";
			this.iconeAjuda.Size = new System.Drawing.Size(69, 65);
			this.iconeAjuda.TabIndex = 5;
			this.iconeAjuda.TabStop = false;
			this.iconeAjuda.Click += new System.EventHandler(this.iconeAjuda_Click);
			// 
			// iconeBaixar
			// 
			this.iconeBaixar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconeBaixar.BackgroundImage")));
			this.iconeBaixar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.iconeBaixar.Location = new System.Drawing.Point(24, 493);
			this.iconeBaixar.Name = "iconeBaixar";
			this.iconeBaixar.Size = new System.Drawing.Size(69, 65);
			this.iconeBaixar.TabIndex = 6;
			this.iconeBaixar.TabStop = false;
			this.iconeBaixar.Click += new System.EventHandler(this.iconeBaixar_Click);
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1115, 612);
			this.Controls.Add(this.iconeBaixar);
			this.Controls.Add(this.iconeAjuda);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.botaoAjuda);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.botaoBaixar);
			this.Controls.Add(this.caixaTextoLinks);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "mainForm";
			this.Text = "Rubi Downloader";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.iconeAjuda)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.iconeBaixar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox caixaTextoLinks;
		private System.Windows.Forms.Button botaoBaixar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button botaoAjuda;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.PictureBox iconeAjuda;
		private System.Windows.Forms.PictureBox iconeBaixar;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
	}
}

