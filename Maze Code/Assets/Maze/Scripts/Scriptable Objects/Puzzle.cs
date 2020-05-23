using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Puzzle : ScriptableObject
{
    [Header("Especificações do mapa")]
    public int naSala;
    public int destravaSala;

    [Header("Detalhes do Puzzle")]
    public string objetivo;
    public BoolValue realizado;
    
    [Header("Número de blocos necessários")]
    public int variavel;        // 1 - Vermelho
    public int leitura;         // 2 - Laranja
    public int imprime;         // 3 - Amarelo
    public int matematica;      // 4 - Verde
    public int condicional;     // 5 - Azul
    public int loopDefinido;    // 6 - Roxo
    public int loopIndefinido;  // 7 - Rosa
    public int vetor;           // 8 - Marrom
    public int matriz;          // 9 - Cinza

    [Header("Número de blocos bônus")]
    public int bonusVariavel;        // 1 - Vermelho
    public int bonusLeitura;         // 2 - Laranja
    public int bonusImprime;         // 3 - Amarelo
    public int bonusMatematica;      // 4 - Verde
    public int bonusCondicional;     // 5 - Azul
    public int bonusLoopDefinido;    // 6 - Roxo
    public int bonusLoopIndefinido;  // 7 - Rosa
    public int bonusVetor;           // 8 - Marrom
    public int bonusMatriz;          // 9 - Cinza
}
