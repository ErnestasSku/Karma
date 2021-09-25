using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma
{
    public class CSVProcessing
    {
        public void AppendToCSV(string text)
        {
            File.AppendAllText("items.csv", text + "\n");
        }
    }

   

}
