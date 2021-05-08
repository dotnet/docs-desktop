#pragma once
#include "Student.h"
#include "Subject.h"
#include "TextBook.h"

namespace project {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();
			
            PopulateTreeView();

            //Below method implementations will start printing node values to MessageBoxes and can be time consuming.
            //An alternate way to check is adding two labels and printing the values of the total nodes in each using both the below traversal methods.
            
            //CallRecursive(trvTest);
            
            //CallNonRecursive(trvTest);
		}

    private:
        //List of all students
        ArrayList^ studentArray = gcnew ArrayList();

        void PopulateTreeView()
        {
            // Add students  to the ArrayList of Student objects.
            for (int x = 0; x < 5; x++)
            {
                studentArray->Add(gcnew Student("Student " + x.ToString()));
            }

            // Add subjects to each Student object in the ArrayList.
            for(int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    safe_cast<Student^>(studentArray[x])->StudentSubjects->Add(gcnew Subject("Subject " + y.ToString()));
                }
            }

            // Add subjects to each Student object in the ArrayList.
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    for (int z = 0; z < 3; z++)
                    {
                       safe_cast<Subject^>(safe_cast<Student^>(studentArray[x])->StudentSubjects[y])->SubjectTextbooks->Add(gcnew TextBook("TextBook " + z.ToString()));
                    }
                }
            }

            // Suppress repainting the TreeView until all the objects have been created.
            trvTest->BeginUpdate();

            // Clear the TreeView each time the method is called.
            trvTest->Nodes->Clear();

            System::Collections::IEnumerator^ studArray = (safe_cast<System::Collections::IEnumerable^>(studentArray))->GetEnumerator();

            // Add a root TreeNode for each Student object in the ArrayList.
            while (studArray->MoveNext())
            {
                trvTest->Nodes->Add(gcnew TreeNode(safe_cast<Student^>(studArray->Current)->StudentName));

                System::Collections::IEnumerator^ studSubjects = (safe_cast<System::Collections::IEnumerable^>(safe_cast<Student^>(studArray->Current)->StudentSubjects))->GetEnumerator();

                while (studSubjects->MoveNext())
                {
                    trvTest->Nodes[studentArray->IndexOf(safe_cast<Student^>(studArray->Current))]->Nodes->Add(gcnew TreeNode(safe_cast<Subject^>(studSubjects->Current)->SubjectID));
                
                    System::Collections::IEnumerator^ subTextbooks = (safe_cast<System::Collections::IEnumerable^>(safe_cast<Subject^>(studSubjects->Current)->SubjectTextbooks))->GetEnumerator();
                    
                    while (subTextbooks->MoveNext())
                    {
                        trvTest->Nodes[studentArray->IndexOf(safe_cast<Student^>(studArray->Current))]->Nodes[safe_cast<Student^>(studArray->Current)->StudentSubjects->IndexOf(safe_cast<Subject^>(studSubjects->Current))]->Nodes->Add(gcnew TreeNode(safe_cast<TextBook^>(subTextbooks->Current)->TextBookID));
                    }
                }
            }

            // Begin repainting the TreeView.
            trvTest->EndUpdate();
        }

    // <PrintRecursive>
    private:
        void PrintRecursive(TreeNode^ treeNode)
        {
            // Print the node.  
            System::Diagnostics::Debug::WriteLine(treeNode->Text);
            MessageBox::Show(treeNode->Text);

            // Print each node recursively.  
            System::Collections::IEnumerator^ myNodes = (safe_cast<System::Collections::IEnumerable^>(treeNode->Nodes))->GetEnumerator();
            try
            {
                while (myNodes->MoveNext())
                {
                    TreeNode^ tn = safe_cast<TreeNode^>(myNodes->Current);
                    PrintRecursive(tn);
                }
            }
            finally
            {
                delete(myNodes);
            }
        }

        // Call the procedure using the TreeView.  
        void CallRecursive(TreeView^ treeView)
        {
            // Print each node recursively.  
            TreeNodeCollection^ nodes = treeView->Nodes;
            System::Collections::IEnumerator^ myNodes = (safe_cast<System::Collections::IEnumerable^>(nodes))->GetEnumerator();
            try
            {
                while (myNodes->MoveNext())
                {
                    TreeNode^ n = safe_cast<TreeNode^>(myNodes->Current);
                    PrintRecursive(n);
                }
            }
            finally
            {
                delete(myNodes);
            }
        }
    // </PrintRecursive>
    
    // <PrintNonRecursive>
    private:
        void PrintNonRecursive(TreeNode^ treeNode)
        {
            //Using a queue to store and process each node in the TreeView
            Queue^ staging = gcnew Queue();
            staging->Enqueue(treeNode);
            while (staging->Count > 0)
            {
                treeNode = safe_cast<TreeNode^>(staging->Dequeue());

                // Print the node.  
                System::Diagnostics::Debug::WriteLine(treeNode->Text);
                MessageBox::Show(treeNode->Text);

                System::Collections::IEnumerator^ children = (safe_cast<System::Collections::IEnumerable^>(treeNode->Nodes))->GetEnumerator();
                try 
                {
                    while (children->MoveNext())
                    {
                        staging->Enqueue(children->Current);
                    }
                }
                finally
                {
                    delete(children);
                }                
            }

            // Print the node.  
            System::Diagnostics::Debug::WriteLine(treeNode->Text);
            MessageBox::Show(treeNode->Text);

            // Print each node recursively.  
            System::Collections::IEnumerator^ myNodes = (safe_cast<System::Collections::IEnumerable^>(treeNode->Nodes))->GetEnumerator();
            try
            {
                while (myNodes->MoveNext())
                {
                    TreeNode^ tn = safe_cast<TreeNode^>(myNodes->Current);
                    PrintRecursive(tn);
                }
            }
            finally
            {
                delete(myNodes);
            }
        }

        // Call the procedure using the TreeView.  
        void CallNonRecursive(TreeView^ treeView)
        {
            // Print each node recursively.  
            TreeNodeCollection^ nodes = treeView->Nodes;
            System::Collections::IEnumerator^ myNodes = (safe_cast<System::Collections::IEnumerable^>(nodes))->GetEnumerator();
            try
            {
                while (myNodes->MoveNext())
                {
                    TreeNode^ n = safe_cast<TreeNode^>(myNodes->Current);
                    PrintNonRecursive(n);
                }
            }
            finally
            {
                delete(myNodes);
            }
        }
        // </PrintNonRecursive>

    private:

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
    private: System::Windows::Forms::TreeView^ trvTest;
    protected:

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
            this->trvTest = (gcnew System::Windows::Forms::TreeView());
            this->SuspendLayout();
            // 
            // trvTest
            // 
            this->trvTest->Location = System::Drawing::Point(12, 12);
            this->trvTest->Name = L"trvTest";
            this->trvTest->Size = System::Drawing::Size(474, 396);
            this->trvTest->TabIndex = 0;
            // 
            // MyForm
            // 
            this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
            this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
            this->ClientSize = System::Drawing::Size(498, 420);
            this->Controls->Add(this->trvTest);
            this->Name = L"MyForm";
            this->Text = L"MyForm";
            this->ResumeLayout(false);

        }
#pragma endregion
	};
}
