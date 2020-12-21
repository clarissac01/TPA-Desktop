using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA_Desktop_CC
{
    public class Employee
    {
        public string id;
        public string name;
        public string password;
        public int salary;
        public float rating;
        public int ratecount;

        public Employee(string id, string name, string password, int salary, float rating, int ratecount)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.salary = salary;
            this.rating = rating;
            this.ratecount = ratecount;
        }

    }


}
