namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvailableAmountAddedToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "AvailableAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "AvailableAmount");
        }
    }
}
