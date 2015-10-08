using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class CategoryItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public int MenuCategoryId { get; set; }
        public int Sequence { get; set; }
    }
}
