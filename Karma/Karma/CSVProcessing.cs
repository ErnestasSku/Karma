using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Karma
{
    public class CSVProcessing
    {

        public static List<Item> Items;
        public static void AppendToCSV(string text)
        {
            File.AppendAllText("items.csv", text + "\n");

            //Temporary, this should not be called, since it will be created during LoadItems()
            if (Items == null) Items = new List<Item>();
            Items.Add(new Item(text.Split(',')));
        }

        public static void LoadItems()
        {
            Items = new List<Item>();
            var fileText = File.ReadAllText("items.csv").Split('\n');
           
            foreach (var data in fileText)
            {
                Items.Add(new Item(data.Split(',')));
            }

        }
    }



}
