namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ActionName = c.String(),
                        ControllerName = c.String(),
                        MenuCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuCategories", t => t.MenuCategoryId, cascadeDelete: true)
                .Index(t => t.MenuCategoryId);
            
            CreateTable(
                "dbo.MenuCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ServiceId = c.Int(nullable: false),
                        MessageText = c.String(),
                        DeliveryRate = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        SmsServiceUserId = c.Guid(nullable: false),
                        SmsServiceUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SmsServiceUser_Id)
                .Index(t => t.SmsServiceUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SubscribersBases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FilePath = c.String(),
                        SubscribersNumber = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        SmsServiceUserId = c.Guid(nullable: false),
                        SmsServiceUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SmsServiceUser_Id)
                .Index(t => t.SmsServiceUser_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.SubscribersBaseDeliveries",
                c => new
                    {
                        SubscribersBase_Id = c.Int(nullable: false),
                        Delivery_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubscribersBase_Id, t.Delivery_Id })
                .ForeignKey("dbo.SubscribersBases", t => t.SubscribersBase_Id, cascadeDelete: true)
                .ForeignKey("dbo.Deliveries", t => t.Delivery_Id, cascadeDelete: true)
                .Index(t => t.SubscribersBase_Id)
                .Index(t => t.Delivery_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SubscribersBases", "SmsServiceUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubscribersBaseDeliveries", "Delivery_Id", "dbo.Deliveries");
            DropForeignKey("dbo.SubscribersBaseDeliveries", "SubscribersBase_Id", "dbo.SubscribersBases");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Deliveries", "SmsServiceUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CategoryItems", "MenuCategoryId", "dbo.MenuCategories");
            DropIndex("dbo.SubscribersBaseDeliveries", new[] { "Delivery_Id" });
            DropIndex("dbo.SubscribersBaseDeliveries", new[] { "SubscribersBase_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SubscribersBases", new[] { "SmsServiceUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Deliveries", new[] { "SmsServiceUser_Id" });
            DropIndex("dbo.CategoryItems", new[] { "MenuCategoryId" });
            DropTable("dbo.SubscribersBaseDeliveries");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SubscribersBases");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Deliveries");
            DropTable("dbo.MenuCategories");
            DropTable("dbo.CategoryItems");
        }
    }
}
