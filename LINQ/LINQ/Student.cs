using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Cgpa { get; set; }

        public void show()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Cgpa: " + Cgpa);
        }
    }
}
