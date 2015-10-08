using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.Menu
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<CategoryItemViewModel> CategoryItems{get; set; }

        public CategoryViewModel()
        {
            CategoryItems = new List<CategoryItemViewModel>();
        }

    }
}