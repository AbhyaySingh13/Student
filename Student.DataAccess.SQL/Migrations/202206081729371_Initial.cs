namespace Student.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        JobId = c.String(),
                        Business = c.String(),
                        JobPosition = c.String(),
                        StudentName = c.String(),
                        University = c.String(),
                        Qualification = c.String(),
                        Email = c.String(),
                        Cell = c.String(),
                        CV = c.String(),
                        Image = c.String(),
                        Status = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BasketId = c.String(maxLength: 128),
                        DeviceId = c.String(),
                        DeviceName = c.String(),
                        Price = c.String(),
                        Quantity = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskets", t => t.BasketId)
                .Index(t => t.BasketId);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                        Street = c.String(nullable: false, maxLength: 30),
                        City = c.String(nullable: false, maxLength: 10),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        Memory = c.String(nullable: false, maxLength: 30),
                        OperatingSystem = c.String(nullable: false, maxLength: 30),
                        ProcessorType = c.String(nullable: false, maxLength: 20),
                        HardDrive = c.String(nullable: false, maxLength: 30),
                        GraphicsCard = c.String(nullable: false, maxLength: 30),
                        VirusProtect = c.Boolean(nullable: false),
                        YearsOfWarranty = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DriverName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        University = c.Int(nullable: false),
                        Availability = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false),
                        JobPosition = c.String(nullable: false, maxLength: 30),
                        SalaryOffered = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BusinessName = c.String(nullable: false, maxLength: 30),
                        Image = c.String(),
                        Experience = c.String(nullable: false, maxLength: 30),
                        University = c.String(nullable: false, maxLength: 30),
                        Vaccinated = c.Boolean(nullable: false),
                        ShiftTimes = c.String(nullable: false, maxLength: 20),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Area = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        Description = c.String(nullable: false, maxLength: 300),
                        NumBedrooms = c.Int(nullable: false),
                        NumBathrooms = c.Int(nullable: false),
                        NumGarages = c.Int(nullable: false),
                        University = c.String(nullable: false, maxLength: 30),
                        Alarm = c.Boolean(nullable: false),
                        Fencing = c.Boolean(nullable: false),
                        Wifi = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OrderId = c.String(maxLength: 128),
                        DeviceId = c.String(),
                        DeviceName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        Quantity = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        OrderStatus = c.String(),
                        DeliveryMethod = c.String(),
                        BasketTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinalTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        University = c.Int(nullable: false),
                        Driver = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                        CellNumber = c.String(nullable: false, maxLength: 20),
                        University = c.String(nullable: false, maxLength: 30),
                        Faculty = c.String(nullable: false, maxLength: 50),
                        Qualification = c.String(nullable: false, maxLength: 50),
                        Vaccinated = c.Boolean(nullable: false),
                        NumYears = c.Int(nullable: false),
                        Bursary = c.Boolean(nullable: false),
                        EmergencyFirstName = c.String(nullable: false, maxLength: 30),
                        Relation = c.String(nullable: false, maxLength: 30),
                        EmergencyCellNum = c.String(nullable: false, maxLength: 20),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets");
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.BasketItems", new[] { "BasketId" });
            DropTable("dbo.Students");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Listings");
            DropTable("dbo.Jobs");
            DropTable("dbo.Drivers");
            DropTable("dbo.Devices");
            DropTable("dbo.Customers");
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
            DropTable("dbo.Appointments");
            DropTable("dbo.Applications");
        }
    }
}
