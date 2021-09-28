using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma
{
    public class CSVProcessing
    {
        public static Item[] Items;
        public static void AppendToCSV(string text)
        {
            File.AppendAllText("items.csv", text + "\n");
        }
        public static DataTable DataTableFromCSV()
        {
            DataTable result;
            string[] LineArray = File.ReadAllLines("items.csv");
            result = FromDataTable(LineArray);
            return result;
        }
        
        private static DataTable FromDataTable(string[] LineArray)
        {
            DataTable dt = new DataTable();
            AddColumnToTable(LineArray, ref dt);
            AddRowToTable(LineArray, ref dt);
            return dt;
        }
        private static void AddColumnToTable(string[] columnCollection, ref DataTable dt)
        {
            string[] columns = columnCollection[0].Split(',');
            foreach(string columnName in columns)
            {
                DataColumn dc = new DataColumn(columnName, typeof(string));
                dt.Columns.Add(dc);
            }
        }
        private static void AddRowToTable(string[] valueCollection, ref DataTable dt)
        {
            for(int i = 1; i < valueCollection.Length; i++)
            {
                string[] values = valueCollection[i].Split(',');

                //Items[i - 1] = new Item(values);
             

                DataRow dr = dt.NewRow();

                for(int j = 0; j < values.Length; j++)
                {
                    dr[j] = values[j];
                }

                dt.Rows.Add(dr);
            }
        }
    }

   

}
