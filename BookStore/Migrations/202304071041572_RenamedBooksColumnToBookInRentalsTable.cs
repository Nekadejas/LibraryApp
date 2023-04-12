namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedBooksColumnToBookInRentalsTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rentals", name: "Books_Id", newName: "Book_Id");
            RenameIndex(table: "dbo.Rentals", name: "IX_Books_Id", newName: "IX_Book_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Rentals", name: "IX_Book_Id", newName: "IX_Books_Id");
            RenameColumn(table: "dbo.Rentals", name: "Book_Id", newName: "Books_Id");
        }
    }
}
