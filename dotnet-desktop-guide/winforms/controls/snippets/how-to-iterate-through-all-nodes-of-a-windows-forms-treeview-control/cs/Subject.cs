using System.Collections;

namespace project
{
    // The basic student Subject class.
    public class Subject
    {
        protected ArrayList _subjectTextbooks = new ArrayList();

        public Subject(string subjectID)
        {
            SubjectID = subjectID;
        }

        public string SubjectID { get; set; } = "";

        public ArrayList SubjectTextbooks => _subjectTextbooks;
    }
}
