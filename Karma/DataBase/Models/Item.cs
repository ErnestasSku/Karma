using System;
using Backend;

namespace DataBase.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactInfo { get; set; }
        public string Category { get; set; }
        public Location Location { get; set; }
        public DateTime Date { get; set; }

        public User Poster;
    }
}
