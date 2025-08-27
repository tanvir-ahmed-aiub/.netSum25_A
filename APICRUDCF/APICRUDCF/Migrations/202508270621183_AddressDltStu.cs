namespace APICRUDCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressDltStu : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Address", c => c.String(nullable: false, maxLength: 200, unicode: false));
        }
    }
}
