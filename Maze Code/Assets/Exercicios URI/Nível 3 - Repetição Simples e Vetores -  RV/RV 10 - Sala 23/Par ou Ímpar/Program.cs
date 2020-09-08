using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Par_ou_Ímpar
{
    class Program
    {
        static void Main(string[] args)
        {
            int N, num;
            N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                num = int.Parse(Console.ReadLine());
                if (num == 0)
                {
                    Console.WriteLine("NULL");
                }
                else if (num % 2 == 0)
                {
                    Console.Write("EVEN");
                }
                if(num % 2 != 0)
                {
                    Console.Write("ODD");
                }
                if(num > 0)
                {
                    Console.WriteLine(" POSITIVE");
                }
                if(num < 0)
                {
                    Console.WriteLine(" NEGATIVE");
                }
            }
        }
    }
}
