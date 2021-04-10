namespace UniversitySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        Materials = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Homework",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 1000),
                        TimeSent = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        Number = c.String(nullable: false, maxLength: 6),
                        Gender = c.Int(nullable: false),
                        MentorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.MentorId)
                .Index(t => t.Name, unique: true)
                .Index(t => t.Number, unique: true)
                .Index(t => t.MentorId);
            
            CreateTable(
                "dbo.StudentsInCoursesManyToManyAlternatives",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Course_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Course_Id);
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.StudentsInCoursesManyToManyAlternatives", "StudentId", "dbo.Students");
            this.DropForeignKey("dbo.StudentsInCoursesManyToManyAlternatives", "CourseId", "dbo.Courses");
            this.DropForeignKey("dbo.Students", "MentorId", "dbo.Students");
            this.DropForeignKey("dbo.Homework", "StudentId", "dbo.Students");
            this.DropForeignKey("dbo.StudentCourses", "Course_Id", "dbo.Courses");
            this.DropForeignKey("dbo.StudentCourses", "Student_Id", "dbo.Students");
            this.DropForeignKey("dbo.Homework", "CourseId", "dbo.Courses");
            this.DropIndex("dbo.StudentCourses", new[] { "Course_Id" });
            this.DropIndex("dbo.StudentCourses", new[] { "Student_Id" });
            this.DropIndex("dbo.StudentsInCoursesManyToManyAlternatives", new[] { "CourseId" });
            this.DropIndex("dbo.StudentsInCoursesManyToManyAlternatives", new[] { "StudentId" });
            this.DropIndex("dbo.Students", new[] { "MentorId" });
            this.DropIndex("dbo.Students", new[] { "Number" });
            this.DropIndex("dbo.Students", new[] { "Name" });
            this.DropIndex("dbo.Homework", new[] { "CourseId" });
            this.DropIndex("dbo.Homework", new[] { "StudentId" });
            this.DropIndex("dbo.Courses", new[] { "Name" });
            this.DropTable("dbo.StudentCourses");
            this.DropTable("dbo.StudentsInCoursesManyToManyAlternatives");
            this.DropTable("dbo.Students");
            this.DropTable("dbo.Homework");
            this.DropTable("dbo.Courses");
        }
    }
}
