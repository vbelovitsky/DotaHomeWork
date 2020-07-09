namespace Dota2
{
	partial class TableForm
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
			this.dotaGridView = new System.Windows.Forms.DataGridView();
			this.saveTableButton = new System.Windows.Forms.Button();
			this.minSpeedEditText = new System.Windows.Forms.TextBox();
			this.maxSpeedEditText = new System.Windows.Forms.TextBox();
			this.minRegEditText = new System.Windows.Forms.TextBox();
			this.maxRegEditText = new System.Windows.Forms.TextBox();
			this.typeText = new System.Windows.Forms.TextBox();
			this.speedTextBox = new System.Windows.Forms.TextBox();
			this.regenerationTextBox = new System.Windows.Forms.TextBox();
			this.filterApplyButton = new System.Windows.Forms.Button();
			this.typeComboBox = new System.Windows.Forms.ComboBox();
			this.resetFilterButton = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.startGameButton = new System.Windows.Forms.Button();
			this.selectedHeroTextBox = new System.Windows.Forms.TextBox();
			this.tableBackgroundBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.dotaGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tableBackgroundBox)).BeginInit();
			this.SuspendLayout();
			// 
			// dotaGridView
			// 
			this.dotaGridView.AccessibleName = "";
			this.dotaGridView.AllowUserToAddRows = false;
			this.dotaGridView.AllowUserToDeleteRows = false;
			this.dotaGridView.AllowUserToResizeColumns = false;
			this.dotaGridView.AllowUserToResizeRows = false;
			this.dotaGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.dotaGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dotaGridView.Location = new System.Drawing.Point(12, 147);
			this.dotaGridView.MultiSelect = false;
			this.dotaGridView.Name = "dotaGridView";
			this.dotaGridView.RowTemplate.Height = 28;
			this.dotaGridView.Size = new System.Drawing.Size(1204, 463);
			this.dotaGridView.TabIndex = 0;
			this.dotaGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dotaGridView_CellBeginEdit);
			this.dotaGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dotaGridView_CellClick);
			this.dotaGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dotaGridView_CellEndEdit);
			// 
			// saveTableButton
			// 
			this.saveTableButton.Location = new System.Drawing.Point(12, 629);
			this.saveTableButton.Name = "saveTableButton";
			this.saveTableButton.Size = new System.Drawing.Size(187, 46);
			this.saveTableButton.TabIndex = 1;
			this.saveTableButton.Text = "Сохранить таблицу";
			this.saveTableButton.UseVisualStyleBackColor = true;
			this.saveTableButton.Click += new System.EventHandler(this.saveTableButton_Click);
			// 
			// minSpeedEditText
			// 
			this.minSpeedEditText.Location = new System.Drawing.Point(356, 85);
			this.minSpeedEditText.Name = "minSpeedEditText";
			this.minSpeedEditText.Size = new System.Drawing.Size(100, 26);
			this.minSpeedEditText.TabIndex = 3;
			this.minSpeedEditText.Leave += new System.EventHandler(this.minSpeedEditText_Leave);
			// 
			// maxSpeedEditText
			// 
			this.maxSpeedEditText.Location = new System.Drawing.Point(462, 85);
			this.maxSpeedEditText.Name = "maxSpeedEditText";
			this.maxSpeedEditText.Size = new System.Drawing.Size(100, 26);
			this.maxSpeedEditText.TabIndex = 4;
			this.maxSpeedEditText.Leave += new System.EventHandler(this.maxSpeedEditText_Leave);
			// 
			// minRegEditText
			// 
			this.minRegEditText.Location = new System.Drawing.Point(705, 85);
			this.minRegEditText.Name = "minRegEditText";
			this.minRegEditText.Size = new System.Drawing.Size(100, 26);
			this.minRegEditText.TabIndex = 5;
			this.minRegEditText.Leave += new System.EventHandler(this.minRegEditText_Leave);
			// 
			// maxRegEditText
			// 
			this.maxRegEditText.Location = new System.Drawing.Point(811, 85);
			this.maxRegEditText.Name = "maxRegEditText";
			this.maxRegEditText.Size = new System.Drawing.Size(100, 26);
			this.maxRegEditText.TabIndex = 6;
			this.maxRegEditText.Leave += new System.EventHandler(this.maxRegEditText_Leave);
			// 
			// typeText
			// 
			this.typeText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.typeText.Location = new System.Drawing.Point(23, 88);
			this.typeText.Name = "typeText";
			this.typeText.ReadOnly = true;
			this.typeText.Size = new System.Drawing.Size(75, 19);
			this.typeText.TabIndex = 7;
			this.typeText.Text = "Тип героя";
			// 
			// speedTextBox
			// 
			this.speedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.speedTextBox.Location = new System.Drawing.Point(275, 88);
			this.speedTextBox.Name = "speedTextBox";
			this.speedTextBox.ReadOnly = true;
			this.speedTextBox.Size = new System.Drawing.Size(75, 19);
			this.speedTextBox.TabIndex = 8;
			this.speedTextBox.Text = "Скорость";
			// 
			// regenerationTextBox
			// 
			this.regenerationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.regenerationTextBox.Location = new System.Drawing.Point(599, 88);
			this.regenerationTextBox.Name = "regenerationTextBox";
			this.regenerationTextBox.ReadOnly = true;
			this.regenerationTextBox.Size = new System.Drawing.Size(100, 19);
			this.regenerationTextBox.TabIndex = 9;
			this.regenerationTextBox.Text = "Регенерация";
			// 
			// filterApplyButton
			// 
			this.filterApplyButton.Location = new System.Drawing.Point(976, 71);
			this.filterApplyButton.Name = "filterApplyButton";
			this.filterApplyButton.Size = new System.Drawing.Size(117, 55);
			this.filterApplyButton.TabIndex = 10;
			this.filterApplyButton.Text = "Применить фильтр";
			this.filterApplyButton.UseVisualStyleBackColor = true;
			this.filterApplyButton.Click += new System.EventHandler(this.filterApplyButton_Click);
			// 
			// typeComboBox
			// 
			this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.typeComboBox.FormattingEnabled = true;
			this.typeComboBox.Location = new System.Drawing.Point(104, 85);
			this.typeComboBox.Name = "typeComboBox";
			this.typeComboBox.Size = new System.Drawing.Size(106, 28);
			this.typeComboBox.TabIndex = 11;
			// 
			// resetFilterButton
			// 
			this.resetFilterButton.Location = new System.Drawing.Point(1099, 71);
			this.resetFilterButton.Name = "resetFilterButton";
			this.resetFilterButton.Size = new System.Drawing.Size(117, 55);
			this.resetFilterButton.TabIndex = 12;
			this.resetFilterButton.Text = "Сбросить фильтр";
			this.resetFilterButton.UseVisualStyleBackColor = true;
			this.resetFilterButton.Click += new System.EventHandler(this.resetFilterButton_Click);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Location = new System.Drawing.Point(559, 23);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(130, 19);
			this.textBox1.TabIndex = 13;
			this.textBox1.Text = "Выберите героя!";
			// 
			// startGameButton
			// 
			this.startGameButton.Location = new System.Drawing.Point(1065, 629);
			this.startGameButton.Name = "startGameButton";
			this.startGameButton.Size = new System.Drawing.Size(151, 46);
			this.startGameButton.TabIndex = 14;
			this.startGameButton.Text = "Начать битву!";
			this.startGameButton.UseVisualStyleBackColor = true;
			this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
			// 
			// selectedHeroTextBox
			// 
			this.selectedHeroTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.selectedHeroTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.selectedHeroTextBox.Location = new System.Drawing.Point(703, 642);
			this.selectedHeroTextBox.Name = "selectedHeroTextBox";
			this.selectedHeroTextBox.ReadOnly = true;
			this.selectedHeroTextBox.Size = new System.Drawing.Size(350, 19);
			this.selectedHeroTextBox.TabIndex = 15;
			this.selectedHeroTextBox.Text = "Герой не выбран";
			// 
			// tableBackgroundBox
			// 
			this.tableBackgroundBox.Location = new System.Drawing.Point(-9, -10);
			this.tableBackgroundBox.Name = "tableBackgroundBox";
			this.tableBackgroundBox.Size = new System.Drawing.Size(1250, 710);
			this.tableBackgroundBox.TabIndex = 17;
			this.tableBackgroundBox.TabStop = false;
			// 
			// TableForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1228, 694);
			this.Controls.Add(this.selectedHeroTextBox);
			this.Controls.Add(this.startGameButton);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.resetFilterButton);
			this.Controls.Add(this.typeComboBox);
			this.Controls.Add(this.filterApplyButton);
			this.Controls.Add(this.regenerationTextBox);
			this.Controls.Add(this.speedTextBox);
			this.Controls.Add(this.typeText);
			this.Controls.Add(this.maxRegEditText);
			this.Controls.Add(this.minRegEditText);
			this.Controls.Add(this.maxSpeedEditText);
			this.Controls.Add(this.minSpeedEditText);
			this.Controls.Add(this.saveTableButton);
			this.Controls.Add(this.dotaGridView);
			this.Controls.Add(this.tableBackgroundBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TableForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Таблица героев";
			this.Load += new System.EventHandler(this.TableForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dotaGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tableBackgroundBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dotaGridView;
		private System.Windows.Forms.Button saveTableButton;
		private System.Windows.Forms.TextBox minSpeedEditText;
		private System.Windows.Forms.TextBox maxSpeedEditText;
		private System.Windows.Forms.TextBox minRegEditText;
		private System.Windows.Forms.TextBox maxRegEditText;
		private System.Windows.Forms.TextBox typeText;
		private System.Windows.Forms.TextBox speedTextBox;
		private System.Windows.Forms.TextBox regenerationTextBox;
		private System.Windows.Forms.Button filterApplyButton;
		private System.Windows.Forms.ComboBox typeComboBox;
		private System.Windows.Forms.Button resetFilterButton;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button startGameButton;
		private System.Windows.Forms.TextBox selectedHeroTextBox;
		private System.Windows.Forms.PictureBox tableBackgroundBox;
	}
}

