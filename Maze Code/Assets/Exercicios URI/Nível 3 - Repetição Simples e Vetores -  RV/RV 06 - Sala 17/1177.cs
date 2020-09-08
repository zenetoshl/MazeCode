/*
  Link: https://www.urionlinejudge.com.br/judge/pt/problems/view/1177
  URI - Problema 1177: Preenchimento de Vetor II
  ------------------------------------------------------------------------------
  Sala 17
  Código: RV 06
*/

using System;

class URI {

  static void Main(string[] args) {

    int numero = int.Parse(Console.ReadLine());
    int contador = 0;
    for (int n = 0; n < 1000; n++) {
      if (contador < numero){
        Console.WriteLine("N[" + n + "] = " + contador);
      }
      else {
        contador = 0;
        Console.WriteLine("N[" + n + "] = " + contador);
      }
      contador++;
    }

  }

}
