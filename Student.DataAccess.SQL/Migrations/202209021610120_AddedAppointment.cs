namespace Student.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAppointment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ListingId = c.String(),
                        StudentName = c.String(nullable: false, maxLength: 50),
                        AppointmentDate = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Listings", "OwnerEmail", c => c.String(nullable: false));
            DropColumn("dbo.Listings", "StudentName");
            DropColumn("dbo.Listings", "AppointmentDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Listings", "AppointmentDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Listings", "StudentName", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Listings", "OwnerEmail");
            DropTable("dbo.Appointments");
        }
    }
}
