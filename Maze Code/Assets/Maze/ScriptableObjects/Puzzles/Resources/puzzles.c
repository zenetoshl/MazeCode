
//1
Leia 2 valores e armazene-os nas variaveis A e B. Efetue a soma de A e B e depois exiba o resultado.
//8 8 9 9 10 10 10 10 10
//2 2 1 1 0 0 0 0 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _loopLimit = 0;string _loopError = null; int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){_loopLimit = 0;_loopError = null;var a = 0;var b = 0;if(_inputs.Count > _i)a =  _inputs[_i++];if(_inputs.Count > _i)b =  _inputs[_i++];a = b+a;if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += a+ " ";}}}

//2
Leia dois valores. A seguir, calcule o produto entre estes dois valores e exiba o resultado.
//8 8 9 9 10 10 10 10 10
//2 2 1 1 0 0 0 0 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _loopLimit = 0;string _loopError = null; int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){_loopLimit = 0;_loopError = null;var a = 0;var b = 0;if(_inputs.Count > _i)a =  _inputs[_i++];if(_inputs.Count > _i)b =  _inputs[_i++];a = b*a;if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += a+ " ";}}}

//3
Leia um valor de ponto flutuante que representa o tamanho dos lados de um quadrado. A seguir, calcule a area deste quadrado.
//9 9 9 9 10 10 10 10 10
//1 1 1 1 0 0 0 0 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _loopLimit = 0;string _loopError = null; int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){_loopLimit = 0;_loopError = null;var a = 0.0;if(_Dinputs.Count > _j)a = _Dinputs[_j++];a = a*a;if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += a+ " ";}}}

//4
Leia 3 valores de ponto flutuante, que sao as tres notas de um aluno. A seguir, calcule a media das notas do aluno, sabendo que a nota A tem peso 2, a nota B tem peso 3 e a nota C tem peso 5. Considere que cada nota pode ir de 0 ate 10.
//7 7 9 4 10 10 10 10 10
//3 3 1 6 0 0 0 0 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _loopLimit = 0;string _loopError = null; int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){_loopLimit = 0;_loopError = null;var a = 0.0;var b = 0.0;var c = 0.0;if(_Dinputs.Count > _j)a = _Dinputs[_j++];if(_Dinputs.Count > _j)b = _Dinputs[_j++];if(_Dinputs.Count > _j)c = _Dinputs[_j++];a = a*2;b = b*3;c = c*5;a = a+b;a = a+c;a = a/10;if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += a+ " ";}}}

//5
Leia dois valores Float e exiba o maior.
//8 8 8 10 9 10 10 10 10
//2 2 2 0 1 0 0 0 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _loopLimit = 0;string _loopError = null; int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){_loopLimit = 0;_loopError = null;var a = 0;var b = 0;if(_inputs.Count > _i)a =  _inputs[_i++];if(_inputs.Count > _i)b =  _inputs[_i++];if( a>b ){if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += a+ " ";}else{if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += b+ " ";}}}}

//8
Leia 2 valores inteiros A e B. Após, imprima "0" caso A e B sejam multiplos e "1" caso não sejam.
//7 8 9 7 8 10 10 10 10
//3 2 1 3 2 0 0 0 0 
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){var a = 0;var b = 0;var c = 0;a =  _inputs[_i++];b =  _inputs[_i++];if( a>b ){c = a%b;}else{c = b%a;}if( c==0 ){}else{c = 1+0;}_output += c+ " ";}}}

//12
Leia 4 valores inteiros. Então, mostre a quantidade de valores positivos lidos. Estes valores serão somente negativos ou positivos.
//5 6 9 2 6 10 10 10 10
//5 4 1 8 4 0 0 0 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){var a = 0;var b = 0;var c = 0;var d = 0;var e = 0;a =  _inputs[_i++];b =  _inputs[_i++];c =  _inputs[_i++];d =  _inputs[_i++];a = a%2;if( a==0 ){e = e+1;}b = b%2;if( b==0 ){e = e+1;}c = c%2;if( c==0 ){e = e+1;}d = d%2;if( d==0 ){e = e+1;}_output += e+ " ";}}}

//16
Leia três valores Inteiros e apresente o maior dos três valores lidos.
//7 7 4 10 4 10 10 10 10
//3 3 6 0 6 0 0 0 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){var a = 0;var b = 0;var c = 0;a =  _inputs[_i++];b =  _inputs[_i++];c =  _inputs[_i++];if( a<=b ){if( b<=c ){if( c<=a ){_output += a+ " ";}else{_output += c+ " ";}}else{_output += b+ " ";}}else{if( a<=c ){if( c<=b ){_output += b+ " ";}else{_output += c+ " ";}}else{_output += a+ " ";}}}}}

//20
Leia 6 valores Float. Em seguida, mostre quantos destes valores digitados foram positivos. Estes valores serão somente negativos ou positivos.
//3 4 9 4 4 10 10 10 10
//7 6 1 6 6 0 0 0 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){var a = 0.0;var b = 0.0;var c = 0.0;var d = 0.0;var f = 0.0;var e = 0.0;a = _Dinputs[_j++];b = _Dinputs[_j++];c = _Dinputs[_j++];d = _Dinputs[_j++];e = _Dinputs[_j++];f = _Dinputs[_j++];var g = 0;if( a>0 ){g = g+1;}if( b>0 ){g = g+1;}if( c>0 ){g = g+1;}if( d>0 ){g = g+1;}if( e>0 ){g = g+1;}if( f>0 ){g = g+1;}_output += g+ " ";}}}

//6 -> 24
Leia um valor inteiro N. Apresente o quadrado de cada um dos valores pares, de 1 até N, inclusive N, se for o caso.
//7 9 9 6 9 10 9 10 10
//3 1 1 4 1 0 1 0 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _loopLimit = 0;_loopError = null;string _loopError = null; int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){_loopLimit = 0;var a = 0;var b = 0;var c = 0;if(_inputs.Count > _i)a =  _inputs[_i++];b = 0+1;while(b<=a){ if(_loopLimit >= 100000){_loopError = "Seus loops rodaram além do limite permitido pelo Mazecode"; return;} else {_loopLimit += 1;}c = b%2;if( c==0 ){c = b*b;if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += c+ " ";}b = b+1;}}}}

//7
Escreva um programa que repita a leitura de uma senha até que ela seja válida. Para cada leitura de senha incorreta informada, escrever a mensagem "0". Quando a senha for informada corretamente deve ser impressa a mensagem "1" e o algoritmo encerrado. Considere que a senha correta é o valor 2002.
//8 8 8 8 10 10 9 10 10
//2 2 2 2 0 0 1 0 0 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _loopLimit = 0;_loopError = null;string _loopError = null; int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){_loopLimit = 0;var a = 0;var b = 0;if(_inputs.Count > _i)b =  _inputs[_i++];while(b!=2002){ if(_loopLimit >= 100000){_loopError = "Seus loops rodaram além do limite permitido pelo Mazecode"; return;} else {_loopLimit += 1;}a = 0+0;if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += a+ " ";if(_inputs.Count > _i)b =  _inputs[_i++];}a = 1+0;if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += a+ " ";}}}

//9
Leia 100 valores inteiros. Apresente então o maior valor lido e a sua posição (começando de 1 até 100) dentre os 100 valores lidos.
//6 9 8 6 8 9 10 10 10
//4 1 2 4 2 1 0 0 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _loopLimit = 0;_loopError = null;string _loopError = null; int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){_loopLimit = 0;var a = 0;var b = 0;var c = 0;for(a = 1 ;a<=100;a++){ if(_loopLimit >= 100000){_loopError = "Seus loops rodaram além do limite permitido pelo Mazecode"; return;} else {_loopLimit += 1;}var d = 0;if(_inputs.Count > _i)d =  _inputs[_i++];if( a!=0 ){if( d>b ){b = d+0;c = a+0;}}else{b = d+0;c = a+0;}}if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += b+ " ";if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += c+ " ";}}}

//17
Leia um valor e faça um programa que coloque o valor lido na primeira posição de um vetor de tamanho 10. Em cada posição subsequente, coloque o dobro do valor da posição anterior. Por exemplo, se o valor lido for 1, os valores do vetor devem ser 1,2,4,8 e assim sucessivamente. Mostre o vetor em seguida.
//8 9 9 8 10 9 10 9 10
//2 1 1 2 0 1 0 1 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _loopLimit = 0;_loopError = null;string _loopError = null; int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){_loopLimit = 0;var a = 0;int[] b = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};if(_inputs.Count > _i)a =  _inputs[_i++];var c = 0;for(c = 0 ;c<=9;c++){ if(_loopLimit >= 100000){_loopError = "Seus loops rodaram além do limite permitido pelo Mazecode"; return;} else {_loopLimit += 1;}b[c] = a+0;a = a+a;if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += b[c]+ " ";}}}}

//22 -> 23
Faça um programa que leia um vetor inteiro de tamanho 30. No final, mostre todas as posições do vetor que armazenam um valor negativo. Ex: Para uma entrada 0, -5, 63 -8, -9... a saída será 1, 3, 4...
//9 9 9 10 9 9 10 9 10
//1 1 1 0 1 1 0 1 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _loopLimit = 0;string _loopError = null; int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){_loopLimit = 0;_loopError = null;var a = 0;int[] b = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};for(a = 0 ;a<=29;a++){ if(_loopLimit >= 100000){_loopError = "Seus loops rodaram além do limite permitido pelo Mazecode"; return;} else {_loopLimit += 1;}if(_inputs.Count > _i)b[a] =  _inputs[_i++];if( b[a]<0 ){if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += a+ " ";}}}}}

//23 -> 6
Faça um programa que leia um valor positivo T e preencha um vetor de tamanho 100 com a sequência de valores de 0 até T-1 repetidas vezes, conforme exemplo abaixo. Imprima o vetor N.
//7 9 8 6 10 9 10 9 10
//3 1 2 4 0 1 0 1 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _loopLimit = 0;_loopError = null;string _loopError = null; int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){_loopLimit = 0;var t = 0;var a = 0;if(_inputs.Count > _i)t =  _inputs[_i++];int[] b = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};b[0] = 0+0;if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += b[0]+ " ";for(a = 1 ;a<=99;a++){ if(_loopLimit >= 100000){_loopError = "Seus loops rodaram além do limite permitido pelo Mazecode"; return;} else {_loopLimit += 1;}var c = 0;c = a-1;c = b[c]+1;b[a] = c%t;if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += b[a]+ " ";}}}}

//24 -> 22
A seguinte sequência de números 0 1 1 2 3 5 8 13 21... é conhecida como série de Fibonacci. Nessa sequência, cada número, depois dos 2 primeiros, é igual à soma dos 2 anteriores. Escreva um algoritmo que leia um inteiro N (N < 46) e mostre os N primeiros números dessa série.
//6 9 9 4 8 10 9 9 10
//4 1 1 6 2 0 1 1 0
using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _loopLimit = 0;_loopError = null;string _loopError = null; int _i = 0; int _j = 0;string _output = "";List<int> _inputs = new List<int>() {}; List<double> _Dinputs = new List<double>() {};void teste(){_loopLimit = 0;var a = 0;if(_inputs.Count > _i)a =  _inputs[_i++];int[] b = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};var c = 0;while(c<a){ if(_loopLimit >= 100000){_loopError = "Seus loops rodaram além do limite permitido pelo Mazecode"; return;} else {_loopLimit += 1;}if( c==0 ){b[c] = 0+0;}else{if( c==1 ){b[c] = 1+0;}else{var d = 0;var e = 0;d = c-1;e = d-1;b[c] = b[d]+b[e];if(_output.Length >= 1000000) {_loopError = "Sua saída possui muitos caracteres, por favor, confira os loops da sua solução. "; return;}_output += b[c]+ " ";c = c+1;}}}}}}