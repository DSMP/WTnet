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
        Int32[] tab = (Int32[])Array.CreateInstance(typeof(Int32), 1);
        int mainLastIndex = 0;
        public event EventHandler SizeChanged;
        public event EventHandler AddedNewValue;
        public void Add(int value)
        {
            this[++mainLastIndex] = value;
        }
        public int this[int index]
        {
            get
            {
                if (index > mainLastIndex && index < size - 1) // && index < size-1
                {
                    throw new IndexOutOfRangeException();
                }
                return Convert.ToInt32(tab.GetValue(index));
            }
            set
            {
                while (true)
                {
                    if (index < size - 1)
                    {
                        tab.SetValue(value, index);
                        OnAddNewValue(new MyEventArgs());
                        if (mainLastIndex < index)
                        {
                            InitializeSpaceBetweenLastIndexAndUserIndex(mainLastIndex, index);
                            mainLastIndex = index;
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
            OnAddMoreSpace(new MyEventArgs());
        }

        protected virtual void OnAddMoreSpace(MyEventArgs e)
        {
            if (SizeChanged != null)
            {
                e.Size = size;
                SizeChanged(this, e);
            }                
        }
        protected virtual void OnAddNewValue(MyEventArgs e)
        {
            if (AddedNewValue != null)
            {
                e.Size = size;
                AddedNewValue(this, e);
            }
            
        }
    }
}
