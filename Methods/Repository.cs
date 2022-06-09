using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernNote
{
    struct Repository
    {
        #region fields
        private Worker[] workers;
        private string path;
        private int index;
        private string[] titles;

        #endregion

        /// <summary>
        /// Количество сотрудников
        /// </summary>
        public int Count { get { return this.index; } }

        #region Constructors
        public Worker this[int index]
        {
            get{return workers[index];}set{workers[index] = value;}
        }

        public Repository(string path)
        {
            this.path = path;
            this.index = 0;
            this.workers = new Worker[2];
            this.titles = new string[4];

        }
        #endregion
        #region methods
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.workers, this.workers.Length +1);
            }
        }


        public void Add(Worker ConcreteWorker)
        {
            this.Resize(index >= this.workers.Length);
            this.workers[index] = ConcreteWorker;
            this.index++;
        }

        public void Sort()
        {
            Load();
            Console.WriteLine("введи дату начала просмотра");
            int firstDay = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите конечную дату просмотра");
            int secondDay = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < workers.Length; i++)
            {
                for (int j = firstDay; j <= secondDay; j++)
                {
                    if (this.workers[i].Date == new DateTime(2022, 05, j))
                    {
                       Console.WriteLine(this.workers[i].Print());
                    }
                }
                    
            }
            
        }


        public void Load()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(';');
                    Add(new Worker(Convert.ToInt32(args[0]), args[1], args[2], Convert.ToDateTime(args[3])));
                }
            }
        }

        public void ShowConcreteWorker()
        {
            string key;
            Load();

                Console.Write("Введите номер сотрудника :");
                key = Console.ReadLine();
                int id = Convert.ToInt32(key);
                id--;
                Console.WriteLine(this.workers[id].Print());

        }

        public void PrintDbToConsole()
        {
/*            Console.WriteLine($"{this.titles[0]} {this.titles[1]} {this.titles[2]} {this.titles[3]}");*/

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.workers[i].Print());
            }

        }
        #endregion

    }
}
