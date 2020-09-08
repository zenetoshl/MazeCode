using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acima_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            string T;
            bool result;
            int soma = 0;
            float media = 0;
            int[,] matriz = new int[12, 12];
            T = Console.ReadLine();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    matriz[i, j] = int.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if(j > i)
                    {
                        soma = soma + matriz[i, j];
                        media = soma / 66;
                    }
                }
            }
            if (result = T.Equals("S"))
            {
                Console.WriteLine(soma);
            }
            else if (result = T.Equals("M"))
            {
                Console.WriteLine(media);
            }
        }
    }
}
