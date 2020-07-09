using System;

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

		/// <summary>
		/// Индекс героя в таблице (для аватарок)
		/// </summary>
		public int Index { get; private set; }

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
					if (health > maxHealth)
					{
						health = maxHealth;
					}
				}
			}
		}
		int healthCoefficient = 29;

		// Строковый массив характеристик героя
		public string[] characteristics;


		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="index"></param>
		/// <param name="characteristics">Массив характеристик. Значения должны быть валидными, в соответствии с классом ValueBounds</param>
		public Hero(int index, params string[] characteristics)
		{
			Index = index;
			this.characteristics = characteristics;
			SetValues();

			// Если герой создается для продолжения игры
			try
			{
				MaxHealth = double.Parse(characteristics[10]);
				Health = double.Parse(characteristics[9]);
			}
			catch (Exception){}
		}

		/// <summary>
		/// Устанавливает переданные значения. Кидает исключения, если значения не верные
		/// </summary>
		private void SetValues()
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

	}
}
