﻿using System;
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
            var human = new Worker(IDNum(),Console.ReadLine(),Console.ReadLine());
            return human.Print();
        }
        public int IDNum()
        {
            string text = String.Empty;
            using (StreamReader sR = new StreamReader("workerData.txt"))
            {
                text = sR.ReadToEnd();
            }
            string[] splitNum = text.Split("Номер:");
            int id = splitNum.Length;

            return id;
        }
        public string[] StrWrite()
        {
            string[] spl = WorkerData().Split(';');
            using (StreamWriter sW = new StreamWriter("workerData.txt", true))
                foreach (var e in spl)
                {
                    sW.WriteLine(e);
                }
            return spl;
        }
        public string ShowData()
        {
            using (StreamReader sR = new StreamReader("workerData.txt"))
            {
                return sR.ReadToEnd();
            }
        }

        public string DeleteWorker()
        {
            string data = ShowData();
            string deleteNum = "3";
            if (data.Contains($"Номер: {deleteNum}"))
            {
                int num = Convert.ToInt32(deleteNum);
                string[] splt = data.Split(";");
                splt[num] = "deleted";
                StreamWriter streamWriter = new StreamWriter("workerData.txt", true);
                streamWriter.WriteLine();
                streamWriter.Close();


            }
                return data;
        }

    }
}
