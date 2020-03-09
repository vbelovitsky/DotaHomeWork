using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DotaLibrary.Characteristics;
using static DotaLibrary.ValueBounds;

namespace DotaLibrary
{

	public static class DotaValidator
	{

		public static string Validate(string value, int colIndex)
		{
			string message = null;
			if (value == null)
			{
				return message = "Ячейка не должна быть пустой";
			}
			
			switch (colIndex)
			{
				case (int)HeroName:
					try
					{
						string name = value;
						if (!(name.Length >= NameMinLength && name.Length <= NameMaxLength))
						{
							message = $"Имя должно содержать от {NameMinLength} до {NameMaxLength} символов.";
						}
						if (name.Contains(';'))
						{
							message = "Недопустимый символ в имени героя";
						}
					}
					catch (Exception)
					{
						message = $"Имя должно содержать от {NameMinLength} до {NameMaxLength} символов.";
					}
					break;
				case (int)HeroType:
					try
					{
						int type = int.Parse(value);
						if (!(type >= TypeMinValue && type <= TypeMaxValue))
						{
							throw new Exception();
						}
					}
					catch (Exception)
					{
						message = "Тип героя может быть числом 0, 1 или 2.";
					}
					break;
				case (int)BaseStrength:
					try
					{
						int strength = int.Parse(value);
						if (!(strength >= StrengthMinValue && strength <= StrengthMaxValue))
						{
							throw new Exception();
						}
					}
					catch (Exception)
					{
						message = $"Сила героя может быть целым числом от {StrengthMinValue} до {StrengthMaxValue}";
					}
					break;
				case (int)BaseAgility:
					try
					{
						int agility = int.Parse(value);
						if (!(agility >= AgilityMinValue && agility <= AgilityMaxValue))
						{
							throw new Exception();
						}
					}
					catch (Exception)
					{
						message = $"Ловкость героя может быть целым числом от {AgilityMinValue} до {AgilityMaxValue}";
					}
					break;
				case (int)BaseIntelligence:
					try
					{
						int intelligence = int.Parse(value);
						if (!(intelligence >= IntelligenceMinValue && intelligence <= IntelligenceMaxValue))
						{
							throw new Exception();
						}
					}
					catch (Exception)
					{
						message = $"Интеллект героя может быть целым числом от {IntelligenceMinValue} до {IntelligenceMaxValue}";
					}
					break;
				case (int)MoveSpeed:
					try
					{
						int speed = int.Parse(value);
						if (!(speed >= SpeedMinValue && speed <= SpeedMaxValue))
						{
							throw new Exception();
						}
					}
					catch (Exception)
					{
						message = $"Скорость героя может быть целым числом от {SpeedMinValue} до {SpeedMaxValue}";
					}
					break;
				case (int)BaseArmor:
					try
					{
						double armor = double.Parse(value);
						if (!(armor >= ArmorMinValue && armor <= ArmorMaxValue))
						{
							throw new Exception();
						}
					}
					catch (Exception)
					{
						message = $"Броня героя может быть вещественным числом от {ArmorMinValue} до {ArmorMaxValue}";
					}
					break;
				case (int)MinDamage:
					try
					{
						int damage = int.Parse(value);
						if (!(damage >= DamageMinValue && damage <= DamageMaxValue))
						{
							throw new Exception();
						}
					}
					catch (Exception)
					{
						message = $"Минимальный урон героя может быть целым числом от {DamageMinValue} до {DamageMaxValue}";
					}
					break;
				case (int)Regeneration:
					try
					{
						double regeneration = double.Parse(value);
						if (!(regeneration >= RegenerationMinValue && regeneration <= RegenerationMaxValue))
						{
							throw new Exception();
						}
					}
					catch (Exception)
					{
						message = $"Ренегация героя может быть вещественным числом от {RegenerationMinValue} до {RegenerationMaxValue}";
					}
					break;
				default:
					break;
			}
			
			return message;
		}
	}
}
