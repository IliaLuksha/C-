using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace WindowsService1
{
    class Interface
    {
        Info infer = new Info();
        private void Archiving(string path)//функция архивации файла
        {
            string zip = infer.Source + Path.GetFileNameWithoutExtension(path) + ".gz";
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
            string FIlePath = infer.Target + @"Archive\" + Path.GetFileNameWithoutExtension(path) + ".gz";
            string targetFile = infer.Target + @"DisArchive";
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
            string zip1 = infer.Source + Path.GetFileNameWithoutExtension(path) + ".gz";
            string zip2 = infer.Target + @"Archive\" + Path.GetFileNameWithoutExtension(path) + ".gz";
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
