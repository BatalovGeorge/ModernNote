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
            WorkerManipulation work1 = new WorkerManipulation();

            Repository readFile = new Repository();
            Console.WriteLine(readFile.EachWorker());

/*            Console.WriteLine(work1.StrWrite());
            Console.WriteLine(work1.ShowData());*//*
            Console.WriteLine(work1.DeleteWorker());*/
        }
    }
}
