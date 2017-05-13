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
            MyProgram myProgram = new MyProgram();
        }

    }
    class MyProgram
    {
        public MyProgram()
        {
            SyncTab myTab = new SyncTab();

            myTab.SizeChanged += MyTab_SizeChanged; // to musi isc na zewnatrz
            myTab.AddedNewValue += MyTab_AddedNewValue;
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

        private void MyTab_AddedNewValue(object sender, EventArgs e)
        {
            Console.WriteLine("Dodano nową wartość");
        }

        void MyTab_SizeChanged(object sender, EventArgs e)
        {
            Console.WriteLine("powiekszono tablice. Aktualny rozmiar to: " + ((MyEventArgs)e).Size);
        }
    }

}
