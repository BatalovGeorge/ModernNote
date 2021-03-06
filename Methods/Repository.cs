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
        #endregion

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

        public void RedactWorker()
        {
            PrintDbToConsole();

            Console.Write("Введите номер записи: ");
            uint input = Convert.ToUInt32(Console.ReadLine());
            input -= 1;

            if(input <= workers.Length-1)
            {
                Console.WriteLine("Введите имя: ");
                workers[input].Name = Console.ReadLine();
                Console.WriteLine("Введите город: ");
                workers[input].City = Console.ReadLine();
                workers[input].Date = DateTime.Now;
            }
            else { Console.WriteLine($"запись под номером {input} отсутствует"); }
        }

        public void SaveChanges()
        {
            using (StreamWriter sw = new StreamWriter(this.path))
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    sw.WriteLine(workers[i].Print());
                }

            }
        }

        private void Sort()
        {
            for(int i =0; i<this.workers.Length; i++)
            {
                for (int j = 0; j < this.workers.Length-1; j++)
                {
                    if (this.workers[j].Date > this.workers[j + 1].Date)
                    {
                        DateTime t = this.workers[j + 1].Date;
                        this.workers[j + 1].Date = this.workers[j].Date;
                        this.workers[j].Date = t;
                    }
                }
            }
        }

        public void Delete()
        {
            var firstWorker = this.workers[1];
            var lastWorker = this.workers[workers.Length - 1];
            this.workers[1] = lastWorker;
            this.workers[workers.Length - 1] = firstWorker;
            Array.Resize(ref this.workers, this.workers.Length - 1);
            Sort();
            WorkersID();
            index--;
        }

        public void WorkersID()
        {
            int id = 1;
                for (int i = 0; i < this.workers.Length; i++)
                {
                    this.workers[i].Id = id;
                    id++;
                }
        }

        private void Add(Worker ConcreteWorker)
        {
            this.Resize(index >= this.workers.Length);
            this.workers[index] = ConcreteWorker;
            this.index++;
        }

        public void ReverseDates()
        {
            
            Array.Reverse(workers);
            PrintDbToConsole();
        }

        public void SortByInputDates()
        {
            Console.WriteLine("введите месяц");
            uint month = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("введи дату начала просмотра");
            uint firstDay = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("введите конечную дату просмотра");
            uint secondDay = Convert.ToUInt32(Console.ReadLine());

            DateTime dt1 = DateTime.Parse($"{firstDay}.{month}.2022");
            DateTime dt2 = DateTime.Parse($"{secondDay}.{month}.2022");

            for (int i = 0; i < workers.Length; i++)
            {
                if ((dt1.Date <= this.workers[i].Date) && (dt2.Date >= this.workers[i].Date ) )
            {
                    Console.WriteLine(this.workers[i].Print());
            }/*else { Console.WriteLine("Введена некорректная дата"); }*/
            }
        }

        public void Load()
        {
            /*this.path = path;*/
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
