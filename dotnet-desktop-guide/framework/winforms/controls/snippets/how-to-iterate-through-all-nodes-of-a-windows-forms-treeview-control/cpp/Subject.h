#pragma once
namespace project {
    using namespace System;
    using namespace System::Collections;

    public ref class Subject
    {
    private:
        ArrayList^ _subjectTextbooks = gcnew ArrayList();
    public:
        String^ SubjectID = "";

        ArrayList^ SubjectTextbooks = _subjectTextbooks;

        Subject(String^ subjectID)
        {
            SubjectID = subjectID;
        }
    };
}

