using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernNote
{
    struct CreateDB
    {
        private Worker Worker;

        public void WorkerDB(int id, string path)
        {
            char key = 'д';
            do
            {
                Console.WriteLine($"Номер: {id}");
                Worker.Id = id;
                Console.WriteLine("Введите имя:");
                Worker.Name = Console.ReadLine();
                Console.WriteLine("Введите город:");
                Worker.City = Console.ReadLine();
                Worker.Date = DateTime.Now;
                id++;

                Console.WriteLine("Продолжить д/н");
                key = Console.ReadKey(true).KeyChar;

                AddData(path, Worker.Print());
            } while (char.ToLower(key) == 'д');
        }

        public int ID(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string[] split = sr.ReadToEnd().Split(";");
                return ((split.Length-1)/4);
            }
        }

        public void Load(string path)
        {
            if (File.Exists(path))
            {
                WorkerDB(ID(path)+1, path);
            }
            else { WorkerDB(1, path); }
        }

        public void AddData(string path, string text)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(text);
            }
        }
    }

}

