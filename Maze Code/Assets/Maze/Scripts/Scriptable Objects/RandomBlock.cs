using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RandomBlock : ScriptableObject
{
    [Header("Número da sala do Random")]
    public int numSala;

    [Header("Lista de quais blocos podem ser gerados")]
    public List<GameObject> block = new List<GameObject>();
    
    [Header("Centralização da área de geração")]
    public Vector2 position;

    [Header("Tamanho da área")]
    public Vector2 size;
}
