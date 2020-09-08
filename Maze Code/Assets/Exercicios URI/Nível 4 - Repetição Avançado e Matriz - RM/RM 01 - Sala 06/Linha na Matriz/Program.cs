using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linha_na_Matriz
{
    class Program
    {
        static void Main(string[] args)
        {
            int L;
            string T;
            bool result;
            int soma = 0;
            float media = 0;
            int[,]matriz = new int[12,12];
            L = int.Parse(Console.ReadLine());
            T = Console.ReadLine();

            for(int i = 0; i < 12; i++)
            {
                for(int j = 0; j < 12; j++)
                {
                    matriz[i,j] = int.Parse(Console.ReadLine());
                }
            }
            for(int j = 0; j < 12; j++)
            {
                soma = soma + matriz[L, j];
                media = (float)soma / 12;
            }
            if(result = T.Equals("s"))
            {
                Console.WriteLine(soma);
            }
            else if(result = T.Equals("m"))
            {
                Console.WriteLine(media);
            }
        }
    }
}
