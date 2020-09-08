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
        {//|b-c|<a<b+c

            string[] linha1 = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(linha1[0]);
            int b = Convert.ToInt32(linha1[1]);
            int c = Convert.ToInt32(linha1[2]);
            int d = Convert.ToInt32(linha1[3]);
            if(b > c)
            {
                if(d > a)
                {
                    int cd = c + d;
                    int ab = a + b;
                    if(cd > ab)
                    {
                        if (c > 0)
                        {
                            if (d > 0)
                            {
                                int resto = a % 2;
                                if(resto == 0)
                                {
                                    Console.WriteLine("Valores aceitos");
                                }
                                else Console.WriteLine("Valores nao aceitos");
                            }
                            else Console.WriteLine("Valores nao aceitos");
                        }
                        else Console.WriteLine("Valores nao aceitos");
                    }
                    else Console.WriteLine("Valores nao aceitos");
                }
                else Console.WriteLine("Valores nao aceitos");
            }
            else Console.WriteLine("Valores nao aceitos");
        }
    }
}
