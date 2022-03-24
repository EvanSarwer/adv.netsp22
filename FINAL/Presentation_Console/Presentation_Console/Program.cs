using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stu = StudentService.Get(2);
            Console.WriteLine("Student Name: " + stu.Name);
            Console.WriteLine("Student Dept_ID: " + stu.Dept_Id);
        }
    }
}
