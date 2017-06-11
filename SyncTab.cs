using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zad2MyTab
{
    class SyncTab : MyTab
    {
        String fileName;
        Object MySelfRef;
        public SyncTab()
        {
            MySelfRef = this;
        }

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value.ToString();
            }
        }

        public void WriteToFile()
        {
            if (!File.Exists(this.fileName))
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    for (int i = 0; i < MainLastIndex+1; i++)
                    {
                        sw.WriteLine(this[i].ToString());
                    }
                }
            }
        }

        public void addBlokujaca(int value)
        {
            Monitor.Enter(MySelfRef);
            try
            {
                this.Add(value);
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }finally
            {
                Monitor.Exit(MySelfRef);
            }
        }

        public bool addNieBlokujaca(int value, int timeMs)
        {
            if (!Monitor.TryEnter(MySelfRef, timeMs))
            {
                return false;
            }
            try
            {
                this.Add(value);
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            finally
            {
                Monitor.Exit(MySelfRef);
            }
            return true;
        }
    }
}
