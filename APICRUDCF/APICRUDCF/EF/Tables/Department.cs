using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICRUDCF.EF.Tables
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}