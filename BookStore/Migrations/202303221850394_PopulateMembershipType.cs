﻿namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonths,DiscountRate)" +
                "VALUES (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonths,DiscountRate)" +
                "VALUES (2,35,1,10)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonths,DiscountRate)" +
                "VALUES (3,90,3,15)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonths,DiscountRate)" +
                "VALUES (4,250,12,30)");
        }
        
        public override void Down()
        {
        }
    }
}
