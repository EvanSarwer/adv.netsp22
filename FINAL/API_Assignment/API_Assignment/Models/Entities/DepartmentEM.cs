using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Assignment.Models.Entities
{
    public class DepartmentEM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentEM> Students { get; set; }
    }
}