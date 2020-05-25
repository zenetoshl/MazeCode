using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{   
    [Header("Inventário base para controle de blocos no ambiente")]
    [SerializeField] public PlayerInventory inventory = null;

    [Header("Lista com todos os puzzles do jogo")]
    public List<Puzzle> puzzle = new List<Puzzle>();

    [Header("Lista com todas as áreas pseudoaleatórias")]
    public List<RandomBlock> areasAleatorias = new List<RandomBlock>();

    [Header("Lista de salas desbloqueadas")]
    public List<int> sala = new List<int>();

    [Header("Lista os puzzles acessíveis e não realizados")]
    public List<Puzzle> puzzleAcessivel = new List<Puzzle>();

    [Header("Lista as salas onde podem aparecer blocos")]
    public List<RandomBlock> areasGeradoras = new List<RandomBlock>();

    // Executará toda vez que o jogador retornar do terminal para o labirinto
    void Start()
    {
        AddResolved();
        AddPuzzles();
        AddRandom();
        if(sala.Count > 0)
        {
            SpawnBlock();
        }
    }

    // Método percorre os puzzles verificando quais foram resolvidos, adicionando as salas desbloqueadas a lista
    public void AddResolved()
    {
        sala.Clear();
        for(int i=0; i<puzzle.Count; i++)
        {
            if(puzzle[i].status == true)
            {
                sala.Add(puzzle[i].destravaSala);
            }
        }
    }

    // Método percorre lista de salas desbloqueadas, determinando quais puzzles o jogador tem acesso
    public void AddPuzzles()
    {
        puzzleAcessivel.Clear();
        for(int i=0; i<puzzle.Count; i++)
        {
            for(int j=0; j<sala.Count; j++)
            {
                if(sala[j] == puzzle[i].naSala)
                {
                    if(puzzle[i].status == false)
                    {
                        puzzleAcessivel.Add(puzzle[i]);
                    }
                }
            }
        }
    }

    // Método gera lista de salas onde o jogador tem acesso, para randon blocks
    public void AddRandom()
    {
        areasGeradoras.Clear();
        for(int i=0; i<areasAleatorias.Count; i++)
        {
            for(int j=0; j<sala.Count; j++)
            {
                if(sala[j] == areasAleatorias[i].numSala)
                {
                    areasGeradoras.Add(areasAleatorias[i]);
                }
            }
        }
    }

    // Gera os blocos aleatórios necessários para resolver o primeiro problema da lista puzzles
    public void SpawnBlock()
    {
        // Compara Inventário com o primeiro problema da lista
        int auxBloco = 0;
        if(inventory.myInventory[0].numberHeld < puzzleAcessivel[0].variavel)
        {
            // Primeiro random -> Qual área aleatória
            int a = Random.Range(0, (areasGeradoras.Count-1));
            Debug.Log("Area escolhida aleatoriamente: " + areasGeradoras[a].name);
            for(int i=0; i<areasGeradoras[a].block.Count; i++)
            {
                if (areasGeradoras[a].block[i].name == "1-BlocoVariavel")
                {
                    auxBloco = i;
                    break;
                }
                else {
                    // Nova area
                    a = Random.Range(0, (areasGeradoras.Count-1));
                    Debug.Log("Area escolhida aleatoriamente: " + areasGeradoras[a].name);
                }
            }
            int auxVariavel = puzzleAcessivel[0].variavel - inventory.myInventory[0].numberHeld;
            while(auxVariavel != 0)
            {
                // Segundo random -> Posição em que o bloco vai aparecer
                Vector2 pos = areasGeradoras[a].position + new Vector2(
                    Random.Range(-areasGeradoras[a].size.x / 2, areasGeradoras[a].size.x / 2), 
                    Random.Range(-areasGeradoras[a].size.y / 2, areasGeradoras[a].size.y / 2)
                );

                Instantiate(areasGeradoras[a].block[auxBloco] , pos, Quaternion.identity);
                auxVariavel--;
            }
        }

        if(inventory.myInventory[1].numberHeld < puzzleAcessivel[0].leitura)
        {
            // Primeiro random -> Qual área aleatória
            int a = Random.Range(0, (areasGeradoras.Count-1));
            Debug.Log("Area escolhida aleatoriamente: " + areasGeradoras[a].name);
            for(int i=0; i<areasGeradoras[a].block.Count; i++)
            {
                if (areasGeradoras[a].block[i].name == "2-BlocoLeitura")
                {
                    auxBloco = i;
                    break;
                }
                else {
                    // Nova area
                    a = Random.Range(0, (areasGeradoras.Count-1));
                    Debug.Log("Area escolhida aleatoriamente: " + areasGeradoras[a].name);
                }
            }
            int auxVariavel = puzzleAcessivel[0].leitura - inventory.myInventory[0].numberHeld;
            while(auxVariavel != 0)
            {
                // Segundo random -> Posição em que o bloco vai aparecer
                Vector2 pos = areasGeradoras[a].position + new Vector2(
                    Random.Range(-areasGeradoras[a].size.x / 2, areasGeradoras[a].size.x / 2), 
                    Random.Range(-areasGeradoras[a].size.y / 2, areasGeradoras[a].size.y / 2)
                );

                Instantiate(areasGeradoras[a].block[auxBloco] , pos, Quaternion.identity);
                auxVariavel--;
            }
        }

        if(inventory.myInventory[2].numberHeld < puzzleAcessivel[0].imprime)
        {
            // Primeiro random -> Qual área aleatória
            int a = Random.Range(0, (areasGeradoras.Count-1));
            Debug.Log("Area escolhida aleatoriamente: " + areasGeradoras[a].name);
            for(int i=0; i<areasGeradoras[a].block.Count; i++)
            {
                if (areasGeradoras[a].block[i].name == "3-BlocoImprime")
                {
                    auxBloco = i;
                    break;
                }
                else {
                    // Nova area
                    a = Random.Range(0, (areasGeradoras.Count-1));
                    Debug.Log("Area escolhida aleatoriamente: " + areasGeradoras[a].name);
                }
            }
            int auxVariavel = puzzleAcessivel[0].imprime - inventory.myInventory[0].numberHeld;
            while(auxVariavel != 0)
            {
                // Segundo random -> Posição em que o bloco vai aparecer
                Vector2 pos = areasGeradoras[a].position + new Vector2(
                    Random.Range(-areasGeradoras[a].size.x / 2, areasGeradoras[a].size.x / 2), 
                    Random.Range(-areasGeradoras[a].size.y / 2, areasGeradoras[a].size.y / 2)
                );

                Instantiate(areasGeradoras[a].block[auxBloco] , pos, Quaternion.identity);
                auxVariavel--;
            }
        }

        /*        Fazer gatilho para demais blocos
        if(inventory.myInventory[3].numberHeld < puzzleAcessivel[0].matematica)
        {

        }

        if(inventory.myInventory[4].numberHeld < puzzleAcessivel[0].condicional)
        {

        }

        if(inventory.myInventory[5].numberHeld < puzzleAcessivel[0].loopDefinido)
        {

        }

        if(inventory.myInventory[6].numberHeld < puzzleAcessivel[0].loopIndefinido)
        {

        }

        if(inventory.myInventory[7].numberHeld < puzzleAcessivel[0].vetor)
        {

        }

        if(inventory.myInventory[8].numberHeld < puzzleAcessivel[0].matriz)
        {

        }
        */
    }
}
