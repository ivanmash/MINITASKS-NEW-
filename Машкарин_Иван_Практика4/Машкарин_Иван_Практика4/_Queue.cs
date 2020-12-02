using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Машкарин_Иван_Практика4
{
    class _Queue<F>
    {
        F[] _array;
        int capacity;
        int head;
        int tail;
        int size;
        public _Queue()
        {
            _array = new F[1];
            capacity = 1;
            size = 0;
            tail = -1;
            head = 0;
        }
        public bool CHECK()
        {
            if (size == 0)
                return false;
            else
            return true;
        }
        public int Count
        {
            get
            {
                return size;
            }
        }
        public void _Enqueue(F h)
        {
                capacity++;
                size++;
                tail++;
                F[] _array1 = new F[size];
                Array.Copy(_array, _array1, tail);
                _array1[tail] = h;
                _array = new F[size];
                Array.Copy(_array1, _array, size);
        }
        public F _Dequeue()
        {
            if (CHECK() == false)
            {
                throw new Exception();
            }
                F h = _array[head];
            capacity--;
            size--;
            head++;
            return h;
        }
        public F _Peek()
        {
            if (CHECK() == false)
            {
                throw new Exception();
            }
            return _array[tail];
        }
        public void _Clear()
        {
            _array = new F[1];
            capacity = 1;
            size = 0;
            tail = -1;
            head = 0;
        }
    }
}
