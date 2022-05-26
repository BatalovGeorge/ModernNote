using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernNote
{
    public struct WorkerManipulation
    {
        private string path;
        public string SetPath { set { path = value; } }
        public string GetPath { get { return path; } }
        public bool FileExist()
        {
            Console.WriteLine("Введите имя файла: ");
            SetPath = Console.ReadLine();
            bool exist = File.Exists($@"{GetPath}.txt") ? true : false;
           
            return exist;
        }

        public void RecordInFileData(int id)
        {
            using (StreamWriter sW = new StreamWriter(GetPath,true))
            {
                char key = 'д';

                do
                {
                    Console.WriteLine("Введите Имя :");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите Город :");
                    string city = Console.ReadLine();

                    var worker = new Worker(id, name, city);

                    sW.WriteLine(worker.Print());

                    Console.WriteLine("Продолжить д/н");
                    key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key) == 'д');
            }
        }

        public string CheckFile()
        {
            int n = 0;
            if (FileExist()==true)
            {
                RecordInFileData(n);
            }
            else { File.Create($@"{GetPath}.txt"); RecordInFileData(n+999); }
            return null;
        }

    }
}
