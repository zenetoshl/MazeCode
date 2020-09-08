using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Número_de_Positivos
{
    class Program
    {
        static void Main(string[] args)
        {
            float num1, num2, num3, num4, num5, num6;
            int contador = 0;
            num1 = float.Parse(Console.ReadLine());
            num2 = float.Parse(Console.ReadLine());
            num3 = float.Parse(Console.ReadLine());
            num4 = float.Parse(Console.ReadLine());
            num5 = float.Parse(Console.ReadLine());
            num6 = float.Parse(Console.ReadLine());

            if(num1 >= 0)
            {
                contador = contador + 1;
            }
            if (num2 >= 0)
            {
                contador = contador + 1;
            }
            if (num3 >= 0)
            {
                contador = contador + 1;
            }
            if (num4 >= 0)
            {
                contador = contador + 1;
            }
            if (num5 >= 0)
            {
                contador = contador + 1;
            }
            if (num6 >= 0)
            {
                contador = contador + 1;
            }
            Console.WriteLine(contador+" valores positivos");
        }
    }
}
