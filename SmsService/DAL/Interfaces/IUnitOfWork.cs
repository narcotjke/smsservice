using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public interface IUnitOfWork:IDisposable
    {
        GenericRepository<Delivery> DeliveryRepository { get; }
        GenericRepository<SubscribersBase> SubscriberBaseRepository { get; }
        GenericRepository<CategoryItem> CategoryItemRepository { get; }
        GenericRepository<MenuCategory> MenuCategoryRepository { get; }
        void Save();
    }
}
