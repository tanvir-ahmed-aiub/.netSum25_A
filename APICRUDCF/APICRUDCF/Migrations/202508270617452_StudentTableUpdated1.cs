namespace APICRUDCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentTableUpdated1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Cgpa", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Cgpa", c => c.Single());
        }
    }
}
