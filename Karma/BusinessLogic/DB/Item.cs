using System;
using System.Linq;
using Backend;

namespace Backend
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
        public Location Location { get; set; }
        public DateTime Date { get; set; }

        public User OriginalPoster;

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
        //TODO: clear
        //public enum Locations
        //{
        //    Vilnius,
        //    Kaunas,
        //    Klaipėda,
        //    Šiauliai,
        //    Panevėžys,
        //    Alytus,
        //    Marijampolė,
        //    Mažeikiai
        //}

        public Item()
        {

        }

        public Item(string[] itemInfo)
        {
            try
            {
                Name = itemInfo[0];
                Description = itemInfo[1];
                ContactInfo = itemInfo[2];
                Category = itemInfo[3];
                Location = new Location(City: itemInfo[4], Country: "Lithuania");
                Date = DateTime.Parse(itemInfo[5]);

                
            }
            catch (Exception)
            {

            } 
        }

        public Item(string Name, string Description, string ContactInfo, string Category, string Country, string City, DateTime Date)
        {
            this.Name = Name;
            this.Description = Description;
            this.ContactInfo = ContactInfo;
            this.Category = Category;
            Location = new Location(Country: Country, City: City);
            this.Date = Date;

            //OriginalPoster = LocalData.CurentUserData.currentUser;
        }

        public int CompareTo(object obj)
        {
            return Date.CompareTo(obj);
        }
        
        /*public static void GetRecomendedMeetingLocations()
        {
            var querry = from t in ItemData.GetData().ItemList
                         join r in TemporaryData.RecomendedLocations
                         on t.Location.City equals r.City
                        
                         select new {t, r};
        }*/
    }
}
