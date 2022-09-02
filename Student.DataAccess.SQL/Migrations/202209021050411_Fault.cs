namespace Student.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fault : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FaultLogs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        ResidentialAddress = c.String(maxLength: 500),
                        CellNumber = c.String(maxLength: 10),
                        Technician = c.String(),
                        FaultType = c.String(),
                        Description = c.String(),
                        Urgency = c.String(),
                        Status = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Technicians",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TechnicianName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        CellNumber = c.String(nullable: false, maxLength: 10),
                        Company = c.String(),
                        CalloutFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Technicians");
            DropTable("dbo.FaultLogs");
        }
    }
}
