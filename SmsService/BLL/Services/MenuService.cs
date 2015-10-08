using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Entities;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using DAL.Repositories;

namespace BLL
{
    public class MenuService:IMenuService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        public List<MenuCategoryDTO> GetMenuCategories()
        {
            var menuCategories = _unitOfWork.MenuCategoryRepository.GetAll();
            Mapper.CreateMap<MenuCategory, MenuCategoryDTO>();
            var categories = Mapper.Map<IEnumerable<MenuCategory>, IEnumerable<MenuCategoryDTO>>(menuCategories);

            return categories.OrderBy(c => c.Name).ToList();
        }

        public List<CategoryItemDTO> GetCategoryItems()
        {
            var categoryItems = _unitOfWork.CategoryItemRepository.GetAll();
            Mapper.CreateMap<CategoryItem, CategoryItemDTO>();
            var items = Mapper.Map<IEnumerable<CategoryItem>, IEnumerable<CategoryItemDTO>>(categoryItems);

            return items.OrderBy(i => i.Name).ToList();
        }

        public void CreateMenuCategory(MenuCategoryDTO category)
        {
            Mapper.CreateMap<MenuCategoryDTO, MenuCategory>();
            var cat = Mapper.Map<MenuCategoryDTO, MenuCategory>(category);
            _unitOfWork.MenuCategoryRepository.Create(cat);
            _unitOfWork.Save();
        }

        public void CreateCategoryItem(CategoryItemDTO item)
        {
            Mapper.CreateMap<CategoryItemDTO, CategoryItem>();
            var it = Mapper.Map<CategoryItemDTO, CategoryItem>(item);
            _unitOfWork.CategoryItemRepository.Create(it);
            _unitOfWork.Save();
        }
    }
}
