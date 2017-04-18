using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2MyTab
{
    class MyTab
    {
        int size = 1;
        Int32[] tab = (Int32[])Array.CreateInstance(typeof(Int32),1);
        int MainLastIndex = 0;
        public void add(int value)
        {
            tab.SetValue(value, MainLastIndex);
        }
        public int this[int index]
        {
            get
            {
                if (index > MainLastIndex && index < size - 1) // && index < size-1
                {
                    throw new IndexOutOfRangeException();
                }
                return Convert.ToInt32(tab.GetValue(index));
            }
            set
            {
                while (true)
                {
                    if (index < size-1)
                    {
                        tab.SetValue(value, index);
                        if (MainLastIndex < index)
                        {
                            InitializeSpaceBetweenLastIndexAndUserIndex(MainLastIndex, index);
                            MainLastIndex = index;
                        }
                        return;
                    }
                    else
                    {
                        AddMoreSpace();
                    }
                }
            }
        }

        private void InitializeSpaceBetweenLastIndexAndUserIndex(int mainLastIndex, int index)
        {
            while (mainLastIndex < index)
            {
                tab[mainLastIndex] = 0;
                mainLastIndex++;
            }
        }
        
        

        private void AddMoreSpace()
        {
            size *= 2;
            Array.Resize<Int32>(ref tab, size);
        }
    }
}
