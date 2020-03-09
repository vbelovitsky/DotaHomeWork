using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotaLibrary;
using static DotaLibrary.Characteristics;
using static DotaLibrary.ValueBounds;

namespace Dota2
{
	public partial class TableForm : Form
	{
		
		string tempPreviousValue;
		int selectedHeroIndex = -1;
		static Random rnd = new Random();

		DataTable table;

		List<string[]> characteristics;
		

		public TableForm(List<string[]> characteristics)
		{
			InitializeComponent();
			this.characteristics = characteristics;
		}

		private void TableForm_Load(object sender, EventArgs e)
		{
			FillGrid(characteristics);
			FillFilterValues();
		}

		/// <summary>
		/// Заполняет dataGridView полученными характеристиками
		/// </summary>
		/// <param name="characteristics"></param>
		private void FillGrid(List<string[]> characteristics)
		{
			table = new DataTable();
			for(int i = 0; i < 9; i++)
			{
				DataColumn column = new DataColumn(characteristics[0][i]);
				table.Columns.Add(column);
			}
			for(int i = 1; i < characteristics.Count(); i++)
			{
				table.Rows.Add(characteristics[i]);
			}
			dotaGridView.DataSource = table;

			dotaGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			for(int i = 1; i < dotaGridView.ColumnCount; i++)
			{
				dotaGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			}
		}

		private void FillFilterValues()
		{
			typeComboBox.DataSource = new string[] { "Любой", "0", "1", "2" };

			minSpeedEditText.Text = SpeedMinValue.ToString();
			maxSpeedEditText.Text = SpeedMaxValue.ToString();

			minRegEditText.Text = RegenerationMinValue.ToString();
			maxRegEditText.Text = RegenerationMaxValue.ToString();
		}

		/// <summary>
		/// Обработчик начала редактирования на клетки, сохраняется значение клетки
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dotaGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			tempPreviousValue = dotaGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
		}

		/// <summary>
		/// Обработчик завершения редактирования клетки, валидация значения
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dotaGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			string value = dotaGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
			string message = DotaValidator.Validate(value, e.ColumnIndex);
			if(message != null)
			{
				ErrorHandling(message, e.RowIndex, e.ColumnIndex);
			}
			else
			{
				UpdateSelectedHero(e.RowIndex);
			}

		}
		
		/// <summary>
		/// Обработчик ошибки валидации, возвращение первоначального значения в клетку
		/// </summary>
		/// <param name="message"></param>
		/// <param name="rowIndex"></param>
		/// <param name="colIndex"></param>
		private void ErrorHandling(string message, int rowIndex, int colIndex)
		{
			dotaGridView.Rows[rowIndex].Cells[colIndex].Value = tempPreviousValue;
			MessageBox.Show(message);
		}
		
		/// <summary>
		/// Сохраняет измененную таблицу
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void saveTableButton_Click(object sender, EventArgs e)
		{
			dotaGridView.SaveTableToCSV();
		}

		/// <summary>
		/// Нажатие на клетку. Обновляет выбранного героя, если был клик по имени.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dotaGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.ColumnIndex == 0)
			{
				UpdateSelectedHero(e.RowIndex);
			}
			
		}

		/// <summary>
		/// Обновляет текст и индекс выбранного героя.
		/// </summary>
		/// <param name="rowIndex"></param>
		private void UpdateSelectedHero(int rowIndex)
		{
			selectedHeroTextBox.Text = $"Выбранный герой: {dotaGridView.Rows[rowIndex].Cells[0].Value}";
			selectedHeroIndex = rowIndex;
		}


		private void minSpeedEditText_Leave(object sender, EventArgs e)
		{
			SetValidatedFilterValue(minSpeedEditText, MoveSpeed, SpeedMinValue);
		}

		private void maxSpeedEditText_Leave(object sender, EventArgs e)
		{
			SetValidatedFilterValue(maxSpeedEditText, MoveSpeed, SpeedMaxValue);
		}

		private void minRegEditText_Leave(object sender, EventArgs e)
		{
			SetValidatedFilterValue(minRegEditText, Regeneration, RegenerationMinValue);
		}

		private void maxRegEditText_Leave(object sender, EventArgs e)
		{
			SetValidatedFilterValue(maxRegEditText, Regeneration, RegenerationMaxValue);
		}

		private void SetValidatedFilterValue(TextBox box, Characteristics chr, object value)
		{
			string tmp = DotaValidator.Validate(box.Text, (int)chr);
			if (tmp != null)
			{
				box.Text = value.ToString();
			}
		}

		/// <summary>
		/// Фильтрует таблицу по выбранным фильтрам
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void filterApplyButton_Click(object sender, EventArgs e)
		{
			try
			{
				// Названия заголовков
				string type = table.Columns[(int)HeroType].ColumnName;
				string speed = table.Columns[(int)MoveSpeed].ColumnName;
				string regeneration = table.Columns[(int)Regeneration].ColumnName;

				// Фильтры
				string typeFilter = typeComboBox.SelectedItem.ToString() == "Любой" ? string.Empty : $"{type} = {typeComboBox.SelectedItem.ToString()}";
				string speedFilter = $"{speed} >= {minSpeedEditText.Text} AND {speed} <= {maxSpeedEditText.Text}";
				string regFilter = $"{regeneration} >= '{minRegEditText.Text.Replace(',', '.')}' AND {regeneration} <= '{maxRegEditText.Text.Replace(',', '.')}'";

				string filter = typeFilter + (typeFilter.Equals(string.Empty) ? string.Empty : " AND ") + speedFilter + " AND " + regFilter;

				// Присвоение фильтра таблице
				table.DefaultView.RowFilter = filter;
			}
			catch (SyntaxErrorException)
			{
				MessageBox.Show("Возникла ошибка при фильтрации данных, попробуйте перезайти в таблицу.");
			}
			catch (Exception)
			{
				MessageBox.Show("Возникла ошибка при фильтрации данных, попробуйте перезайти в таблицу.");
			}

		}

		/// <summary>
		/// Сбрасывает параметры фильтра
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void resetFilterButton_Click(object sender, EventArgs e)
		{

			FillFilterValues();
			table.DefaultView.RowFilter = string.Empty;
		}

		/// <summary>
		/// Начинает игру с выбранным героем. Компьютер выбирает случайно другого героя.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void startGameButton_Click(object sender, EventArgs e)
		{
			if(selectedHeroIndex == -1)
			{
				MessageBox.Show("Для начала игры выберите героя.\nЧтобы это сделать, кликните на его имя.");
			}
			else
			{
				int enemyHeroIndex = -1;
				do
				{
					int tmp = rnd.Next(0, table.Rows.Count);
					enemyHeroIndex = tmp == selectedHeroIndex ? -1 : tmp;
				}
				while (enemyHeroIndex == -1);

				Hero playerHero = CreateHero(selectedHeroIndex);
				Hero enemyHero = CreateHero(enemyHeroIndex);

				GameForm gameForm = new GameForm(playerHero, enemyHero, 1, "История битвы.", this);
				gameForm.Show();
				Hide();
			}
		}

		private Hero CreateHero(int index)
		{
			List<string> heroCharacteristics = new List<string>();

			for(int i = 0; i < table.Rows[index].ItemArray.Length; i++)
			{
				heroCharacteristics.Add(table.Rows[index].ItemArray[i].ToString());
			}

			Hero hero = new Hero(heroCharacteristics.ToArray());
			return hero;
		}
	}

	
}
