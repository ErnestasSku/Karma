using System;

namespace BusinessLogic
{
    /// <summary>
    /// 
    /// </summary>
    /// We can add IComparable here
    /// Another exta fields which can be added are Date, FUTURE: we should add a List 
    /// for images (or maybe just path (string/URI) to images, and we can load them later)
    /// 
    public class Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public string contactInfo { get; set; }

        public string category { get; set; }

        public enum SortType
        {
            Date,
            Name
        }

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
