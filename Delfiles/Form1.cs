using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Delfiles
{
    public partial class Form1 : Form
    {
        
        private string[] files;
        private string[] folders;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnchs_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
            folders = Directory.GetDirectories(folderBrowserDialog1.SelectedPath);
            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                // info1 = info;

                if (info.LastAccessTime <= DateTime.Now.AddMonths(-3))
                {
                    listBox1.Items.Add(info.Name);
                    MessageBox.Show(info.LastAccessTime.ToString());
                }
                else
                {
                    MessageBox.Show(info.Name + " " + " is new");
                }
            }
            foreach (var folder in folders)
            {
                DirectoryInfo infofolder = new DirectoryInfo(folder);
                if (infofolder.LastAccessTime <= DateTime.Now.AddMonths(-3))
                {
                    listBox1.Items.Add(infofolder.Name);
                    MessageBox.Show(infofolder.LastAccessTime.ToString());
                }
                else
                {
                    MessageBox.Show(infofolder.Name + " " + " is new");
                }

            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            foreach (var file in files)
            {
                FileInfo info1 = new FileInfo(file);
                if (info1.LastAccessTime <= DateTime.Now.AddMonths(-3))
                {
                    info1.Delete();
                }
                else
                {
                    MessageBox.Show(info1.Name + " : " + " you can't delete this file");
                }

            }
            foreach (var folder in folders)
            {
                DirectoryInfo infofolder1 = new DirectoryInfo(folder);
                if (infofolder1.LastAccessTime <= DateTime.Now.AddMonths(-3))
                {
                    infofolder1.Delete();
                }
                else
                {
                    MessageBox.Show(infofolder1.Name + " : " + " you can't delete this folder");
                }

            }

        }
    }
}
