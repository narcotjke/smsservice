using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL;
using BLL.Entities;

namespace UI.Models.Menu
{
    public class CategoryItemViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; } 

        [Required]
        public string Name { get; set; }

        [Required]
        public string ActionName { get; set; }

        [Required]
        public string ControllerName { get; set; }

        [Required]
        public int Sequence { get; set; }

        public CategoryItemViewModel()
        {
            SetCategories();
        }

        public void SetCategories()
        {
            var _menuService = new MenuService();
            var categories = _menuService.GetMenuCategories();
            Mapper.CreateMap<MenuCategoryDTO, CategoryViewModel>()
                .ForMember(x => x.Id, m => m.MapFrom(s => s.Id))
                .ForMember(x => x.Name, m => m.MapFrom(s => s.Name));
            Categories = Mapper.Map<IEnumerable<MenuCategoryDTO>, IEnumerable<CategoryViewModel>>(categories).ToList();
        }
    }
}