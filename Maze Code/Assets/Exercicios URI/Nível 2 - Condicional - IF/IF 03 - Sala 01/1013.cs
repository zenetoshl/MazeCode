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
             string[] linha = Console.ReadLine().Replace(".", ",").Split(' ');
            int a = Convert.ToInt32(linha[0]);
            int b = Convert.ToInt32(linha[1]);
            int c = Convert.ToInt32(linha[2]);
            if (a > b)//a
            {
                if (a > c)
                    Console.WriteLine("{0} eh o maior", a);
            }
            if (b > a) //b
            {
                if (b > c)
                    Console.WriteLine("{0} eh o maior", b);
            }
            if (c > a)//c
            {
                if (c > b)
                    Console.WriteLine("{0} eh o maior", c);
            }
        }
    }
}
