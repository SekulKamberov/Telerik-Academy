namespace Example.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsMale = c.Boolean(nullable: false),
                        MotherId = c.Int(),
                        FatherId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.FatherId)
                .ForeignKey("dbo.People", t => t.MotherId)
                .Index(t => t.MotherId)
                .Index(t => t.FatherId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);

            CreateTable(
                "dbo.Kids",
                c => new
                {
                    ParentId = c.Int(nullable: false),
                    ChildId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.ParentId, t.ChildId })
                .ForeignKey("dbo.People", t => t.ChildId, cascadeDelete: false)
                .ForeignKey("dbo.People", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId)
                .Index(t => t.ChildId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kids", "ParentId", "dbo.People");
            DropForeignKey("dbo.Kids", "ChildId", "dbo.People");
            DropForeignKey("dbo.Stores", "OwnerId", "dbo.People");
            DropForeignKey("dbo.People", "MotherId", "dbo.People");
            DropForeignKey("dbo.People", "FatherId", "dbo.People");
            DropIndex("dbo.Stores", new[] { "OwnerId" });
            DropIndex("dbo.People", new[] { "FatherId" });
            DropIndex("dbo.People", new[] { "MotherId" });
            DropIndex("dbo.Kids", new[] { "ChildId" });
            DropIndex("dbo.Kids", new[] { "ParentId" });
            DropTable("dbo.Stores");
            DropTable("dbo.People");
            DropTable("dbo.Kids");
        }
    }
}
