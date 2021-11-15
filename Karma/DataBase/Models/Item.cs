using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend;

namespace DataBase.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactInfo { get; set; }
        public string Category { get; set; }
        //public Location Location { get; set; }
        public DateTime Date { get; set; }

        public User Poster;

        public Item()
        {

        }
    }
}
