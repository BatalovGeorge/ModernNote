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
        private string path;
        public Menu(string path)
        {
            this.path = "data";
            this.Repository = new Repository(path);
            this.DataBase = new CreateDB();
        }
        public void MenuList()
        {
            Repository.Load();

            bool repeatMenu = true;
            while (repeatMenu)
            {
                Console.WriteLine(
                    "1 - создание файла; " +
                    "\n2 - чтение файла; " +
                    "\n3 - редактирование файла;" +
                    "\n4 - вывод отдельного сотрудника; " +
                    "\n5 - сортировка; " +
                    "\n6 - удаление сотрудника; " +
                    "\ns - сохранение изменений; " +
                    "\nq - Выход ");
                string key = Console.ReadLine();

                

                switch (key)
                {
                    
                    case "1":
                        if (File.Exists(this.path))
                        {
                            Console.Write($"Файл {this.path} уже существует. Редактировать файл ? д/н");
                            key = Console.ReadLine();
                            if (key == "д")
                            {
                                Console.WriteLine("переход в файл для редактирования");
                                DataBase.Load(this.path);

                                continue;
                            }
                            else
                            {
                                DataBase.Load(this.path);
                                continue;
                            }
                        }
                        else
                        {
                            DataBase.Load(this.path);
                            continue;
                        }

                    case "2":
                        Repository.PrintDbToConsole();
                        continue;

                    case "3":
                        Repository.RedactWorker();
                        continue;

                    case "4":
                        Repository.ShowConcreteWorker();
                        continue;

                    case "5":
                        Repository.SortByInputDates();
                        Console.WriteLine(new string('-',15));
                        Console.ReadKey();
                        Repository.ReverseDates();
                        continue;

                    case "6":
                        Repository.Delete();
                        Repository.PrintDbToConsole();
                        continue;
                    case "s":
                        Repository.SaveChanges();
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
