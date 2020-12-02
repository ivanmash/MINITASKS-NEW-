using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Машкарин_Иван_Практика4
{
    class Program
    {
        static void Main(string[] args)
        {
            _Queue<int> mass = new _Queue<int>();
            bool s = true; int h;
            Console.WriteLine(@"
Введите:
1, чтобы добавить значение;
2, чтобы вывести количество элементов в очереди;
3, чтобы получить первый элемент очереди с его удалением;
4, чтобы очистить очередь;
5, чтобы посмотреть последний элемент очереди
6, чтобы прекратить работу с очередью.");
            while(s)
            {
                h = int.Parse(Console.ReadLine());
                switch(h)
                {
                    case (1): h = int.Parse(Console.ReadLine()); mass._Enqueue(h); break;
                    case (2): Console.WriteLine(mass.Count); break;
                    case (3): try { Console.WriteLine(mass._Dequeue()); } catch { Console.WriteLine("Очередь не имеет значений."); } break;
                    case (4): mass._Clear(); break;
                    case (5): try { Console.WriteLine(mass._Peek()); } catch { Console.WriteLine("Очередь не имеет значений."); } break;
                    case (6): s = false; break;
                    default:  Console.WriteLine("Введено неверное значение, введите число от 1 до 6"); break;
                }
            }
            Console.ReadKey();
        }
    }
}
