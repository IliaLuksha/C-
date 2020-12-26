using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WindowsService1;

namespace Data
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        public void OnDebug()
        {
            OnStart(null);
        }

        class Logger
        {
            Interface inter = new Interface();
            FileSystemWatcher Watcher;
            Info Infer = new Info();
            Confik Parser = new Confik();
            bool ifer;

            public Logger()
            {
                if (File.Exists(@"C:\\Users\\User\\Desktop\\XML.xml"))
                    Infer = Parser.XML();

                else
                {
                    if (File.Exists(@"C:\\Users\\User\\Desktop\\JSON.json"))
                        Infer = Parser.JSON();
                    else
                        EROR();
                }

                Watcher.Path = Infer.Source;
                Watcher.IncludeSubdirectories = true;
                Watcher.EnableRaisingEvents = true;
                Watcher.Created += Created;
                Watcher.Deleted += Deleted;
                Watcher.Renamed += Renamed;
                Watcher.Changed += Changed;
            }

            private void Created(object sender, System.IO.FileSystemEventArgs e)
            {
                inter.Show(inter, e.FullPath);
            }

            private void Deleted(object sender, System.IO.FileSystemEventArgs e)
            {
                inter.Show(inter, e.FullPath);
            }

            private void Renamed(object sender, System.IO.FileSystemEventArgs e)
            {
                inter.Show(inter, e.FullPath);
            }

            private void Changed(object sender, System.IO.FileSystemEventArgs e)
            {
                inter.Show(inter, e.FullPath);
            }
        }

        protected override void OnStart(string[] args)
        {
            logger = new Logger();
            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            logger.Stop();
            Thread.Sleep(1000);
        }
        public static void EROR()
        {
            Console.WriteLine("ERROR. There are no configs ");
        }
    }
}
}
