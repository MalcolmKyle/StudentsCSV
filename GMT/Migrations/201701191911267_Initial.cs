namespace GMT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        School = c.String(),
                        Sex = c.String(),
                        Age = c.Int(nullable: false),
                        Address = c.String(),
                        FamSize = c.String(),
                        Pstatus = c.String(),
                        MEdu = c.Int(nullable: false),
                        FEdu = c.Int(nullable: false),
                        Reason = c.String(),
                        Guardian = c.String(),
                        TravelTime = c.Int(nullable: false),
                        StudyTime = c.Int(nullable: false),
                        Failures = c.Int(nullable: false),
                        SchoolSupport = c.String(),
                        FamSupport = c.String(),
                        Paid = c.String(),
                        Activities = c.String(),
                        Nursery = c.String(),
                        Higher = c.String(),
                        Internet = c.String(),
                        Romantic = c.String(),
                        FamilyRel = c.Int(nullable: false),
                        FreeTime = c.Int(nullable: false),
                        GoOut = c.Int(nullable: false),
                        DailyAlc = c.Int(nullable: false),
                        WeekAlc = c.Int(nullable: false),
                        Health = c.Int(nullable: false),
                        Absences = c.Int(nullable: false),
                        G1 = c.Int(nullable: false),
                        G2 = c.Int(nullable: false),
                        G3 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
