using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seleção_emVetor1
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] vetorA;
            vetorA = new float[10];
            for(int i = 0; i < 10; i++)
            {
                vetorA[i] = float.Parse(Console.ReadLine());
            }
            for(int i = 0; i < 10; i++)
            {
                if(vetorA[i] <= 10)
                {
                    Console.WriteLine("A["+i+"] = "+vetorA[i]);
                }
            }
        }
    }
}
