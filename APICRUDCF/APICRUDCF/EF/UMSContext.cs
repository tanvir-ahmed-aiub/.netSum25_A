using APICRUDCF.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APICRUDCF.EF
{
    public class UMSContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}