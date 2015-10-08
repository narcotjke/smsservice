using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IMenuService
    {
        void CreateMenuCategory(MenuCategoryDTO category);
        void CreateCategoryItem(CategoryItemDTO item);
        List<MenuCategoryDTO> GetMenuCategories();
        List<CategoryItemDTO> GetCategoryItems();
    }
}
