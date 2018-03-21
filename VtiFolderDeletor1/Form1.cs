using System;
using System.IO;
using System.Windows.Forms;

namespace VtiFolderDeletor1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string path = folderName.Text;
            int i = 0; int j = 0;
            if (Directory.Exists(path))
            {
                foreach (string file in Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories))
                {
                    if (file.Contains("_vti_")) { i++; }

                }

                foreach (string folder in Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories))
                {
                    if (folder.Contains("_vti_"))
                    {
                        DeleteFolder(folder, listBox1);
                        j++;
                        progressBar1.Value = (int)((j * 100) / i);
                        string message = folder + "........................................deleted";
                        listBox1.Items.Insert(0, message);
                        listBox1.Update();
                    }
                }
            }
            else
            {
                listBox1.Items.Insert(0, "***********************************************");
                listBox1.Items.Insert(0, "****You enter a wrong path for the file****");
                listBox1.Items.Insert(0, "***********************************************");
                listBox1.Update();
            }
           

        }

        //function to delete folder
        private static void DeleteFolder(string pathToVti , ListBox listBox)
        {
            if (Directory.Exists(pathToVti))
            {
                foreach (string directory in Directory.GetDirectories(pathToVti))
                {
                DeleteFolder(directory , listBox);
                string message = pathToVti + ".....................................is being scanned";
                listBox.Items.Insert(0, message);
                listBox.Update();
                }
            
               try
                {
                     Directory.Delete(pathToVti, true);
                     string message = pathToVti + "........................................deleted";
                     listBox.Items.Insert(0, message);
                     listBox.Update();
                }
                catch (IOException)
                {
                     Directory.Delete(pathToVti, true);
                     string message = pathToVti + "........................................deleted";
                     listBox.Items.Insert(0, message);
                     listBox.Update();
                }
                catch (UnauthorizedAccessException)
                {
                     Directory.Delete(pathToVti, true);
                     string message = pathToVti + "........................................deleted";
                     listBox.Items.Insert(0, message);
                     listBox.Update();
               }
            }
        }
    }
}
