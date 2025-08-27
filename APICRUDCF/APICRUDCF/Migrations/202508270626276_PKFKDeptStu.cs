namespace APICRUDCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PKFKDeptStu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "DeptId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "DeptId");
            AddForeignKey("dbo.Students", "DeptId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DeptId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DeptId" });
            DropColumn("dbo.Students", "DeptId");
        }
    }
}
