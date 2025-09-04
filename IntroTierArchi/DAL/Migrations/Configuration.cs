namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.UMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.UMSContext context)
        {
            //for (int i = 0; i < 10; i++) {
            //    context.Students.Add(new EF.Tables.Student()
            //    {
            //        Name = Guid.NewGuid().ToString().Substring(0, 10),
            //        Address = Guid.NewGuid().ToString().Substring(0, 20),
            //    }); ;
            //}
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
