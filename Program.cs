using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zad2MyTab
{
    class Program
    {
        static void Main(string[] args)
        {
            SyncTab newTab = new SyncTab();
            MyProgram myProgram = new MyProgram(newTab);
            MyProgram myProgram2 = new MyProgram(newTab);
            Thread FirstThread = new Thread(new ThreadStart(myProgram.MyProgramFun));
            Thread SecondThread = new Thread(new ThreadStart(myProgram2.MyProgramFun));
            FirstThread.Start();
            SecondThread.Start();
            SecondThread.Join();
            FirstThread.Join();
            Console.ReadKey();
            Thread FirstThread1 = new Thread(new ThreadStart(myProgram.TestNieBlokujacych));
            Thread SecondThread1 = new Thread(new ThreadStart(myProgram2.TestNieBlokujacych));
            FirstThread1.Start();
            SecondThread1.Start();
            SecondThread1.Join();
            FirstThread1.Join();
            Console.ReadKey();
        }

    }
    class MyProgram
    {
        SyncTab MyTab;
        static int sId = 0;
        int Id = 0;
        public MyProgram(SyncTab myTab)
        {
            MyTab = myTab;
            Id = ++sId;
        }

        public void TestNieBlokujacych()
        {
            MyTab.SizeChanged += MyTab_SizeChanged; // to musi isc na zewnatrz
            MyTab.AddedNewValue += MyTab_AddedNewValue;
            MyTab[3] = 10;
            MyTab.addNieBlokujaca(20);
            MyTab.addNieBlokujaca(21);
            MyTab.addNieBlokujaca(22);
            MyTab.addNieBlokujaca(23);
            MyTab.addNieBlokujaca(24);
            MyTab.addNieBlokujaca(25);
            Console.WriteLine("{0}: {1}", Id, MyTab[10]);
            Console.WriteLine("{0}: {1}", Id, MyTab[11]);
            Console.WriteLine("{0}: {1}", Id, MyTab[12]);
            Console.WriteLine("{0}: {1}", Id, MyTab[13]);
            Console.WriteLine("{0}: {1}", Id, MyTab[14]);
            Console.WriteLine("{0}: {1}", Id, MyTab[15]);
        }

        public void MyProgramFun()
        {

            MyTab.SizeChanged += MyTab_SizeChanged; // to musi isc na zewnatrz
            MyTab.AddedNewValue += MyTab_AddedNewValue;
            MyTab[3] = 10;
            MyTab.addBlokujaca(20);
            MyTab.addBlokujaca(21);
            MyTab.addBlokujaca(22);
            MyTab.addBlokujaca(23);
            MyTab.addBlokujaca(24);
            MyTab.addBlokujaca(25);
            Console.WriteLine("{0}: {1}", Id, MyTab[4]);
            Console.WriteLine("{0}: {1}", Id, MyTab[5]);
            Console.WriteLine("{0}: {1}", Id, MyTab[6]);
            Console.WriteLine("{0}: {1}", Id, MyTab[7]);
            Console.WriteLine("{0}: {1}", Id, MyTab[8]);
            Console.WriteLine("{0}: {1}", Id, MyTab[9]);
            MyTab.SizeChanged -= MyTab_SizeChanged;
            MyTab.AddedNewValue -= MyTab_AddedNewValue;
            //Console.WriteLine(myTab[1]);
            //Console.WriteLine(myTab[2]);
            //Console.WriteLine(myTab[3]);
            //Console.WriteLine(myTab[4]);
        }

        private void MyTab_AddedNewValue(object sender, EventArgs e)
        {
            Console.WriteLine(Id + " Dodano nową wartość");
        }

        void MyTab_SizeChanged(object sender, EventArgs e)
        {
            Console.WriteLine(Id + " Powiekszono tablice. Aktualny rozmiar to: " + ((MyEventArgs)e).Size);
        }
    }

}
