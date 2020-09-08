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

            string[] linha1 = Console.ReadLine().Replace(".", ",").Split(' ');
            double x = Convert.ToDouble(linha1[0]);
            double y = Convert.ToDouble(linha1[1]);
            if(x > 0)
            {
                if (y > 0)
                {
                    Console.WriteLine("Q1");
                }
                else if (y < 0)
                {
                    Console.WriteLine("Q4");
                }
                else
                {
                    Console.WriteLine("Eixo Y");
                }
            }
            else if(x < 0)
            {
                if(y > 0)
                {
                    Console.WriteLine("Q2");
                }
                else if(y < 0)
                {
                    Console.WriteLine("Q3");
                }
                else
                {
                    Console.WriteLine("Eixo X");
                }
            }
            else
            {
                if (y == 0)
                {
                    Console.WriteLine("Origem");
                }
                else
                {
                    Console.WriteLine("Eixo Y");
                }
            }
        }
    }
}
