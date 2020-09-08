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

            //string[] linha1 = Console.ReadLine().Replace(".", ",").Split(' ');
            int a = Convert.ToInt32(Console.ReadLine());
            char b = Convert.ToChar(Console.ReadLine());
            double[,] mat;
            double sum = 0;
            mat = new double[12, 12];
            for (int j = 0; j < 12; j++)
            {
                for (int k = 0; k < 12; k++)
                {
                    mat[j, k] = Convert.ToDouble(Console.ReadLine());
                    if (k == a)
                    {
                        sum = sum + mat[j, k];
                    }
                }
            }
            if (b == 'S')
            {
                Console.WriteLine("{0:0.0}", sum);
            }
            else
            {
                double result = sum / 12;
                Console.WriteLine("{0:0.0}", result);
            }
        }
    }
}
