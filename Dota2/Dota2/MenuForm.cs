using System;
using System.Media;
using System.IO;
using System.Drawing;
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

		ParseErrors tableError;

		public MenuForm()
		{
			InitializeComponent();
			DotaParser.onParseFailed += ErrorHandler;
		}

		private void MenuForm_Load(object sender, EventArgs e)
		{
			LoadDisign();
			
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

			string path = GetTableSavedPath();

			do
			{
				List<string[]> characteristics = DotaParser.Read(path, separator);

				if (tableError == Success)
				{
					TableForm tableForm = new TableForm(characteristics);
					tableForm.Show();

					SetTableSavedPath(path);
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
						path = openFileDialog1.FileName;
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
			tableError = error;
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

		}

		/// <summary>
		/// Нажатие на кнопку продолжения игры
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// Считывает XML файл сохраненной игры
		/// </summary>
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

		/// <summary>
		/// Считывает характеристики героя из XML файла
		/// </summary>
		/// <param name="hero"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Достает последний путь до последней открытой таблицы
		/// </summary>
		/// <returns></returns>
		private string GetTableSavedPath()
		{
			string path = null;
			if (File.Exists(TableSavedPath))
			{
				try
				{
					path = File.ReadAllText(TableSavedPath);
				}
				catch (IOException)
				{

				}
				catch (Exception)
				{

				}
			}
			return path;
		}

		/// <summary>
		/// Сохраняет путь до последней открытой таблицы
		/// </summary>
		/// <param name="path"></param>
		private void SetTableSavedPath(string path)
		{
			try
			{
				File.WriteAllText(TableSavedPath, path);
			}
			catch (IOException)
			{

			}
			catch (Exception)
			{

			}
		}


		private void LoadDisign()
		{
			try
			{
				backgroundGIFBox.Image = Properties.Resources.PudgeVSJugWallpaper;
				backgroundGIFBox.SizeMode = PictureBoxSizeMode.Zoom;
			}
			catch (Exception) { }

			try
			{
				SoundPlayer soundPlayer = new SoundPlayer("../../Resources/AgeOfWarSound.wav");
				soundPlayer.Play();
			}
			catch (Exception) { }
		}
	}
}
