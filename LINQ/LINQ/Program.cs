using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Program
    {
        static void Print(dynamic students)
        {
            foreach(var s in students)
            {
                Console.WriteLine("Name: " + s.Name);
                Console.WriteLine("CGPA: " + s.Cgpa);
            }
        }
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            Random rand = new Random();
            for(int i = 0; i <=1000; i++)
            {
                Student s = new Student();
                s.Id = i + 1;
                s.Name = "Student" + (i + 1);
                s.Cgpa = rand.NextDouble() * (4.00 - 2.50) + 2.50;
                students.Add(s);
            }

            var filteredStu = (from s in students 
                              where s.Cgpa > 3.75 && 
                              (s.Id > 1 && s.Id <= 100 || s.Id >=901 && s.Id <= 1000)   
                              && s.Name.Contains("2")
                              select new { s.Name, s.Cgpa }).ToList();

            Print(filteredStu);


            int[] arr = new int[] { 12, 13, 14, 23, 22, 24, 25, 34, 12, 45, };
            foreach(var i in arr)
            {
                if (i > 20)
                {
                    //insert into another array
                }
            }
            var filtered = (from i in arr where i > 20 select i).ToList();
        }
    }
}
