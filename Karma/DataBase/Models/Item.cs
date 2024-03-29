﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models;

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

        public string City { get; set; }

        //public Location Location { get; set; }
        public DateTime Date { get; set; }

        public string Image { get; set; }

        public int PosterId { get; set; }

        public User Poster { get; set; }

        public IList<UserTakenItem> UserTakenItems { get; set; }

        public Item()
        {

        }
    }
}
