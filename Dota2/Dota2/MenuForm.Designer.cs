namespace Dota2
{
	partial class MenuForm
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
			this.continueGameButton = new System.Windows.Forms.Button();
			this.newGameButton = new System.Windows.Forms.Button();
			this.backgroundGIFBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.backgroundGIFBox)).BeginInit();
			this.SuspendLayout();
			// 
			// continueGameButton
			// 
			this.continueGameButton.Location = new System.Drawing.Point(12, 317);
			this.continueGameButton.Name = "continueGameButton";
			this.continueGameButton.Size = new System.Drawing.Size(184, 65);
			this.continueGameButton.TabIndex = 1;
			this.continueGameButton.Text = "Продолжить";
			this.continueGameButton.UseVisualStyleBackColor = true;
			this.continueGameButton.Click += new System.EventHandler(this.continueGameButton_Click);
			// 
			// newGameButton
			// 
			this.newGameButton.Location = new System.Drawing.Point(682, 317);
			this.newGameButton.Name = "newGameButton";
			this.newGameButton.Size = new System.Drawing.Size(184, 65);
			this.newGameButton.TabIndex = 2;
			this.newGameButton.Text = "Новая игра";
			this.newGameButton.UseVisualStyleBackColor = true;
			this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
			// 
			// backgroundGIFBox
			// 
			this.backgroundGIFBox.ErrorImage = null;
			this.backgroundGIFBox.InitialImage = null;
			this.backgroundGIFBox.Location = new System.Drawing.Point(-11, 1);
			this.backgroundGIFBox.Name = "backgroundGIFBox";
			this.backgroundGIFBox.Size = new System.Drawing.Size(900, 400);
			this.backgroundGIFBox.TabIndex = 3;
			this.backgroundGIFBox.TabStop = false;
			// 
			// MenuForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(878, 394);
			this.Controls.Add(this.newGameButton);
			this.Controls.Add(this.continueGameButton);
			this.Controls.Add(this.backgroundGIFBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MenuForm";
			this.Text = "Dota 2 Refunded";
			this.Load += new System.EventHandler(this.MenuForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.backgroundGIFBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button continueGameButton;
		private System.Windows.Forms.Button newGameButton;
		private System.Windows.Forms.PictureBox backgroundGIFBox;
	}
}