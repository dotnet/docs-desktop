using System.Collections;

namespace project
{
    // The basic Student class.
    public class Student
    {
        protected ArrayList _studentSubjects = new ArrayList();

        public Student(string studentName)
        {
            StudentName = studentName;
        }

        public string StudentName { get; set; } = "";

        public ArrayList StudentSubjects => _studentSubjects;
    }
}
