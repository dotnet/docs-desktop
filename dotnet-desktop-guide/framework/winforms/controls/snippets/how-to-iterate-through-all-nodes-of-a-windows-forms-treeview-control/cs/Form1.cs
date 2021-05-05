using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        //List of all students
        private ArrayList studentArray = new ArrayList();

        //Windows Form application
        public Form1()
        {
            InitializeComponent();

            //Loading the TreeView with data
            PopulateTreeView();

            //Below method implementations will start printing node values to MessageBoxes and can be time consuming.
            //An alternate way to check is adding two labels and printing the values of the total nodes in each using both the below traversal methods.
            
            //Printing the total number of nodes recursively
            //CallRecursive(trvTest);

            //CallNonRecursive(trvTest);
        }

        // <PrintRecursive>
        private void PrintRecursive(TreeNode treeNode)
        {
            // Print the node.  
            System.Diagnostics.Debug.WriteLine(treeNode.Text);
            MessageBox.Show(treeNode.Text);

            // Visit each node recursively.  
            foreach (TreeNode tn in treeNode.Nodes)
            {
                PrintRecursive(tn);
            }
        }       

        // Call the procedure using the TreeView.  
        private void CallRecursive(TreeView treeView)
        {
            // Print each node recursively.  
            foreach (TreeNode n in treeView.Nodes)
            {
                //recursiveTotalNodes++;
                PrintRecursive(n);
            }
        }
        // </PrintRecursive>

        // <PrintNonRecursive>
        private void PrintNonRecursive(TreeNode treeNode)
        {
            if (treeNode != null)
            {
                //Using a queue to store and process each node in the TreeView
                Queue<TreeNode> staging = new Queue<TreeNode>();
                staging.Enqueue(treeNode);

                while (staging.Count > 0)
                {
                    treeNode = staging.Dequeue();
                    
                    // Print the node.  
                    System.Diagnostics.Debug.WriteLine(treeNode.Text);
                    MessageBox.Show(treeNode.Text);

                    foreach (TreeNode node in treeNode.Nodes)
                    {
                        staging.Enqueue(node);
                    }
                }
            }
        }

        // Call the procedure using the TreeView.  
        private void CallNonRecursive(TreeView treeView)
        {
            // Print each node.
            foreach (TreeNode n in treeView.Nodes)
            {
                PrintNonRecursive(n);
            }
        }
        // </PrintNonRecursive>

        private void PopulateTreeView()
        {
            // Add students  to the ArrayList of Student objects.
            for (int x = 0; x < 5; x++)
            {
                studentArray.Add(new Student("Student " + x.ToString()));
            }

            // Add subjects to each Student object in the ArrayList.
            foreach (Student student in studentArray)
            {
                for (int y = 0; y < 10; y++)
                {
                    student.StudentSubjects.Add(new Subject("Subject " + y.ToString()));
                }
            }

            Random _random = new Random();

            // Add subjects to each Student object in the ArrayList.
            foreach (Student student in studentArray)
            {
                foreach (Subject subject in student.StudentSubjects)
                {
                    var gen = _random.Next(1, 10);

                    for (int y = 0; y < gen; y++)
                    {
                        subject.SubjectTextbooks.Add(new TextBook("TextBook " + y.ToString()));
                    }
                }                
            }

            // Suppress repainting the TreeView until all the objects have been created.
            trvTest.BeginUpdate();

            // Clear the TreeView each time the method is called.
            trvTest.Nodes.Clear();

            // Add a root TreeNode for each Student object in the ArrayList.
            foreach (Student student in studentArray)
            {
                trvTest.Nodes.Add(new TreeNode(student.StudentName));

                // Add a child treenode for each Subject object in the current student object.
                foreach (Subject subject in student.StudentSubjects)
                {
                    trvTest.Nodes[studentArray.IndexOf(student)].Nodes.Add(
                      new TreeNode(subject.SubjectID));

                    // Add a child treenode for each TextBook object in the current Subject object.

                    foreach (TextBook textbook in subject.SubjectTextbooks)
                    {
                        trvTest.Nodes[studentArray.IndexOf(student)].Nodes[student.StudentSubjects.IndexOf(subject)].Nodes.Add(
                        new TreeNode(textbook.TextBookID));
                    }
                }
            }

            // Begin repainting the TreeView.
            trvTest.EndUpdate();
        }


    }
}
