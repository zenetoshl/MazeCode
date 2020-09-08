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
            int i = 1, j = 60;
            while(j != -5)
            {
                Console.WriteLine("I={0} J={1}", i, j);
                i = i + 3;
                j = j - 5;
            }
        }
    }
}
