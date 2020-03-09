using System;
using System.Xml.Linq;
using System.Windows.Forms;
using DotaLibrary;
using static DotaLibrary.DotaFilesPaths;

namespace Dota2
{
	public partial class GameForm : Form
	{

		Hero player;
		Hero enemy;
		int round;
		string historyText;

		const int Attack = 0;
		const int Defence = 1;
		const int Escape = 2;

		bool gameEnded;

		TableForm tableForm;

		static Random rnd = new Random();

		public GameForm(Hero player, Hero enemy, int round, string historyText, TableForm tableForm = null)
		{
			InitializeComponent();

			this.player = player;
			this.enemy = enemy;
			this.round = round;
			this.historyText = historyText;

			this.tableForm = tableForm;
		}

		private void GameForm_Load(object sender, EventArgs e)
		{
			roundTextBox.Text = $"Раунд {round}";
			historyTextBox.AppendText(historyText);
			if (tableForm == null)
			{
				escapeTextBox.Hide();
			}


			UpdateHeroInfo(player, heroNameTextBox1, heroList1);
			UpdateHeroInfo(enemy, heroNameTextBox2, heroList2);
		}

		/// <summary>
		/// Обновление информации на экране
		/// </summary>
		/// <param name="hero"></param>
		/// <param name="nameBox"></param>
		/// <param name="listView"></param>
		private void UpdateHeroInfo(Hero hero, TextBox nameBox, ListBox listView)
		{
			nameBox.Text = hero.Name;


			listView.Items.Clear();
			listView.Items.Add($"Здоровье: {hero.Health:F3}");
			listView.Items.Add($"Макс. здоровье: {hero.MaxHealth:F3}");
			listView.Items.Add($"Урон: {hero.MinDamage}");
			listView.Items.Add($"Сила: {hero.BaseStrength}");
			listView.Items.Add($"Ловкость: {hero.BaseAgility}");
			listView.Items.Add($"Интеллект: {hero.BaseIntelligence}");
			listView.Items.Add($"Скорость: {hero.MoveSpeed}");
			listView.Items.Add($"Броня: {hero.BaseArmor:F3}");
			listView.Items.Add($"Регенерация: {hero.Regeneration:F3}");
		}


		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			switch (e.KeyCode)
			{
				case Keys.Q:
					if (!gameEnded)
						MakeRound(Attack);
					break;
				case Keys.W:
					if (!gameEnded)
						MakeRound(Defence);
					break;
				case Keys.E:
					if (!gameEnded)
						MakeRound(Escape);
					break;
				case Keys.Escape:
					if (tableForm != null)
					{
						Hide();
						tableForm.Show();
					}
					break;
			}
		}

		/// <summary>
		/// Игровой раунд
		/// </summary>
		/// <param name="actionIndex"></param>
		private void MakeRound(int actionIndex)
		{
			// Умный ход бота
			int enemyIndex = rnd.Next(0, 3);

			// Действие двух игроков
			string text = BattleAction(actionIndex, enemyIndex);

			// Обновление истории битвы
			historyTextBox.AppendText(Environment.NewLine + text);

			CheckGameEnd();

			if (!gameEnded)
			{
				SaveToXML();
			}

			round++;
			roundTextBox.Text = $"Раунд {round}";

			if (gameEnded && tableForm == null)
			{
				MessageBox.Show("Сохраненная игра завершена.\nДля начала новой игры перейдите в главное меню.");
			}
		}

		/// <summary>
		/// Проводит боевое действие между двумя игроками
		/// </summary>
		/// <param name="playerAction"></param>
		/// <param name="enemyAction"></param>
		/// <returns></returns>
		private string BattleAction(int playerAction, int enemyAction)
		{
			string text = $"Раунд {round}:" + Environment.NewLine;

			// Оба убегают
			if (playerAction == Escape && enemyAction == Escape)
			{
				text += $"Оба противника решили отступить.";
				if (rnd.Next(0, 10) < 2)
				{
					player.Health += 5 * player.Regeneration;
					text += Environment.NewLine + (player.Health == player.MaxHealth ? $"{player.Name} восстановил здоровье до максимума" :
						$"{player.Name} восстановил {5 * player.Regeneration} здоровья.");
				}
				if (rnd.Next(0, 10) < 2)
				{
					enemy.Health += 5 * enemy.Regeneration;
					text += Environment.NewLine + (enemy.Health == enemy.MaxHealth ? $"{enemy.Name} восстановил здоровье до максимума" :
						$"{enemy.Name} восстановил {5 * enemy.Regeneration} здоровья.");
				}
			}
			// Один убегает
			else if ((playerAction == Escape) ^ (enemyAction == Escape))
			{
				if (playerAction == Escape)
				{
					player.MaxHealth -= player.MaxHealth * 0.01;
					text += $"Отступая, {player.Name} потерял 1% максимального здоровья.";
				}
				else
				{
					enemy.MaxHealth -= enemy.MaxHealth * 0.01;
					text += $"Отступая, {enemy.Name} потерял 1% максимального здоровья.";
				}
			}
			// Оба защищаются
			else if (playerAction == Defence && enemyAction == Defence)
			{
				string[] defenceTexts = { "Противники столкнулись щитами, и ничего не произошло.",
										"Оба воина встали в защитную стойку и стали ждать...",
										"Противники решили передохнуть и заняли оборонительную позицию." };
				text += defenceTexts[rnd.Next(0, defenceTexts.Length)];

			}
			// Оба атакуют
			else if (playerAction == Attack || enemyAction == Attack)
			{
				double playerAttack = player.MinDamage * player.BaseStrength / 10 + player.BaseArmor * player.BaseAgility / 10;
				double enemyAttack = enemy.MinDamage * enemy.BaseStrength / 10 + enemy.BaseArmor * enemy.BaseAgility / 10;

				if (playerAttack > enemyAttack + 10)
				{


					double damage = player.MinDamage * player.BaseStrength / 20;
					enemy.Health -= damage;
					text += $"{player.Name} нанес {enemy.Name} {damage} урона.";

					// Магический ответный урон
					if (enemy.BaseIntelligence > player.BaseIntelligence)
					{
						double magicCounterDamage = enemy.BaseIntelligence * rnd.Next(2, 7);
						player.Health -= magicCounterDamage;
						text += Environment.NewLine + $"{enemy.Name} нанес в ответ {magicCounterDamage} магического урона.";
					}
				}
				else if (enemyAttack > playerAttack + 10)
				{
					double damage = enemy.MinDamage * enemy.BaseStrength / 20;
					player.Health -= damage;
					text = $"{enemy.Name} нанес {player.Name} {damage} урона.";

					// Магический ответный урон
					if (player.BaseIntelligence > enemy.BaseIntelligence)
					{
						double magicCounterDamage = player.BaseIntelligence * rnd.Next(2, 7);
						enemy.Health -= magicCounterDamage;
						text += Environment.NewLine + $"{player.Name} нанес в ответ {magicCounterDamage} магического урона.";
					}
				}
				else
				{
					double playerDamage = player.MinDamage * player.BaseStrength / 25;
					double enemyDamage = enemy.MinDamage * enemy.BaseStrength / 25;
					player.Health -= enemyDamage;
					enemy.Health -= playerDamage;
					text = $"Противники бились с невероятной жестокостью." + Environment.NewLine +
						$"{player.Name} нанес врагу {playerDamage} урона, а {enemy.Name} в ответ {enemyDamage} урона.";
				}
			}

			UpdateHeroInfo(player, heroNameTextBox1, heroList1);
			UpdateHeroInfo(enemy, heroNameTextBox2, heroList2);

			return text;
		}

		/// <summary>
		/// Проверяет, окончилась ли игра.
		/// </summary>
		private void CheckGameEnd()
		{
			if ((player.Health == 0) ^ (enemy.Health == 0))
			{
				string looser = string.Empty;
				string winner = string.Empty;
				if (player.Health == 0)
				{
					gameEnded = true;
					looser = player.Name;
					winner = enemy.Name;
				}
				else if (enemy.Health == 0)
				{
					gameEnded = true;
					looser = enemy.Name;
					winner = player.Name;
				}
				string[] endTexts = {$"После тяжелого боя {winner} наконец уничтожил {looser}.",
					$"{looser} был повержен ударом {winner}. Битва окончена.",
					$"{winner} добил мощным ударом {looser}."};
				historyTextBox.AppendText(Environment.NewLine + endTexts[rnd.Next(0, endTexts.Length)]);
			}
			else if (player.Health == 0 && enemy.Health == 0)
			{
				gameEnded = true;
				historyTextBox.AppendText(Environment.NewLine + $"Силы оказались равны. {player.Name} и {enemy.Name} истекли кровью.");
			}
		}

		/// <summary>
		/// Сохраняет текущую игру в файл XML
		/// </summary>
		private void SaveToXML()
		{
			XDocument doc = new XDocument(new XElement("game",
												new XElement("playerHero",
													new XElement("name", player.Name),
													new XElement("type", player.Type),
													new XElement("baseStrength", player.BaseStrength),
													new XElement("baseAgility", player.BaseAgility),
													new XElement("baseIntelligence", player.BaseIntelligence),
													new XElement("moveSpeed", player.MoveSpeed),
													new XElement("baseArmor", $"{player.BaseArmor:F3}"),
													new XElement("minDamage", player.MinDamage),
													new XElement("regeneration", $"{player.Regeneration:F3}"),
													new XElement("health", $"{player.Health:F3}"),
													new XElement("maxHealth", $"{player.MaxHealth:F3}")),
												new XElement("enemyHero",
													new XElement("name", enemy.Name),
													new XElement("type", enemy.Type),
													new XElement("baseStrength", enemy.BaseStrength),
													new XElement("baseAgility", enemy.BaseAgility),
													new XElement("baseIntelligence", enemy.BaseIntelligence),
													new XElement("moveSpeed", enemy.MoveSpeed),
													new XElement("baseArmor", $"{enemy.BaseArmor:F3}"),
													new XElement("minDamage", enemy.MinDamage),
													new XElement("regeneration", $"{enemy.Regeneration:F3}"),
													new XElement("health", $"{enemy.Health:F3}"),
													new XElement("maxHealth", $"{enemy.MaxHealth:F3}")),
												new XElement("round", round),
												new XElement("history", historyTextBox.Text)
											)
										  );

			doc.Save(DotaSavedGamePath);
		}

	}
}
