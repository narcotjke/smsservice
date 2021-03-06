namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbalance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SmsServiceUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SmsServiceUser_Id)
                .Index(t => t.SmsServiceUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Balances", "SmsServiceUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Balances", new[] { "SmsServiceUser_Id" });
            DropTable("dbo.Balances");
        }
    }
}
