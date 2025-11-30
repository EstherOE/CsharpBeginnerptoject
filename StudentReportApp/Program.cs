// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System;
class Student {
    public string dname;
    public int dage;
    public double dscore;
    public Student(string name, int age, double score)
    {
        dname = name;
        dage= age;
        dscore= score;
    }
}

class Program
{
   static void Main(string[] args) 
    {
  StudentManager manager = new StudentManager();
        while (true)
        {
            Console.WriteLine("\n===== Student Report System");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2, View All student");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Remove Student");
            Console.WriteLine("5. Average Score");
            Console.WriteLine("6. Highest score");
            Console.WriteLine("7. Lowest Score");
            Console.WriteLine("8. Exit");


            Console.Write("Choose an option");
             int option= Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    manager.AddStudent();
                    break;
                    case 2:
                    manager.ViewStudent(); break;
                    case 3:
                    manager.SearchStudent();
                    break;
                    case 4:
                    manager.RemoveStudent();
                    break;  
                    case 5:     
                    manager.AverageScore(); break;
                    case 6: 
                    manager.HighestScore(); break;
                    case 7:
                    manager.LowestScore(); break;

                default:
                    Console.WriteLine("Invalid Option");
                    break;


            }
        }
    }
}
