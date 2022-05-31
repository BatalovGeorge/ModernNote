using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernNote
{
     struct Menu
    {
        public WorkerManipulation manipulation;
        public AddOrDeleteWorker addOrDelete;
        public Menu(WorkerManipulation workerManipulation, AddOrDeleteWorker addOrDelete )
        {
            this.manipulation = workerManipulation;
            this.addOrDelete = addOrDelete;
        }

        public object ShowMenu()
        {
            Console.WriteLine("1-просмотр данных файла 2-добавление сотрудника 3-вывести отдельного сотрудника");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    addOrDelete = new AddOrDeleteWorker();
                    addOrDelete.ShowDBContent();
                    break;
                case "2":
                    addOrDelete = new AddOrDeleteWorker();
                    addOrDelete.ShoWorker();
                    break;

                case "3":
                    addOrDelete = new AddOrDeleteWorker();
                    addOrDelete.DeleteWorker();
                    break;
                default:return null;
            }
            return null;
        }

    }
}
