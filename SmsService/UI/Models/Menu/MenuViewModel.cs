using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL;
using BLL.Entities;

namespace UI.Models.Menu
{
    public class MenuViewModel
    {
        public MenuService MenuService = new MenuService();
        public List<CategoryViewModel> Categories { get; set; }

        public MenuViewModel()
        {
            SetMenu();
        }

        public void SetMenu()
        {
            var _categories = MenuService.GetMenuCategories();
            var _items = MenuService.GetCategoryItems();

            Mapper.CreateMap<MenuCategoryDTO, CategoryViewModel>();
            var categories = Mapper.Map<IEnumerable<MenuCategoryDTO>, IEnumerable<CategoryViewModel>>(_categories).ToList();

            Mapper.CreateMap<CategoryItemDTO, CategoryItemViewModel>()
                .ForMember(x => x.CategoryId, m => m.MapFrom(x => x.MenuCategoryId));
            var menuItems = Mapper.Map<IEnumerable<CategoryItemDTO>, IEnumerable<CategoryItemViewModel>>(_items).OrderBy(m => m.Sequence).ToList();

            Categories = categories;
            foreach (var m in menuItems)
            {
                var categoryIndex = Categories.FindIndex(c => c.Id == m.CategoryId);
                m.Categories = null;
                Categories[categoryIndex].CategoryItems.Add(m);
            }
        }
    }
}