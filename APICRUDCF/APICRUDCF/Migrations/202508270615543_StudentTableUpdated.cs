namespace APICRUDCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentTableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Cgpa", c => c.Single());
            AddColumn("dbo.Students", "Address", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Students", "Address");
            DropColumn("dbo.Students", "Cgpa");
        }
    }
}
