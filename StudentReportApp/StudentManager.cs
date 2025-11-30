using System;
using System.Collections.Generic;
using System.Text;

class StudentManager
{
    private List<Student> students=new List<Student>();

    public void AddStudent()
    {
            Console.WriteLine("Enter  name");
            String name = Console.ReadLine();

            Console.WriteLine("Enter age");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the score");
            double score = Convert.ToDouble(Console.ReadLine());

            Student s = new Student(name, age, score);
            students.Add(s);

            Console.WriteLine("Student  added");
        

    }

    public void RemoveStudent()
    {
        Console.WriteLine("Enter  name to remove: ");
        String name = Console.ReadLine();
        foreach (Student s in students)
        {
            if (s.dname.ToLower() == name)
            {
                students.Remove(s);
         
                Console.WriteLine("Student removed");
                return;
            }
        }
        Console.WriteLine("Student not found");
    }
    public void SearchStudent() { }
    public void AverageScore() { }
    public void HighestScore() { }
    public void LowestScore() { }
    public void ViewStudent()
    {
        Console.WriteLine("\n ---------Student Entered --------");
        foreach (Student s in students)
        {
            Console.WriteLine($"Name : {s.dname}, Age:  {s.dage}, Score:  {s.dscore} ");
        }


    }


}