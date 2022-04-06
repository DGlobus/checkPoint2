using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class University
    {
        List<Faculty> faculties;
        public string Name { get; private set; }
        public string Rating { get; private set; }

        public University(string Name, string Rating, List<Faculty> faculties)
        {
            this.Name = Name;
            this.Rating = Rating;
            this.faculties = faculties;
        }

        public void AddNewDepartment(Faculty faculty)
        {
            faculties.Add(faculty);
        }

        public void PrintAllDepartments()
        {
            foreach (Faculty department in faculties)
            {
                Console.WriteLine(department.Name);
            }
        }
    }

    class Faculty
    {
        public string Name { get; private set; }
        public int NumberOfDepartments { get; private set; }

        List<Student> students;
        List<Teacher> teachers;
        List<Stuff> stuff;

        public Faculty(string Name, int NumberOfDepartments, List<Student> students, List<Teacher> teachers, List<Stuff> stuff)
        {
            this.Name = Name;
            this.NumberOfDepartments = NumberOfDepartments;
            this.students = students;
            this.teachers = teachers;
            this.stuff = stuff;
        }

        public void PrintTotalAmountOfPeople()
        {
            Console.WriteLine(students.Count+teachers.Count+stuff.Count);
        }
    }

    internal interface IGetRoomKey
    {
        void GetKey();
    }

    abstract class UniversityPerson
    {
        public string Name { get; private set; }
        public int PassID { get; private set; }

        protected UniversityPerson(string Name, int PassID)
        {
            this.Name = Name;
            this.PassID = PassID;
        }

        public abstract void EnterTheUniversity();
    }

    internal class Student : UniversityPerson
    {
        public int CourseNumber { get; private set; }
        public bool GoodStudent { get; private set; }

        public Student(string Name, int PassID, int CourseNumber, bool GoodStrudent):base(Name, PassID)
        {
            this.CourseNumber = CourseNumber;
            this.GoodStudent = GoodStrudent;
        }
        
        public override void EnterTheUniversity()
        {
            Console.WriteLine("Просто иду в кабинет");
        }

        public void TakenToNextCource()
        {

            if (CourseNumber >= 4)
                Console.WriteLine("отчислен");
            else
            {
                Console.WriteLine("переведен на следующий курс");
                CourseNumber++;
            }
        }
    }

    class Teacher : UniversityPerson, IGetRoomKey
    {
        public string Qualification { get; private set; }

        public Teacher(string Name, int PassID, string Qualification): base(Name, PassID)
        {
            this.Qualification = Qualification;
        }

        public override void EnterTheUniversity()
        {
            GetKey();
            Console.WriteLine("Иду в аудиторию");
        }

        public void GetKey()
        {
            Console.WriteLine("Сходить на кафедру, взять ключ");
        }

        public void TakeAnExam(Student student)
        {
            if(student.GoodStudent || DateTime.Now.DayOfWeek.CompareTo(DayOfWeek.Friday) == 0)
                Console.WriteLine("Сдал");
            else
                Console.WriteLine("Не сдал");
        }
    }

    class Stuff: UniversityPerson, IGetRoomKey
    {
        public string Position { get; private set; }

        public Stuff(string Name, int PassID, string Position) : base(Name, PassID)
        {
            this.Position = Position;
        }

        public override void EnterTheUniversity()
        {
            GetKey();
            Console.WriteLine("Иду к себе в кабинет");
        }

        public void GetKey()
        {
            Console.WriteLine("Сходить на вахту, взять ключ");
        }

        public void Work()
        {
            Console.WriteLine("Работаю");
        }
    }
}
