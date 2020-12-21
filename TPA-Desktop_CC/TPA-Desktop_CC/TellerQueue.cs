using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA_Desktop_CC
{
    public class TellerQueue
    {
        private static TellerQueue Instance;
        public string queueno = "";
        public string uniquequeue = "";

        public static TellerQueue getInstance()
        {
            if (Instance == null)
            {
                Instance = new TellerQueue();
            }
            return Instance;
        }

        private TellerQueue()
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
