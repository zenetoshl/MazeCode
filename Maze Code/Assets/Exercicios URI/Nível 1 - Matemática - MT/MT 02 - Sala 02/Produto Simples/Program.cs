using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produto_Simples
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, PROD;
            num1 = int.Parse(Console.ReadLine());
            num2 = int.Parse(Console.ReadLine());
            PROD = num1 * num2;
            Console.WriteLine("PROD = "+PROD);
        }
    }
}
