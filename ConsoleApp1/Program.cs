using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoiskMaxMin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> n = new List<int> { 100000, 200000, 300000, 400000, 500000 };
            double timeWork = 0;
            int loadcapacity = 600000;
            int minweight = 1;
            int maxweight = 10;            
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            foreach (int k in n)
            {
                Console.WriteLine("----------     Количество элементов массива {0}    ---------- ", k);
                int[] mas = new int[k];

                //средний случай
                Random rand = new Random();
                for (int i = 0; i < mas.Length; i++)
                    mas[i] = rand.Next(minweight, maxweight + 1);

                // лучший случай
                //for (int i = 0; i < mas.Length - 1; i++)
                //    mas[i] = maxweight;

                // худший случай
                //for (int i = 0; i < mas.Length - 1; i ++)
                //    mas[i] = minweight;

                timeWork = 0;
                for (int j = 1; j <= 1000; j++)
                {
                    int Weight = 0;
                    // подготавливаем секундомер к новому измерению
                    sw.Reset();
                    //засекаем время начала работы алгоритма
                    sw.Start();
                    for (int i = 0; i < mas.Length; i++)
                    {
                        if (Weight <= loadcapacity)
                        {
                            Weight += mas[i];
                        }
                        else
                        { 
                            break; 
                        }
                    }
                    sw.Stop();
                    timeWork = timeWork + sw.ElapsedMilliseconds;
                }
                timeWork = timeWork / 10;
                Console.WriteLine("Время работы алгоритма  {0}", timeWork);                
            }
            Console.ReadLine();
        }
    }
}
