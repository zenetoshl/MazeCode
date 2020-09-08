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
            
            string[] linha1 = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(linha1[0]);
            int b = Convert.ToInt32(linha1[1]);
            int resto = b % a;
            int resto2 = a % b;
            if(resto == 0 || resto2 == 0)
            {
                Console.WriteLine("Sao Multiplos");
            }
            else
            {
                Console.WriteLine("Nao sao Multiplos");
            }
        }
    }
}
