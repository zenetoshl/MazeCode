/*
  Link: https://www.urionlinejudge.com.br/judge/pt/problems/view/1015
  URI - Problema 1015: Distância entre dois pontos
  ------------------------------------------------------------------------------
  Sala 03
  Código: MT 03
*/

using System;

class URI {

  static void Main(string[] args) {

    string entrada1 = Console.ReadLine();
    string[] valor1 = entrada1.Split(' ');
    double x1 = double.Parse(valor1[0]);
    double y1 = double.Parse(valor1[1]);

    string entrada2 = Console.ReadLine();
    string[] valor2 = entrada2.Split(' ');
    double x2 = double.Parse(valor2[0]);
    double y2 = double.Parse(valor2[1]);

    string distancia = (Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2))).ToString("#0.0000");

    Console.WriteLine(distancia);
  }

}
