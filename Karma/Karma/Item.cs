using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma
{
    public class Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public string contactInfo { get; set; }

        public Item(string[] itemInfo)
        {
            this.name = itemInfo[0];
            this.description = itemInfo[1];
            this.contactInfo = itemInfo[2];
        }
    }
    
}
