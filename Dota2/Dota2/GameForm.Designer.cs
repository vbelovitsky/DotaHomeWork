namespace Dota2
{
	partial class GameForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.avatarBox1 = new System.Windows.Forms.PictureBox();
			this.avatarBox2 = new System.Windows.Forms.PictureBox();
			this.heroNameTextBox1 = new System.Windows.Forms.TextBox();
			this.roundTextBox = new System.Windows.Forms.TextBox();
			this.heroNameTextBox2 = new System.Windows.Forms.TextBox();
			this.historyTextBox = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.heroList1 = new System.Windows.Forms.ListBox();
			this.heroList2 = new System.Windows.Forms.ListBox();
			this.escapeTextBox = new System.Windows.Forms.TextBox();
			this.backgroundBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.avatarBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.avatarBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.backgroundBox)).BeginInit();
			this.SuspendLayout();
			// 
			// avatarBox1
			// 
			this.avatarBox1.Location = new System.Drawing.Point(98, 12);
			this.avatarBox1.Name = "avatarBox1";
			this.avatarBox1.Size = new System.Drawing.Size(136, 159);
			this.avatarBox1.TabIndex = 0;
			this.avatarBox1.TabStop = false;
			// 
			// avatarBox2
			// 
			this.avatarBox2.Location = new System.Drawing.Point(737, 12);
			this.avatarBox2.Name = "avatarBox2";
			this.avatarBox2.Size = new System.Drawing.Size(136, 159);
			this.avatarBox2.TabIndex = 1;
			this.avatarBox2.TabStop = false;
			// 
			// heroNameTextBox1
			// 
			this.heroNameTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.heroNameTextBox1.Location = new System.Drawing.Point(40, 186);
			this.heroNameTextBox1.Name = "heroNameTextBox1";
			this.heroNameTextBox1.ReadOnly = true;
			this.heroNameTextBox1.Size = new System.Drawing.Size(254, 26);
			this.heroNameTextBox1.TabIndex = 2;
			this.heroNameTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// roundTextBox
			// 
			this.roundTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.roundTextBox.Location = new System.Drawing.Point(398, 12);
			this.roundTextBox.Name = "roundTextBox";
			this.roundTextBox.ReadOnly = true;
			this.roundTextBox.Size = new System.Drawing.Size(185, 26);
			this.roundTextBox.TabIndex = 3;
			this.roundTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// heroNameTextBox2
			// 
			this.heroNameTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.heroNameTextBox2.Location = new System.Drawing.Point(678, 186);
			this.heroNameTextBox2.Name = "heroNameTextBox2";
			this.heroNameTextBox2.ReadOnly = true;
			this.heroNameTextBox2.Size = new System.Drawing.Size(254, 26);
			this.heroNameTextBox2.TabIndex = 4;
			this.heroNameTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// historyTextBox
			// 
			this.historyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.historyTextBox.Location = new System.Drawing.Point(343, 70);
			this.historyTextBox.Multiline = true;
			this.historyTextBox.Name = "historyTextBox";
			this.historyTextBox.ReadOnly = true;
			this.historyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.historyTextBox.Size = new System.Drawing.Size(284, 377);
			this.historyTextBox.TabIndex = 8;
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(222, 474);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(529, 26);
			this.textBox1.TabIndex = 9;
			this.textBox1.Text = "Нажимайте клавиши: Q - атаковать; W - защищаться; E - убежать. ";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// heroList1
			// 
			this.heroList1.FormattingEnabled = true;
			this.heroList1.ItemHeight = 20;
			this.heroList1.Location = new System.Drawing.Point(40, 223);
			this.heroList1.Name = "heroList1";
			this.heroList1.Size = new System.Drawing.Size(254, 224);
			this.heroList1.TabIndex = 10;
			// 
			// heroList2
			// 
			this.heroList2.FormattingEnabled = true;
			this.heroList2.ItemHeight = 20;
			this.heroList2.Location = new System.Drawing.Point(678, 223);
			this.heroList2.Name = "heroList2";
			this.heroList2.Size = new System.Drawing.Size(254, 224);
			this.heroList2.TabIndex = 11;
			// 
			// escapeTextBox
			// 
			this.escapeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.escapeTextBox.Location = new System.Drawing.Point(373, 506);
			this.escapeTextBox.Name = "escapeTextBox";
			this.escapeTextBox.ReadOnly = true;
			this.escapeTextBox.Size = new System.Drawing.Size(222, 26);
			this.escapeTextBox.TabIndex = 12;
			this.escapeTextBox.Text = "Esc - вернуться к таблице.";
			this.escapeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// backgroundBox
			// 
			this.backgroundBox.Location = new System.Drawing.Point(-11, -2);
			this.backgroundBox.Name = "backgroundBox";
			this.backgroundBox.Size = new System.Drawing.Size(1000, 560);
			this.backgroundBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.backgroundBox.TabIndex = 13;
			this.backgroundBox.TabStop = false;
			// 
			// GameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(978, 544);
			this.Controls.Add(this.escapeTextBox);
			this.Controls.Add(this.heroList2);
			this.Controls.Add(this.heroList1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.historyTextBox);
			this.Controls.Add(this.heroNameTextBox2);
			this.Controls.Add(this.roundTextBox);
			this.Controls.Add(this.heroNameTextBox1);
			this.Controls.Add(this.avatarBox2);
			this.Controls.Add(this.avatarBox1);
			this.Controls.Add(this.backgroundBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GameForm";
			this.Text = "Игра";
			this.Load += new System.EventHandler(this.GameForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.avatarBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.avatarBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.backgroundBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox avatarBox1;
		private System.Windows.Forms.PictureBox avatarBox2;
		private System.Windows.Forms.TextBox heroNameTextBox1;
		private System.Windows.Forms.TextBox roundTextBox;
		private System.Windows.Forms.TextBox heroNameTextBox2;
		private System.Windows.Forms.TextBox historyTextBox;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ListBox heroList1;
		private System.Windows.Forms.ListBox heroList2;
		private System.Windows.Forms.TextBox escapeTextBox;
		private System.Windows.Forms.PictureBox backgroundBox;
	}
}