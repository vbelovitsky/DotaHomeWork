using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DotaLibrary.ParseErrors;

namespace DotaLibrary
{

	public delegate void ParseFailure(ParseErrors error);

	/// <summary>
	/// Класс для парсинга данных из файла
	/// </summary>
	public static class DotaParser
	{

		public static event ParseFailure onParseFailed;
		
		static int colCount = 9;

		static bool valueErrorFlag;

		/// <summary>
		/// Считывает данные из csv файла, валидирует файл и формирует список строк таблицы
		/// </summary>
		/// <returns></returns>
		public static List<string[]> Read(string fileName, char separator)
		{
			List<string[]> allCharacteristics = new List<string[]>();

			try
			{

				if(fileName == null)
				{
					throw new IOException();
				}
				using (StreamReader reader = new StreamReader(fileName))
				{
					int rowIndex = 0;
					while (!reader.EndOfStream)
					{
						string row = reader.ReadLine();
						string[] values = row.Split(separator);

						Console.WriteLine(values.Length);

						// Валидация парсинга
						// Проверка на корректное количество сепараторов
						if (values.Length != colCount)
						{
							throw new FormatException();
						}

						// Изменение точек на запятые для вещественных чисел
						values[6] = values[6].Replace('.', ',');
						values[8] = values[8].Replace('.', ',');

						// Валидация значений в строке (без строки заголовков столбцов)
						if (rowIndex > 0)
						{
							ValidateRowValues(values, rowIndex);
							if (valueErrorFlag)
							{
								throw new ArgumentException();
							}
						}

						// Добавление валидной строки в список
						allCharacteristics.Add(values);

						rowIndex++;
					}
				}
				onParseFailed?.Invoke(Success);
			}
			catch (ArgumentException)
			{
				onParseFailed?.Invoke(ValueError);
			}
			catch (FormatException)
			{
				onParseFailed?.Invoke(SeparationError);
			}
			catch(IOException)
			{
				onParseFailed?.Invoke(FileError);
			}
			catch (Exception)
			{
				onParseFailed?.Invoke(UndefinedError);
			}
			return allCharacteristics;
		}

		/// <summary>
		/// Валидирует переданную строку из таблицы
		/// </summary>
		/// <param name="values"></param>
		/// <param name="rowIndex"></param>
		private static void ValidateRowValues(string[] values, int rowIndex)
		{
			
			for(int i = 0; i < values.Length; i++)
			{
				string message = DotaValidator.Validate(values[i], i);
				
				if (message != null)
				{
					Console.WriteLine(message);
					valueErrorFlag = true;
					return;
				}
			}
		}

	}
}
