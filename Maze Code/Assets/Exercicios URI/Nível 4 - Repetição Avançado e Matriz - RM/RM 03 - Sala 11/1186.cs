/*
  Link: https://www.urionlinejudge.com.br/judge/pt/problems/view/1186
  URI - Problema 1186: Abaixo da diagonal secundária
  ------------------------------------------------------------------------------
  Sala 11
  Código: RM 03
*/

using System;

class URI {

  static void Main(string[] args) {

    double a = 0.0;
    double[,] M = new double[12, 12];
    int p = 11;
    string operacao = Console.ReadLine();

    //Preencher matriz
    for (int i=0; i<=11; i++)
    {
      for (int j = 0; j <= 11; j++)
      {
        M[i, j] = double.Parse(Console.ReadLine());
      }
    }

    for (int i = 1; i <= 11; i++)
    {
      for (int j = 11; j >= p; j--)
      {
        a = a + M[i, j];
      }
      p--;
    }

    if (operacao.Equals("S"))
    {
      Console.WriteLine(a.ToString("#0.0"));
    } else if (operacao.Equals("M"))
    {
      a = a / 66.0;
      Console.WriteLine(a.ToString("#0.0"));
    }

  }

}
