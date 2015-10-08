using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly SmsServiceContext _context = new SmsServiceContext();
        private GenericRepository<Delivery> _delivery;
        private GenericRepository<SubscribersBase> _subscribersBase;
        private GenericRepository<CategoryItem> _categoryItem;
        private GenericRepository<MenuCategory> _menuCategory; 

        public GenericRepository<Delivery> DeliveryRepository
        {
            get { return _delivery ?? new GenericRepository<Delivery>(_context); }
        }

        public GenericRepository<SubscribersBase> SubscriberBaseRepository
        {
            get { return _subscribersBase ?? new GenericRepository<SubscribersBase>(_context); }
        }

        public GenericRepository<CategoryItem> CategoryItemRepository
        {
            get { return _categoryItem ?? new GenericRepository<CategoryItem>(_context); }
        }

        public GenericRepository<MenuCategory> MenuCategoryRepository
        {
            get { return _menuCategory ?? new GenericRepository<MenuCategory>(_context); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(Boolean disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
