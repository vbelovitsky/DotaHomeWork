using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaLibrary
{
	/// <summary>
	/// Пути до игровых файлов по умолчанию
	/// </summary>
	public static class DotaFilesPaths
	{
	
		public static string DotaTablePath { get; set; } = "../../../Dota2.csv";
		public static string DotaSavedTablePath { get; set; } = "../../../Dota2_CustomTable.csv";

		public static string TableSavedPath { get; set; } = "TableSavedPath.txt";

		public static string DotaSavedGamePath { get; set; } = "SavedGame.xml";
		
	}
}
