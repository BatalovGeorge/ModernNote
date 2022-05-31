using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernNote
{
    struct AddOrDeleteWorker
    {
        private string path;
        public string SetPath { set { path = value; } }
        public string GetPath { get { return path; } }

        public string FilePath()
        {
            Console.WriteLine("Введите имя файла: ");
            SetPath = Console.ReadLine();
            return GetPath;
        }

        public string ShowDBContent()
        {
            string text = String.Empty;
            using (StreamReader sR = new StreamReader(FilePath()))
            {
                 text= sR.ReadToEnd();
                Console.WriteLine(text);
            }
            return text;
        }
        public string ShoWorker()
        {
            string text = SplitDB(FilePath());
            Console.WriteLine(text);
            return text;
        }

        public string SplitDB(string path)
        {
            this.path = GetPath;
            string text = string.Empty;
            using (StreamReader sR = new StreamReader(path))
            {
                text = sR.ReadToEnd();
                string[] spl = text.Split("-----");
                text = SearchWorker(spl);
            }
            return text;
        }

        public string SearchWorker(string[] text)
        {
            int num = WorkerFlag();
            return text[num - 1];
        }

        public int WorkerFlag()
        {
            Console.WriteLine("введите номер сотрудника ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void DeleteWorker()
        {
            string text = ShoWorker();
            using (StreamWriter sR = new StreamWriter(GetPath,true))
            {
                string[] split = text.Split("-----");

                Console.WriteLine("Удалить сотрудника под номером : ");
                int idOfWorker = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(split[idOfWorker - 1]); 

            }
            ShowDBContent();

        }

    }

}



