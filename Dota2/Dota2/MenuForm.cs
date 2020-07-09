using System;
using System.Media;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using DotaLibrary;
using static DotaLibrary.ParseErrors;
using static DotaLibrary.DotaFilesPaths;

namespace Dota2
{
	/// <summary>
	/// Форма меню
	/// </summary>
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
		/// Открывает таблицу по сохраненному пути, в случае ошибки предлагает выбрать расположение файла.
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

					openFileDialog1.InitialDirectory = "../../../" + AppDomain.CurrentDomain.BaseDirectory;
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

		/// <summary>
		/// Обработчик ошибки парсинга таблицы
		/// </summary>
		/// <param name="error"></param>
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
					MessageBox.Show("Файл с таблицей не найден, поврежден или открыт в другой программе.");
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
			catch (ArgumentException)
			{
				MessageBox.Show("В файле содержатся некорректные значения характеристик героя.");
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

			string message = CheckValues(characteristics);
			if (message != null) throw new ArgumentException();
			
			int index = -1;
			try
			{
				index = int.Parse(hero.Element("index").Value);
			}
			catch (FormatException){}

			return new Hero(index, characteristics.ToArray());
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
				catch (IOException){}
				catch (Exception){}
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
			catch (IOException){}
			catch (Exception){}
		}

		/// <summary>
		/// Загружает обои и музыку в меню
		/// </summary>
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

		/// <summary>
		/// Проверяет значения характеристик героя из XML файла
		/// </summary>
		/// <param name="characteristics"></param>
		/// <returns></returns>
		private string CheckValues(List<string> characteristics)
		{
			string message = null;
			for (int i = 0; i < characteristics.Count - 2; i++)
			{
				message = DotaValidator.Validate(characteristics[i], i);
				if (message != null) return message;
			}

			try
			{
				double.Parse(characteristics[characteristics.Count - 2]);
				double.Parse(characteristics[characteristics.Count - 1]);
			}
			catch (Exception)
			{
				message = "Здоровье не корректно.";
			}

			return message;
		}

		
	}
}
