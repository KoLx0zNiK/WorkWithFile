using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string text, newname;
            string path = @"D:\Work\Богданович М\Слава украине.txt";
            string newpath = @"D:\Work\Богданович М\ForCopy\Слава украине.txt";
            string newnewpath = @"D:\Work\Богданович М\ForMove\Слава украине.txt";
            string pathDir = @"D:\Work\Богданович М";

            FileStream file = new FileStream(path, FileMode.Append);
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                Console.WriteLine("Файл существует");
                Console.WriteLine("Полный путь к файлу:", fileInf.DirectoryName);
                Console.WriteLine(fileInf.DirectoryName);
                Console.WriteLine("Имя файла:", fileInf.Name);
                Console.WriteLine(fileInf.Name);
                Console.WriteLine("Полное имя файла:", fileInf.FullName);
                Console.WriteLine(fileInf.FullName);
            }
            else
            {
                Console.WriteLine("Файла не существует");
            }
            
            StreamWriter writer = new StreamWriter(file);
            Console.WriteLine("Введите текст");
            text = Console.ReadLine();
            writer.WriteLine(text);
            writer.Close();

            Console.WriteLine("Тут написано:");
            StreamReader reader = new StreamReader(path);
            Console.ReadLine();
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();

            fileInf.MoveTo(newnewpath);
            Console.WriteLine("Ваш файл перемещен в " + newnewpath);
            fileInf.CopyTo(newpath);
            Console.WriteLine("Ваш файл скопирован в " + newpath);
            Console.WriteLine("Быстрее проверь, ибо файл скоро удалится "+newnewpath);
            Console.WriteLine("Введите имя нового файла");
            newname = Console.ReadLine();
            FileStream newFile = new FileStream(pathDir + newname, FileMode.Create);
            Console.WriteLine("Ваш файл тут:" + pathDir + newname);
            Console.WriteLine("Что пишем в файле?");
            StreamWriter newWriter = new StreamWriter(newFile);
            text = Console.ReadLine();
            newWriter.WriteLine(text);
            newWriter.Close();
            Console.WriteLine("Вы написали:");
            StreamReader newReader = new StreamReader(pathDir + newname);
            Console.ReadLine();
            Console.WriteLine(newReader.ReadToEnd());
            newReader.Close();
            Console.WriteLine("Ты не успел, файл удалился");
            File.Delete(newnewpath);
            Console.ReadKey();
        }
    }
}
