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
using static DotaLibrary.ParseErrors;
using static DotaLibrary.DotaFilesPaths;

namespace Dota2
{
	public partial class MenuForm : Form
	{

		bool tableError;

		public MenuForm()
		{
			InitializeComponent();
			DotaParser.onParseFailed += ErrorHandler;
		}

		private void MenuForm_Load(object sender, EventArgs e)
		{

		}


		private void newGameButton_Click(object sender, EventArgs e)
		{
			RunTableForm();
		}



		/// <summary>
		/// Запускает форму с таблицей. Одновременно может быть открыта только одна такая форма.
		/// </summary>
		/// <param name="characteristics"></param>
		private void RunTableForm()
		{
			TableForm tempForm = Application.OpenForms["TableForm"] as TableForm;
			if (tempForm != null)
			{
				tempForm.Show();
			}
			else
			{
				OpenTable();
			}
		}

		/// <summary>
		/// Открывает таблицу по пути по умолчанию, в случае ошибки предлагает выбрать расположение файла.
		/// </summary>
		private void OpenTable()
		{
			bool openedOrCancelled = false;
			char separator = ';';

			do
			{
				List<string[]> characteristics = DotaParser.Read(DotaTablePath, separator);

				if (!tableError)
				{
					TableForm tableForm = new TableForm(characteristics);
					tableForm.Show();

					openedOrCancelled = true;
				}
				else
				{
					

					OpenFileDialog openFileDialog1 = new OpenFileDialog();

					openFileDialog1.InitialDirectory = "c:\\";
					openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
					openFileDialog1.FilterIndex = 0;
					openFileDialog1.RestoreDirectory = true;

					if (openFileDialog1.ShowDialog() == DialogResult.OK)
					{
						DotaTablePath = openFileDialog1.FileName;
					}
					else
					{
						openedOrCancelled = true;
					}
				}
			}
			while (!openedOrCancelled);
		}

		private void ErrorHandler(ParseErrors error)
		{
			switch (error)
			{
				case ValueError:
					MessageBox.Show("В таблице содержится некорректное значение характеристики героя.");
					break;
				case SeparationError:
					MessageBox.Show("В строке таблицы содержится некорректное количество сепараторов ';'.");
					break;
				case FileError:
					MessageBox.Show("Файл с таблицей не найден, поврежден или открыт в другой программе. ");
					break;
				case UndefinedError:
					MessageBox.Show("Произошла ошибка при работе с таблицей.");
					break;
			}
			tableError = true;

			if (error == Success)
			{
				tableError = false;
			}

		}


	}
}
