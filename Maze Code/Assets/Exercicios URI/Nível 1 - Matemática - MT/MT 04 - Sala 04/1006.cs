/*
  Link: https://www.urionlinejudge.com.br/judge/pt/problems/view/1006
  URI - Problema 1006: Média 2
  ------------------------------------------------------------------------------
  Sala 04
  Código: MT 04
*/

using System;

class URI {

  static void Main(string[] args) {

    double a, b, c, media;
    a = double.Parse(Console.ReadLine());
    b = double.Parse(Console.ReadLine());
    c = double.Parse(Console.ReadLine());

    media = ((a / 10 * 2) + (b / 10 * 3) + (c / 10 * 5));

    Console.WriteLine("MEDIA = " + media.ToString("0.0"));
  }
}
