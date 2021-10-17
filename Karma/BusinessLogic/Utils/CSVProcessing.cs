using System.Collections.Generic;
using System.IO;

namespace BusinessLogic
{
    public class CSVProcessing
    {

        public static List<Item> Items;
        public static void AppendToCSV(string text)
        {
            var csvFileLength = new System.IO.FileInfo("items.csv").Length;
            if (csvFileLength != 0)
                File.AppendAllText("items.csv", "\n");

            File.AppendAllText("items.csv", text);

            //Temporary, this should not be called, since it will be created during LoadItems()
            if (Items == null) Items = new List<Item>();
            var newItem = new Item(text.Split(','));
            Items.Add(newItem);
            
        }

        public static void LoadItems()
        {

            Items = new List<Item>();
            var csvFileLength = new System.IO.FileInfo("items.csv").Length;
            if (csvFileLength != 0)
            {
                var fileText = File.ReadAllText("items.csv").Split('\n');

                foreach (var data in fileText)
                {
                    Items.Add(new Item(data.Split(',')));
                }
            }

        }
    }



}
