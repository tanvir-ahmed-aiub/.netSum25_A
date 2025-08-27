namespace APICRUDCF.Migrations
{
    using APICRUDCF.EF.Tables;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<APICRUDCF.EF.UMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(APICRUDCF.EF.UMSContext context)
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++) {
                var s = new Student() {
                    Name = Guid.NewGuid().ToString().Substring(0, 11),
                    DeptId = random.Next(1, 7),
                    Cgpa = 0.0f

                };
                context.Students.Add(s);
            }
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
