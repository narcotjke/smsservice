using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using BLL.Entities;
using UI.Models.Menu;
using BLL.Interfaces;

namespace UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class Menu2Controller : Controller
    {
        private readonly IMenuService _menuService = new MenuService();

        public ActionResult MenuCategoryList()
        {
            var categories = _menuService.GetMenuCategories();
            Mapper.CreateMap<MenuCategoryDTO, CategoryViewModel>();
            var categoriesVM = Mapper.Map<IEnumerable<MenuCategoryDTO>, IEnumerable<CategoryViewModel>>(categories);

            return View(categoriesVM);
        }

        public ActionResult CategoryItemList()
        {
            var itemList = _menuService.GetCategoryItems();
            Mapper.CreateMap<CategoryItemDTO, CategoryItemViewModel>()
                .ForMember(x => x.CategoryId, m => m.MapFrom(s => s.MenuCategoryId))
                .ForMember(x => x.Name, m => m.MapFrom(s => s.Name));
            var items = Mapper.Map<IEnumerable<CategoryItemDTO>, IEnumerable<CategoryItemViewModel>>(itemList);

            return View(items);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            Mapper.CreateMap<CategoryViewModel, MenuCategoryDTO>();
            var cat = Mapper.Map<CategoryViewModel, MenuCategoryDTO>(category);
            _menuService.CreateMenuCategory(cat);

            return RedirectToAction("MenuCategoryList");
        }

        [HttpGet]
        public ActionResult CreateCategoryItem()
        {
            var item = new CategoryItemViewModel();

            return View(item);
        }

        [HttpPost]
        public ActionResult CreateCategoryItem(CategoryItemViewModel categoryItem)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryItem);
            }

            Mapper.CreateMap<CategoryItemViewModel, CategoryItemDTO>()
                .ForMember(x => x.MenuCategoryId, m => m.MapFrom(s => s.CategoryId))
                .ForMember(x => x.ActionName, m => m.MapFrom(s => s.ActionName))
                .ForMember(x => x.ControllerName, m => m.MapFrom(s => s.ControllerName))
                .ForMember(x => x.Name, m => m.MapFrom(s => s.Name));
            var item = Mapper.Map<CategoryItemViewModel, CategoryItemDTO>(categoryItem);
            _menuService.CreateCategoryItem(item);

            return RedirectToAction("CategoryItemList");
        }
	}
}