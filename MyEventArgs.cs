using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2MyTab
{
    class MyEventArgs : EventArgs
    {
        public int Size
        {
            get
            {
                return Size;
            }

            set
            {
                Size = value;
            }
        }
    }
}
