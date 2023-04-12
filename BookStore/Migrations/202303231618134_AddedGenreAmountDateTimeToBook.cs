namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenreAmountDateTimeToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Genre", c => c.String());
            AddColumn("dbo.Books", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "AddedToDb", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "AddedToDb");
            DropColumn("dbo.Books", "ReleaseDate");
            DropColumn("dbo.Books", "Amount");
            DropColumn("dbo.Books", "Genre");
        }
    }
}
