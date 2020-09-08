/*
  Link: https://www.urionlinejudge.com.br/judge/pt/problems/view/1173
  URI - Problema 1173: Preenchimento de Vetor I
  ------------------------------------------------------------------------------
  Sala 16
  Código: RV 05
*/
using System;

class URI {

    static void Main(string[] args) {

        int n = Convert.ToInt32(Console.ReadLine());

        int[] input = new int[10];
        input[0] = n;
        for (int i = 1; i < 10; i++){
            input[i] = input[i-1] * 2;
        }
        for (int i = 0; i < 10; i++){
            Console.WriteLine("N[" + i + "] = " + input[i]);
        }
    }
}
