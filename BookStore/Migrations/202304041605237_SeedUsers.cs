namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ab0d937b-212c-4fe9-92c0-d1c153709603', N'guest@bookstore.com', 0, N'AAi6U+LwGO14S33vd+hG8QToMzKzcfjRW2S44wmM9yqNVxfaDU25rTGWPwcrt7H0BA==', N'db6d3fc3-f0ee-4577-8705-ead4e2ad3ce8', NULL, 0, 0, NULL, 1, 0, N'guest@bookstore.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e49556aa-e799-4055-9865-d7c7aaf11af9', N'admin@bookstore.com', 0, N'AAmpvmKXnzksPmfsovcCkDLxR6A3W+G8oNkRxHDCwuY5qmrnQw2iUs7HfI0rn5u5gA==', N'3546334e-a3c9-4e66-bdeb-0b8c1eeb04ff', NULL, 0, 0, NULL, 1, 0, N'admin@bookstore.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1581f5c8-737d-4a29-826e-146de20c5209', N'CanManageBooks')
");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e49556aa-e799-4055-9865-d7c7aaf11af9', N'1581f5c8-737d-4a29-826e-146de20c5209')");//CanManageBooks
        }
        
        public override void Down()
        {
        }
    }
}
