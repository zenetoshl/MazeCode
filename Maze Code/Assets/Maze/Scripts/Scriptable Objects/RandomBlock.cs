using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RandomBlock : ScriptableObject
{
    [Header("Número da sala do Random")]
    public int numSala;

    [Header("Centralização da área de geração")]
    public Vector2 position;

    [Header("Tamanho da área")]
    public Vector2 size;
}
