using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernNote
{
    struct Repository
    {
        private Worker[] Workers;

        public int ID()
        {
            Console.WriteLine("Введите номер: ");
            string id = Console.ReadLine();
            int idNum = Convert.ToInt32(id);
            return idNum - 1 ;
        }
        public string WorkerSeparate()
        {
            string workerData;
            using (StreamReader sR = new StreamReader("workerData.txt"))
            {
                workerData = sR.ReadToEnd();
            }

            return workerData;
        }
        public string EachWorker()
        {
            string[] separate = WorkerSeparate().Split("---------------");

            return separate[ID()];
        }

        public Worker this[int index]
        {
            get { return Workers[index]; }
            set { Workers[index] = value; }
        }

        public Repository(params Worker[] Args)
        {
            Workers = Args;
        }
    }
}
