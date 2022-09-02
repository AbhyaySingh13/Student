namespace Student.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedListing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listings", "OwnerName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Listings", "NumOwner", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Listings", "StudentName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Listings", "AppointmentDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Listings", "Description", c => c.String(nullable: false));
            DropTable("dbo.Appointments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StudentName = c.String(nullable: false, maxLength: 30),
                        PropertyId = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 30),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Listings", "Description", c => c.String(nullable: false, maxLength: 300));
            DropColumn("dbo.Listings", "AppointmentDateTime");
            DropColumn("dbo.Listings", "StudentName");
            DropColumn("dbo.Listings", "NumOwner");
            DropColumn("dbo.Listings", "OwnerName");
        }
    }
}
