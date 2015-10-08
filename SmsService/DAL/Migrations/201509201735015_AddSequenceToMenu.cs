namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSequenceToMenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategoryItems", "Sequence", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CategoryItems", "Sequence");
        }
    }
}
