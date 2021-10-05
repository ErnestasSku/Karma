using System;

namespace Karma
{
    public class Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public string contactInfo { get; set; }

        public Item(string[] itemInfo)
        {
            try
            {
                this.name = itemInfo[0];
                this.description = itemInfo[1];
                this.contactInfo = itemInfo[2];
            }
            catch (Exception)
            {

            }
            
        }
    }

}
