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
            int a;
            int maior = 0;
            int pos = 1;
            for (int i = 1; i <= 100; i++)
            {
                a = Int32.Parse(System.Console.ReadLine().Trim());
                if (i == 1)
                {
                    maior = a;
                }
                else if (maior < a)
                {
                    maior = a;
                    pos = i;
                }
            }

            Console.Write("{0}\n{1}\n", maior, pos);
        }
    }
}
