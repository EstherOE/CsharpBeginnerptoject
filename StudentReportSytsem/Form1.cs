using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentReportSytsem
{
    public partial class Form1 : Form
    {
        List<Student> students=new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            string name = nameText.Text;
            int age= int.Parse(ageText.Text);
             Student s= new Student(name, age);

            foreach(var item in chkStudent.CheckedItems)
            {
                string subjectname= item.ToString();
                double score= double.Parse(scoreText.Text);
                s.Subject.Add(new SubjectScore(subjectname, score));
            }
            students.Add(s);

            AddStudentToList(s);
        
        }

        void AddStudentToList(Student s)
        {
            listStudents.Items.Clear();
            foreach (var student in students)
            {
                foreach (var item in student.Subject)
                {
                    string[] row = { s.Name,
                        s.Age.ToString(),item.Score.ToString(),item.Subjectd  };

                    ListViewItem list = new ListViewItem(row);
                    listStudents.Items.Add(list);

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name= searchText.Text;
            var student= students.FirstOrDefault(s  => s.Name.ToLower() == name);

            if (student != null)
            {
                MessageBox.Show($"Found \nName: {student.Name}, Age:  {student.Age} ");
            }

            else
            {
                MessageBox.Show("No student found");
            }
                 }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = searchText.Text.ToLower();
            var student = students.FirstOrDefault(s => s.Name.ToLower() == name);

            if (student != null)
            {
                students.Remove(student);
                LoadStudentToListView();
                MessageBox.Show("Student Removed");
            }
            else
            {
                MessageBox.Show("No student found");
            }
        }

        void LoadStudentToListView()
            {
            listStudents.Items.Clear();
            foreach (var s in students)
            {
                AddStudentToList(s);
            }
            listStudents.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listStudents.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sorted = GetAllRows().OrderByDescending(r => r.dName).ToList();
            RefreshStudent(sorted);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var sorted = GetAllRows().OrderByDescending(r => r.Age).ToList();
            RefreshStudent(sorted);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var sorted = GetAllRows().OrderByDescending(r =>r.score).ToList();
            RefreshStudent(sorted);

        }
  void RefreshStudent(List<StudentRow> sorted=null)
        {
            listStudents.Items.Clear();
            List<StudentRow> rows = sorted ?? GetAllRows();
            foreach (var s in sorted)
            {
                string[] columns =
                {
                    s.dName,
                    s.Age.ToString(),
                    s.score.ToString(),
                    s.subj


                };
                listStudents.Items.Add(new ListViewItem(columns));
            }
        }
        private List<StudentRow> GetAllRows()
        {

            List<StudentRow> rows = new List<StudentRow>();
            foreach (var student in students)
            {
                foreach(var sub in student.Subject)
                {
                    rows.Add(new StudentRow()
                        {
                        dName=student.Name,
                        Age= student.Age,
                        score= sub.Score,
                        subj= sub.Subjectd


                    });
                }
            }
            return rows;
            
            }
        private void button7_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("students.txt"))
            {
                foreach (Student s in students)
                {
                    foreach (SubjectScore sub in s.Subject)
                    {
                        sw.WriteLine($"{s.Name}, {s.Age}, {sub.Score}, {sub.Subjectd}");

                    }
                }
            }
            MessageBox.Show("Saved!");
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

         }
}
