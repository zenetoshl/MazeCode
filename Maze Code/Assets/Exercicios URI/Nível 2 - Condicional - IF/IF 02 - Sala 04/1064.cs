/*
  Link: https://www.urionlinejudge.com.br/judge/pt/problems/view/1064
  URI - Problema 1064: Positivos e Média
  ------------------------------------------------------------------------------
  Sala 04
  Código: IF 02
*/

using System;

class URI {

  static void Main(string[] args) {

    double A;
    double B;
    double C;
    double D;
    double E;
    double F;
    double media;
    double positivo = 0;
    double totalPositivos = 0;

    A = double.Parse(Console.ReadLine());
    B = double.Parse(Console.ReadLine());
    C = double.Parse(Console.ReadLine());
    D = double.Parse(Console.ReadLine());
    E = double.Parse(Console.ReadLine());
    F = double.Parse(Console.ReadLine());

    if (A > 0){
      totalPositivos = A;
      positivo++;
    }

    if (B > 0){
      totalPositivos = totalPositivos + B;
      positivo++;
    }

    if (C > 0){
      totalPositivos = totalPositivos + C;
      positivo++;
    }

    if (D > 0){
      totalPositivos = totalPositivos + D;
      positivo++;
    }

    if (E > 0){
      totalPositivos = totalPositivos + E;
      positivo++;
    }

    if (F > 0){
      totalPositivos = totalPositivos + F;
      positivo++;
    }

    media = (double)totalPositivos / positivo;
    Console.WriteLine(positivo + " valores positivos");
    Console.WriteLine(media.ToString("#0.0"));

  }

}
