﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int ManagerId { get; set; }
        //public Employee Employee { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
