using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2MyTab
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTab myTab = new MyTab();
            myTab[3] = 10;
            Console.WriteLine(myTab[1]);
            Console.WriteLine(myTab[2]);
            Console.WriteLine(myTab[3]);
            Console.WriteLine(myTab[4]);
            Console.ReadKey();
        }
    }
}
