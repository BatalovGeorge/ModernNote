using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernNote
{
    struct Menu
    {
        private CreateDB DataBase;
        private Repository Repository;

        
        public void MenuList()
        {
            string input = "data";
            bool repeatMenu = true;
            while (repeatMenu)
            {
                Console.WriteLine(
                    "1 - создание файла;" +
                    "\n2 - чтение файла;" +
                    "\n3 - редактирование файла;" +
                    "\n4 - вывод отдельного сотрудника;" +
                    "\n5 - сортировка по датам; " +
                    "\nq - Выход");
                string key = Console.ReadLine();
                

                switch (key)
                {

                    case "1":
                        if (File.Exists(input))
                        {
                            Console.Write($"Файл {input} уже существует. Редактировать файл ? д/н");
                            key = Console.ReadLine();
                            if (key == "д")
                            {
                                Console.WriteLine("переход в файл для редактирования");
                                DataBase.Load(input);

                                continue;
                            }
                            else
                            {
                                DataBase.Load(input);
                                continue;
                            }
                        }
                        else
                        {
                            DataBase.Load(input);
                            continue;
                        }

                    case "2":

                        Repository = new Repository(input);
                        Repository.Load();
                        Repository.PrintDbToConsole();
                        continue;

                    case "3":
                        Repository = new Repository(input);
                        Repository.RedactWorker();
                        continue;

                    case "4":
                        Repository = new Repository(input);
                        Repository.ShowConcreteWorker();
                        continue;

                    case "5":
                        Repository = new Repository(input);
                        Repository.SortByDates();
                        /*Repository.ReverseDates();*/
                        continue;

                    case "q":
                        repeatMenu = false;
                        Console.WriteLine("Досвидания!");
                        break;

                    default:
                        repeatMenu = true;
                        Console.WriteLine("Нет такого пункта.");
                        continue;
                }
            }

        }
    }
}
