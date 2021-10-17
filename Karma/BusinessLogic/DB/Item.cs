using System;

namespace BusinessLogic
{
    /// <summary>
    /// Item template.
    /// </summary>
    public class Item : IComparable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactInfo { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }

        public enum SortType
        {
            Date,
            Name
        }
        
        public enum Categories
        {
            Appliances,
            Furniture,
            Electronics,
            Clothing,
            KidStuff
        }
        public enum Locations
        {
            Vilnius,
            Kaunas,
            Klaipėda,
            Šiauliai,
            Panevėžys,
            Alytus,
            Marijampolė,
            Mažeikiai
        }

        public Item()
        {

        }

        public Item(string[] itemInfo)
        {
            try
            {
                this.Name = itemInfo[0];
                this.Description = itemInfo[1];
                this.ContactInfo = itemInfo[2];
                this.Category = itemInfo[3];
                this.Location = itemInfo[4];
                this.Date = DateTime.Parse(itemInfo[5]);
                
            }
            catch (Exception)
            {

            } 
        }
        public int CompareTo(object obj)
        {
            return Date.CompareTo(obj);
        }               
    }
}
