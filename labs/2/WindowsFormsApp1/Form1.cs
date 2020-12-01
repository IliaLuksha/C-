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
using System.IO.Compression;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        string TargetDirectory = @"C:\Users\User\Desktop\TargetDirectory\";
        string SourseDirectory = @"C:\Users\User\Desktop\SourceDirectory\";
        Interface inter = new Interface();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            inter.Show(inter, e.FullPath);
        }


        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            inter.Show(inter, e.FullPath);
        }
    }

    class Interface
    {
        string TargetDirectory = @"C:\Users\User\Desktop\TargetDirectory\";
        string SourseDirectory = @"C:\Users\User\Desktop\SourceDirectory\";
        private void Archiving(string path)//функция архивации файла
        {
            string zip = SourseDirectory + Path.GetFileNameWithoutExtension(path) + ".gz";
            using (FileStream sourceStream = new FileStream(path, FileMode.Open))
            {
                using (FileStream targetStream = File.Create(zip))
                {
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream);
                    }
                }
            }
        }

        private void DisArchiving(string path)//дизархивация
        {
            string FIlePath = TargetDirectory + @"Archive\" + Path.GetFileNameWithoutExtension(path) + ".gz";
            string targetFile = TargetDirectory + @"DisArchive";
            using (FileStream sourceStream = new FileStream(FIlePath, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(targetFile))
                {
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                    }
                }
            }
        }

        private void Move(string path)
        {
                string zip1 = SourseDirectory + Path.GetFileNameWithoutExtension(path) + ".gz";
                string zip2 = TargetDirectory + @"Archive\" + Path.GetFileNameWithoutExtension(path) + ".gz";
                File.Copy(zip1, zip2, true);
                File.Delete(zip1);
        }

        public void Show(Interface inter, string path)
        {
            inter.Archiving(path);
            inter.Move(path);
            inter.DisArchiving(path);
        }
    }
}
