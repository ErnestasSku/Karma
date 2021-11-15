using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileUI.Models
{
    public class Item
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string ImgSource { get; set; }

        public string Description { get; set; }

        public static ObservableRangeCollection<Item> Items { get; set; }

        public static void AddData(ObservableRangeCollection<Item> Items)
        {
            Items.Add(new Item
            {
                Name = "Table",
                Location = "Vilnius",
                ImgSource = "https://images.pexels.com/photos/279626/pexels-photo-279626.jpeg",
                Description = "This is an item description"
            }) ;

            Items.Add(new Item
            {
                Name = "Chair",
                Location = "Kaunas",
                ImgSource = "https://images.pexels.com/photos/2258083/pexels-photo-2258083.jpeg",
                Description = "This is an item description"
            });
            Items.Add(new Item
            {
                Name = "Lamp",
                Location = "Vievis",
                ImgSource = "https://images.pexels.com/photos/1112598/pexels-photo-1112598.jpeg",
                Description = "This is an item description"
            });
            Items.Add(new Item
            {
                Name = "Lamp",
                Location = "Vievis",
                ImgSource = "https://images.pexels.com/photos/1112598/pexels-photo-1112598.jpeg",
                Description = "This is an item description"
            });
            Items.Add(new Item
            {
                Name = "Lamp",
                Location = "Vievis",
                ImgSource = "https://images.pexels.com/photos/1112598/pexels-photo-1112598.jpeg",
                Description = "This is an item description"
            });
            Items.Add(new Item
            {
                Name = "Lamp",
                Location = "Vievis",
                ImgSource = "https://images.pexels.com/photos/1112598/pexels-photo-1112598.jpeg",
                Description = "This is an item description"
            });
            Items.Add(new Item
            {
                Name = "Lamp",
                Location = "Vievis",
                ImgSource = "https://images.pexels.com/photos/1112598/pexels-photo-1112598.jpeg",
                Description = "This is an item description"
            });
        }
    }
}
