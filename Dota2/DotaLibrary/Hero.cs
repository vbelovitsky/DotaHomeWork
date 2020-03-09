using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaLibrary
{
    public class Hero
    {
		// Базовые характеристики героя, нельзя менять
		public string Name { get; private set; }
		public int Type { get; private set; }
		public int BaseStrength { get; private set; }
		public int BaseAgility { get; private set; }
		public int BaseIntelligence { get; private set; }
		public int MoveSpeed { get; private set; }
		public double BaseArmor { get; private set; }
		public int MinDamage { get; private set; }
		public double Regeneration { get; private set; }

		// Здоровье персонажа, меняется в течение игры
		double health;
		public double Health
		{
			get
			{
				return health;
			}
			set
			{
				if (value <= 0)
				{
					health = 0;
				}
				else if (value > MaxHealth)
				{
					health = MaxHealth;
				}
				else
				{
					health = value;
				}
			}
		}

		double maxHealth;
		public double MaxHealth
		{
			get
			{
				return maxHealth;
			}
			set
			{
				if (value <= 0)
				{
					maxHealth = 2;
					health = 2;
				}
				else
				{
					maxHealth = value;
					if(health > maxHealth)
					{
						health = maxHealth;
					}
				}
			}
		}
		int healthCoefficient = 29;

		// Строковый массив характеристик героя
		public string[] characteristics;

		public Hero(params string[] characteristics)
		{
			this.characteristics = characteristics;
			SetValues();
		}

		private void SetValues()
		{
			try
			{
				Name = characteristics[0];
				Type = int.Parse(characteristics[1]);
				BaseStrength = int.Parse(characteristics[2]);
				BaseAgility = int.Parse(characteristics[3]);
				BaseIntelligence = int.Parse(characteristics[4]);
				MoveSpeed = int.Parse(characteristics[5]);
				BaseArmor = double.Parse(characteristics[6]);
				MinDamage = int.Parse(characteristics[7]);
				Regeneration = double.Parse(characteristics[8]);

				MaxHealth = healthCoefficient * BaseStrength;
				Health = healthCoefficient * BaseStrength;
			}
			catch (FormatException)
			{
				Console.WriteLine("Герой не создан");
			}
			catch (Exception)
			{
				Console.WriteLine("Ошибка при создании героя");
			}
		}

    }
}
