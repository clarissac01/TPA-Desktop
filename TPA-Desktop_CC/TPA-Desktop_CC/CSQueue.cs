using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA_Desktop_CC
{
    public class CSQueue
    {
        private static CSQueue Instance;
        public string queueno = "";
        public string uniquequeue = "";

        public static CSQueue getInstance()
        {
            if(Instance == null)
            {
                Instance = new CSQueue();
            }
            return Instance;
        }

        private CSQueue() 
        {
        }

        public void setValue(string queueno, string uniquequeue)
        {
            this.queueno = queueno;
            this.uniquequeue = uniquequeue;
        }

        public void erase()
        {
            this.queueno = "";
            this.uniquequeue = "";
        }

    }



}
