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
            myTab.Add(20);
            myTab.Add(21);
            myTab.Add(22);
            myTab.Add(23);
            myTab.Add(24);
            myTab.Add(25);
            Console.WriteLine(myTab[4]);
            Console.WriteLine(myTab[5]);
            Console.WriteLine(myTab[6]);
            Console.WriteLine(myTab[7]);
            Console.WriteLine(myTab[8]);
            Console.WriteLine(myTab[9]);
            //Console.WriteLine(myTab[1]);
            //Console.WriteLine(myTab[2]);
            //Console.WriteLine(myTab[3]);
            //Console.WriteLine(myTab[4]);
            Console.ReadKey();
        }
    }
}
