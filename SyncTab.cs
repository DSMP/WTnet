using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zad2MyTab
{
    class SyncTab : MyTab
    {
        Object MySelfRef;
        public SyncTab()
        {
            MySelfRef = this;
        }

        public void addBlokujaca(int value)
        {
            Monitor.Enter(MySelfRef);
            this.Add(value);
            Monitor.Exit(MySelfRef);
        }

        public bool addNieBlokujaca(int value)
        {
            if (!Monitor.TryEnter(MySelfRef))
            {
                return false;
            }
            this.Add(value);
            Monitor.Exit(MySelfRef);
            return true;
        }
    }
}
