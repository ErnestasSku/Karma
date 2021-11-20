using MobileUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileUI.ViewModels
{
    public class AddItemViewModel
    {
        public List<Category> Categories { get; set; } 

        public AddItemViewModel()
        {
            Categories = GetCategories();
        }
        public List<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category(){Key = 1, Value = "Furniture"},
                new Category(){Key = 2, Value = "Electronics"},
                new Category(){Key = 3, Value = "Kids"},
                new Category(){Key = 4, Value = "Kitchen"},
            };
            return categories;
        }
    }
}
