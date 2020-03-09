using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DotaLibrary.DotaFilesPaths;

namespace Dota2
{
	internal static class DataGridViewExtension
	{
		public static void SaveTableToCSV(this DataGridView dataGridView)
		{
			try
			{
				DataTable table = dataGridView.DataSource as DataTable;
				StringBuilder strData = new StringBuilder();
				string separator = ";";

				for(int i = 0; i < table.Columns.Count; i++)
				{
					if(i != table.Columns.Count - 1)
					{
						strData.Append(table.Columns[i].ToString()).Append(separator);
					}
					else
					{
						strData.Append(table.Columns[i].ToString());
					}
				}
				strData.Append(Environment.NewLine);

				for(int i = 0; i < table.Rows.Count; i++)
				{
					for(int j = 0; j < table.Rows[i].ItemArray.Length; j++)
					{
						if(j != table.Rows[i].ItemArray.Length - 1)
						{
							strData.Append(table.Rows[i].ItemArray[j].ToString()).Append(separator);
						}
						else
						{
							strData.Append(table.Rows[i].ItemArray[j].ToString());
						}
					}
					strData.Append(Environment.NewLine);
				}

				File.WriteAllText(DotaSavedTablePath, strData.ToString());

			}
			catch(IOException e)
			{
				MessageBox.Show($"Ошибка при записи файла: {e.Message}");
			}
			catch (Exception e)
			{
				MessageBox.Show($"Ошибка при работе с файлом: {e.Message}");
			}
		}
	}
}
