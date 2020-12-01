using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

//D://1.txt
//path.IndexOfAny(Path.GetInvalidPathChars())
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Сheck funk = new Сheck();
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            string path = comboBox2.Text;
            if (funk.Сhecker(FBD, path))
            {
                textBox1.Text = "";
                textBox1.Clear();
                string dir = FBD.SelectedPath;
                dir += @"\note." + comboBox2.Text;
                textBox1.Text = dir;
                using (FileStream file = new FileStream(dir, FileMode.CreateNew));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //write
           string path = textBox1.Text;
           string path1 = textBox4.Text;
            if (funk.Сhecker(path, path1))
            {
                using (FileStream file1 = new FileStream(path, FileMode.Open))
                {
                    file1.Seek(0, SeekOrigin.End);
                    using (StreamWriter stream = new StreamWriter(file1))
                        stream.WriteLine(path1);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = " ";
            path = textBox1.Text;
            if (File.Exists(path) == false && Directory.Exists(path) == false)
            {
                MessageBox.Show("ERROR. Check the path or file");
            }
            else
            {
                File.Delete(path);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        class Сheck
        {
            public bool Сhecker(FolderBrowserDialog FBD, string path)
            {
                if (FBD.ShowDialog() == DialogResult.OK && path != String.Empty)
                    return true;
                else
                    MessageBox.Show("ERROR. Check the enter of the path or file type enter");
                return false;
            }
            public bool Сhecker(string path, string path1)
            {
                if (path != String.Empty && path1 != String.Empty)
                    return true;
                else
                    MessageBox.Show("ERROR. Check the path of the file or text, that you write");
                return false;
            }
            public bool Cheker(FolderBrowserDialog FBD)
            {
                if (FBD.ShowDialog() == DialogResult.OK)
                    return true;
                else
                    MessageBox.Show("ERROR. Chek tha path of the file");
                return false;
            }
            public bool Cheker(FolderBrowserDialog FBD, string path1, string path2)
            {
                if (FBD.ShowDialog() == DialogResult.OK && path1 != String.Empty && path2 != String.Empty)
                    return true;
                else
                    return false;
            }
            public int Check1(string path, string text)
            {
                if (File.Exists(path) == false)
                {
                    MessageBox.Show("ERROR. Check the path or file");
                    return 1;
                }
                else 
                {
                    if(text == String.Empty)
                    {
                        return 2;
                    }
                    return 0;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = " ", text = " ";
            path = textBox1.Text;
            text = textBox5.Text;

            if (funk.Check1(path,text) == 2 || funk.Check1(path, text) == 0)
            {
                if (funk.Check1(path, text) == 2)
                    textBox5.Clear();
                using (FileStream file = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(file))
                        textBox5.Text = reader.ReadToEnd();
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e) //архивация
        {
            string path = textBox6.Text+@"\";//откуда
            string path2 = comboBox1.Text;
            string path3 = textBox8.Text;//куда
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (funk.Cheker(FBD, path, path2))
            {
                textBox1.Text = "";
                textBox1.Clear();
                string dir = FBD.SelectedPath;
                dir += @"\Copy." + comboBox1.Text;
                textBox8.Text = dir;
                path += @"\";
                ZipFile.CreateFromDirectory(path, dir);                     
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }
     
        private void button6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (funk.Cheker(FBD))
            {
                textBox6.Text = "";
                textBox6.Clear();
                FBD.ShowDialog();
                string dir = FBD.SelectedPath;
                dir+= @"\Copy";
                textBox6.Text = dir;
                DirectoryInfo folder = new DirectoryInfo(dir);
                folder.Create();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
