namespace UniversitySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriorCourse : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Courses", "PriorCourseId", c => c.Int());
            this.CreateIndex("dbo.Courses", "PriorCourseId");
            this.AddForeignKey("dbo.Courses", "PriorCourseId", "dbo.Courses", "Id");
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Courses", "PriorCourseId", "dbo.Courses");
            this.DropIndex("dbo.Courses", new[] { "PriorCourseId" });
            this.DropColumn("dbo.Courses", "PriorCourseId");
        }
    }
}
