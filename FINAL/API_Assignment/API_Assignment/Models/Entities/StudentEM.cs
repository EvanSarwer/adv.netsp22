﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Assignment.Models.Entities
{
    public class StudentEM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Dept_Id { get; set; }
        public string Dept_Name { get; set; }
    }
}