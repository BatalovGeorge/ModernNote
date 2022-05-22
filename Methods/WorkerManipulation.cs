using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernNote
{
    public struct WorkerManipulation
    {
        public string WorkerData()
        {
            var human = new Worker(IDNum(), "Ivan", "Moscow");
            string s1 = human.Print();
            return s1;
        }
        public int IDNum()
        {
            string text = String.Empty;
            using (StreamReader sR = new StreamReader("workerData.txt"))
            {
                text = sR.ReadToEnd();
            }
            string[] splitNum = text.Split("Номер:");
            int id = splitNum.Length - 1;

            return id;
        }
        public string[] StrWrite()
        {
            string[] spl = WorkerData().Split(';');
            using (StreamWriter sW = new StreamWriter("workerData.txt"))
                foreach (var e in spl)
                {
                    sW.WriteLine(e);
                }
            return spl;
        }
    }
}
