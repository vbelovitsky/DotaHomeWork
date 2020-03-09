using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaLibrary
{
	public static class ValueBounds
	{
		public static int NameMinLength { get; } = 1;
		public static int NameMaxLength { get; } = 20;

		public static int TypeMinValue { get; } = 0;
		public static int TypeMaxValue { get; } = 2;

		public static int StrengthMinValue { get; } = 10;
		public static int StrengthMaxValue { get; } = 200;

		public static int AgilityMinValue { get; } = 0;
		public static int AgilityMaxValue { get; } = 100;

		public static int IntelligenceMinValue { get; } = 0;
		public static int IntelligenceMaxValue { get; } = 100;

		public static int SpeedMinValue { get; } = 50;
		public static int SpeedMaxValue { get; } = 1000;

		public static double ArmorMinValue { get; } = 0;
		public static double ArmorMaxValue { get; } = 50;

		public static int DamageMinValue { get; } = 10;
		public static int DamageMaxValue { get; } = 500;

		public static double RegenerationMinValue { get; } = 0.1;
		public static double RegenerationMaxValue { get; } = 50;

	}
}
