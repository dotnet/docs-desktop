#pragma once
namespace project {
    using namespace System;
    using namespace System::Collections;

    public ref class TextBook
    {
    public:
        String^ TextBookID = "";

        TextBook(String^ textBookID)
        {
            TextBookID = textBookID;
        }
    };
}
