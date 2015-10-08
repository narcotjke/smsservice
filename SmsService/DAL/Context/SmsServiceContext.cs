using System;
using System.Data.Entity;
using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL
{
    public class SmsServiceContext : IdentityDbContext<SmsServiceUser>
    {
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<SubscribersBase> SubscribersBases { get; set; }
        public DbSet<CategoryItem> CategoryItems { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Balance> Balances { get; set; }

        public SmsServiceContext()
            : base("SmsService")
        {
        }

        public static SmsServiceContext Create()
        {
            return new SmsServiceContext();
        }
    }
}
