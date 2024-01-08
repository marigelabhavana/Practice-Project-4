using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Person class to represent common properties for both students and teachers
public class Person
{
    public string Name { get; set; }
    public string ClassAndSection { get; set; }
}

// Student class inheriting from Person
public class Student : Person { }

// Teacher class inheriting from Person
public class Teacher : Person { }

// Subject class
public class Subject
{
    public string Name { get; set; }
    public string SubjectCode { get; set; }
    public Teacher Teacher { get; set; }
}

// SchoolData class to manage lists of students, teachers, and subjects
public class SchoolData
{
    public List<Student> Students { get; set; } = new List<Student>();
    public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    public List<Subject> Subjects { get; set; } = new List<Subject>();
}

public class SchoolManager
{
    private SchoolData schoolData = new SchoolData();

    // Method to fill up the lists with dummy data
    public void FillData()
    {
        schoolData.Students.Add(new Student { Name = "Abhi", ClassAndSection = "Class 1" });
        schoolData.Students.Add(new Student { Name = "Vishruth", ClassAndSection = "Class 2" });
        schoolData.Students.Add(new Student { Name = "Radha", ClassAndSection = "Class 3" });
        schoolData.Students.Add(new Student { Name = "Saanvi", ClassAndSection = "Class 4" });
        schoolData.Students.Add(new Student { Name = "Dhruv", ClassAndSection = "Class 5" });

        schoolData.Teachers.Add(new Teacher { Name = "Teacher 1", ClassAndSection = "Class 1" });
        schoolData.Teachers.Add(new Teacher { Name = "Teacher 2", ClassAndSection = "Class 2" });
        schoolData.Teachers.Add(new Teacher { Name = "Teacher 3", ClassAndSection = "Class 3" });
        schoolData.Teachers.Add(new Teacher { Name = "Teacher 4", ClassAndSection = "Class 4" });
        schoolData.Teachers.Add(new Teacher { Name = "Teacher 5", ClassAndSection = "Class 5" });

        schoolData.Subjects.Add(new Subject { Name = "Math", SubjectCode = "M101", Teacher = schoolData.Teachers[0] });
        schoolData.Subjects.Add(new Subject { Name = "Science", SubjectCode = "S101", Teacher = schoolData.Teachers[1] });
        schoolData.Subjects.Add(new Subject { Name = "Telugu", SubjectCode = "T101", Teacher = schoolData.Teachers[2] });
        schoolData.Subjects.Add(new Subject { Name = "Social Studies", SubjectCode = "SS101", Teacher = schoolData.Teachers[3] });
        schoolData.Subjects.Add(new Subject { Name = "English", SubjectCode = "E101", Teacher = schoolData.Teachers[4] });

    }

    // Method to display students in a class
    public void DisplayStudentsInClass(string className)
    {
        var studentsInClass = schoolData.Students.Where(s => s.ClassAndSection == className).ToList();
        Console.WriteLine($"Students in {className}:");
        foreach (var student in studentsInClass)
        {
            Console.WriteLine($"{student.Name}");
        }
    }

    // Method to display subjects taught by a teacher
    public void DisplaySubjectsByTeacher(string teacherName)
    {
        var teacher = schoolData.Teachers.FirstOrDefault(t => t.Name == teacherName);
        if (teacher != null)
        {
            var subjectsByTeacher = schoolData.Subjects.Where(s => s.Teacher == teacher).ToList();
            Console.WriteLine($"Subjects taught by {teacherName}:");
            foreach (var subject in subjectsByTeacher)
            {
                Console.WriteLine($"{subject.Name} ({subject.SubjectCode})");
            }
        }
        else
        {
            Console.WriteLine($"Teacher {teacherName} not found.");
        }
    }
}


namespace Rainbow_Schools
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolManager schoolManager = new SchoolManager();

            // Fill data
            schoolManager.FillData();

            // Display students in a class
            schoolManager.DisplayStudentsInClass("Class 1");

            // Display subjects taught by a teacher
            schoolManager.DisplaySubjectsByTeacher("Teacher 1");
        }
    }
}
