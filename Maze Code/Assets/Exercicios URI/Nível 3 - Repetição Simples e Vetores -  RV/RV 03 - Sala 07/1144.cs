/*
  Link: https://www.urionlinejudge.com.br/judge/pt/problems/view/1144
  URI - Problema 1144: Sequência Lógica
  ------------------------------------------------------------------------------
  Sala 07
  Código: RV 03
*/

using System;

class URI {

    static void Main(string[] args) {

        int n = int.Parse(Console.ReadLine());
        for (int i=1; i<=n; i++){
            Console.WriteLine(i + " " + i*i + " " + i*i*i);
            Console.WriteLine(i + " " + ((i*i)+1) + " " + ((i*i*i)+1));
        }
    }
}
