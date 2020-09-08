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
            int b = Convert.ToInt32(Console.ReadLine());
            while (b != 0)
            {
                double[,] mat;
                mat = new double[b, b];
                for (int j = 0; j < b; j++)
                {
                    for (int k = 0; k < b; k++)
                    {
                        double val = j + k;
                        mat[j, k] = Math.Pow(2, val);
                        if (k == b - 1)
                        {
                            Console.WriteLine("{0}", mat[j,k]);
                        } else Console.Write("{0} ", mat[j, k]);
                    }
                }
                Console.WriteLine();
                b = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
