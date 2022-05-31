using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernNote
{
    public class Program
    {

        public static void Main(string[] args)
        {
            /*            AddOrDeleteWorker work1 = new AddOrDeleteWorker();
            *//*            Repository rep1 = new Repository();

                        WorkerManipulation worker = new WorkerManipulation();
                        worker.CheckFile();
            *//*
                        Console.WriteLine(work1.ShowDBToConsole());*/
            Menu menu = new Menu();
            menu.ShowMenu();

        }
    }
}
