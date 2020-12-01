using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;

namespace File
{
    public class Class1
    {
        static int count = 0;
        static int counter = 0; 
        private void Change(object source, FileSystemEventArgs е)
        {
            counter++;
             count++;
        }
        private string Change(string path)//проверка изменений в папке
        {
            //path путь к папке, которую мыхотим проверить на изменения 
            //1 при отсутствии изменений
            //0 при неправильном пути
            //при изменении возвращает путь к файлам через пробел
            try
            {
                if (Directory.Exists(path))
                { 
                    FileSystemWatcher watcher = new FileSystemWatcher(path);
                    //фильтр на отслеживание txt файлов 
                    watcher.Created += Change;
                    watcher.Deleted += Change;
                    watcher.Renamed += Change;
                    watcher.EnableRaisingEvents = true;// начинаем осмотр
                    string[] dirs = Directory.GetDirectories(watcher.Path); //массив со списком папок с папки SourceDirectory
                    string PathInfo = " ";
                    foreach (string s in dirs) //s - элемент из массива 
                    {
                        watcher.Path = s;
                        watcher.Created += Change;
                        watcher.Created += Change;
                        watcher.Deleted += Change;
                        watcher.Renamed += Change;
                        watcher.EnableRaisingEvents = true;// начинаем осмотр
                        if (counter != 0)
                        {
                            PathInfo += s + " ";
                        }
                        counter = 0;
                        return s;
                    }

                    if (count != 0)
                    {
                        count = 0;
                        return "1";
                    }
                    else
                        return PathInfo;
                }
                else
                {
                    return "0";//Path is not correct
                }
            }
            catch
            {
                return "0";//Error
            }

        }
        private string Archiving(string path)//архивация файла 
        {
            //path путь к файлу, который будем архивировать
            //FolderPath путь к файлу с архивом 
            //вернет путь к архиву если архивация прошла успешна
            //0 если архивация не была совершена
            try
            {
                if (Directory.Exists(path))
                {
                    string FolderPath = path.Remove(path.LastIndexOf('.')) + ".zip";//удаляет все символы с конца строки пока не встретит точку
                    ZipFile.CreateFromDirectory(path, FolderPath);
                    return FolderPath;
                }
                else
                    return "0";//Path is not correct

            }
            catch
            {
                return "0";//Error
            }
        }
        private string DeArchiving(string path)//деархивация файла
        {
            //path путь к архиву 
            //FolderPath путь к папке, в которой находится архив
            //FilePath путь к распакованному файлу
            //возвращает путь к распакованному файлу если деархивация прошла успешна
            //0 если деархивация не была совершена
            try
            {
                if (Directory.Exists(path))
                {
                    string FolderPath = path.Remove(path.LastIndexOf('/'));//удаляет все символы с конца строки пока не встретит точку, находим путь к файлу с архива
                    string FilePath = path.Remove(path.LastIndexOf('.')) + ".txt";//путь к распакованному файлу
                    ZipFile.ExtractToDirectory(path, FolderPath);
                    return FilePath;
                }
                return "0";
            }
            catch
            {
                return "0";
            }     
        }
    }
}
