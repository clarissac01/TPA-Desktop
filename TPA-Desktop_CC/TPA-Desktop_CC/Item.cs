using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA_Desktop_CC
{
    public class Item
    {
        public string itemid;
        public string itemname;
        public string itemstatus;
        public string employee;

        public Item(string id, string name, string status, string emp)
        {
            this.itemid = id;
            this.itemname = name;
            this.itemstatus = status;
            this.employee = emp;
        }

    }
}
