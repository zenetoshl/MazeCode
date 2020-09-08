/*
  Link: https://www.urionlinejudge.com.br/judge/pt/problems/view/1036
  URI - Problema 1036: Fórmula de Bhaskara
  ------------------------------------------------------------------------------
  Sala 08
  Código: IF 04
*/

using System;

class URI {

  static void Main(string[] args) {

    double A, B, C, R1, R2, delta;
		string[] vet = Console.ReadLine().Split(' ');
		A = double.Parse(vet[0]);
    B = double.Parse(vet[1]);
    C = double.Parse(vet[2]);
    delta = (B * B) - (4 * A * C);
    R1 = (-B + Math.Sqrt(delta)) / (2 * A);
    R2 = (-B - Math.Sqrt(delta)) / (2 * A);

    if (delta < 0 || A == 0){
		  Console.WriteLine("Impossivel calcular");
		  Console.ReadLine();
		}
		else{
      Console.WriteLine("R1 = " + R1.ToString("f5"));
      Console.WriteLine("R2 = " + R2.ToString("f5"));
      Console.ReadLine();
		}

  }

}
