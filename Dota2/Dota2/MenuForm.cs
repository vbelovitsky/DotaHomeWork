using System;
using System.Xml.Linq;
using System.Collections.Generic;
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

		private void continueGameButton_Click(object sender, EventArgs e)
		{
			try
			{
				ReadXMLFile();
			}
			catch (Exception)
			{
				MessageBox.Show("Файл сохранения не найден или поврежден.");
			}
		}

		private void ReadXMLFile()
		{
			XDocument doc = XDocument.Load(DotaSavedGamePath);
			XElement game = doc.Element("game");
			XElement playerHero = game.Element("playerHero");
			XElement enemyHero = game.Element("enemyHero");

			Hero player = ReadHero(playerHero);
			Hero enemy = ReadHero(enemyHero);
			int round = int.Parse(game.Element("round").Value);
			string history = game.Element("history").Value;

			GameForm gameForm = new GameForm(player, enemy, round, history);
			gameForm.Show();
		}

		private Hero ReadHero(XElement hero)
		{
			List<string> characteristics = new List<string>();
			characteristics.Add(hero.Element("name").Value);
			characteristics.Add(hero.Element("type").Value);
			characteristics.Add(hero.Element("baseStrength").Value);
			characteristics.Add(hero.Element("baseAgility").Value);
			characteristics.Add(hero.Element("baseIntelligence").Value);
			characteristics.Add(hero.Element("moveSpeed").Value);
			characteristics.Add(hero.Element("baseArmor").Value);
			characteristics.Add(hero.Element("minDamage").Value);
			characteristics.Add(hero.Element("regeneration").Value);
			characteristics.Add(hero.Element("health").Value);
			characteristics.Add(hero.Element("maxHealth").Value);
			return new Hero(characteristics.ToArray());
		}									 
	}
}
