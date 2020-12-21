using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA_Desktop_CC
{
    public class Customer
    {
        public string accountnumber { get; set; }
        public string pin;
        public string name;
        public string identitycard;
        public string familycard;
        public int balance;
        public string type;

        public Customer(string accnumber, string pin, string nama, string idcard, string fcard, int balance, string type)
        {
            this.accountnumber = accnumber;
            this.pin = pin;
            this.name = nama;
            this.identitycard = idcard;
            this.familycard = fcard;
            this.balance = balance;
            this.type = type;
        }

    }
}
