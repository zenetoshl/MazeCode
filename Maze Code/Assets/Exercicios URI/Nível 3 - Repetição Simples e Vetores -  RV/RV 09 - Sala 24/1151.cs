using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uriMazeCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(System.Console.ReadLine().Trim());
            int[] b;
            b = new int[a];
            b[0] = 0;
            b[1] = 1;
            for (int i = 0; i < a; i++)
            {
                if(i < 2)
                {
                    Console.Write("{0} ", b[i]);
                }
                else
                {
                    b[i] = b[i - 1] + b[i - 2];
                    if(i != a-1)
                        Console.Write("{0} ", b[i]);
                    else
                        Console.WriteLine("{0}", b[i]);
                }
            }
        }
    }
}
