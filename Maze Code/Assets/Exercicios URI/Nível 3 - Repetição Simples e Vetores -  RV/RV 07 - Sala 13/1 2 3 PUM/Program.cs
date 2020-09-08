using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_2_3_PUM
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            N = int.Parse(Console.ReadLine());
            for(int i = 1; i <= (N*4); i+=4)
            {
                Console.WriteLine(i+" "+(i+1)+" "+(i+2)+" PUM");
            }
        }
    }
}
