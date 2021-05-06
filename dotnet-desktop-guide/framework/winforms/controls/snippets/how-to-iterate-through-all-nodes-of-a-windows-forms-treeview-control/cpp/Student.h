#pragma once
namespace project {

    using namespace System;
    using namespace System::Collections;
    public ref class Student
    {
    private:
        ArrayList^ _studentSubjects = gcnew ArrayList();
    public:
        String^ StudentName = "";

        ArrayList^ StudentSubjects = _studentSubjects;

        Student(String^ studentName)
        {
            StudentName = studentName;
        }
    };
};
