using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class MenuCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual ICollection<CategoryItem> CategoryItems { get; set; }

        public MenuCategory()
        {
            CategoryItems = new List<CategoryItem>();
        }
    }
}
