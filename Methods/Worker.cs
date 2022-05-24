using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernNote
{
    public struct Worker
    {
        private int id;
        private string name, city;
        private DateTime date;

        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public DateTime Date { get => date; set => date = DateTime.Now; }
        public int Id { get => id; set => id = value; }

        public Worker(int id, string Name, string City)
        {
            this.id = id;
            this.name = Name;
            this.city = City;
            this.date = DateTime.Now;
        }
        public Worker(int id, string Name) : this(id, Name, String.Empty)
        {

        }
        public Worker(int id) : this(id, String.Empty, String.Empty)
        {

        }
        public string Print()
        {
            return $"Номер: {Id};Имя: {Name};Город: {City};Дата: {Date.ToShortDateString()};" ;
        }


    }
}
