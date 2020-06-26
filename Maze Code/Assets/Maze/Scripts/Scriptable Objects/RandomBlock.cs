using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RandomBlock : ScriptableObject
{
    [Header("Random space da sala")]
    public int numSala;

    [Header("Blocos que a sala possui")]
    public int variavel;        // 1 - Vermelho
    public int leitura;         // 2 - Laranja
    public int imprime;         // 3 - Amarelo
    public int matematica;      // 4 - Verde
    public int condicional;     // 5 - Azul
    public int lacoDefinido;    // 6 - Roxo
    public int lacoIndefinido;  // 7 - Rosa
    public int vetor;           // 8 - Marrom
    public int matriz;          // 9 - Cinza

    [Header("Posição da área de geração")]
    public Vector2 position;

    [Header("Tamanho da área")]
    public Vector2 size;
}
