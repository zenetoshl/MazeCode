using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{   
    [Header("Inventário base para controle de blocos no ambiente")]
    [SerializeField] public PlayerInventory inventory = null;

    [Header("Lista com todos os puzzles do jogo")]
    public List<Puzzle> puzzle = new List<Puzzle>();

    [Header("Lista com todos os blocos que podem ser gerados")]
    public List<GameObject> blocks = new List<GameObject>();

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
        if(puzzle.Count > 0)
        {
            AddResolved();
            // Só faz sentido gerar blocos se ainda houverem puzzles
            if(sala.Count > 0)
            {
                AddPuzzles();
                AddRandom();
                SpawnBlock();
            }
        }
    }

    // Método percorre os puzzles verificando quais foram resolvidos, adicionando as salas desbloqueadas a lista
    public void AddResolved()
    {
        sala.Clear();
        for(int i=0; i<puzzle.Count; i++)
        {
            if(puzzle[i].runtimeValue == true)
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
                    if(puzzle[i].runtimeValue == false)
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

    // Escolhe aleatoriamente uma area para a geração de blocos
    public int ChooseArea()
    {
        int a = Random.Range(0, (areasGeradoras.Count-1));
        return a;
    }

    // Gera posição aleatória pra um bloco dentro de uma area
    public Vector2 BlockPosition(int area)
    {
        Vector2 position = areasGeradoras[area].position + new Vector2(
            Random.Range(-areasGeradoras[area].size.x / 2, areasGeradoras[area].size.x / 2), 
            Random.Range(-areasGeradoras[area].size.y / 2, areasGeradoras[area].size.y / 2)
        );
        return position;
    }

    // Intancia os blocos necessários 
    public void BlockInstantiate(int numBloco, int nomeBloco)
    {
        int area;
        Vector2 position;

        while(numBloco != 0)
        {
            // Primeiro random -> Qual área aleatória
            area = ChooseArea();
            // Segundo random -> Posição em que o bloco vai aparecer
            position = BlockPosition(area);
            Instantiate(blocks[nomeBloco] , position, Quaternion.identity);
            numBloco--;
        }
    }

    // Gera os blocos aleatórios necessários para resolver o primeiro problema da lista puzzles
    public void SpawnBlock()
    {
        // Posição dos blocos na lista blocks
        int Variavel = 0;
        int Leitura = 1;
        int Imprime = 2;
        int Matematica = 3;
        int Condicional = 4;
        int LoopDefinido = 5;
        int LoopIndefinido = 6;
        int Vetor = 7;
        int Matriz = 8;

        // Numero de blocos necessários para o primeiro problema da lista
        int numBloco;

        if(inventory.myInventory[Variavel].numberHeld < puzzleAcessivel[0].variavel)
        {
            numBloco = puzzleAcessivel[0].variavel - inventory.myInventory[Variavel].numberHeld;
            BlockInstantiate(numBloco, Variavel);
        }

        if(inventory.myInventory[Leitura].numberHeld < puzzleAcessivel[0].leitura)
        {
            numBloco = puzzleAcessivel[0].leitura - inventory.myInventory[Leitura].numberHeld;
            BlockInstantiate(numBloco, Leitura);
        }

        if(inventory.myInventory[Imprime].numberHeld < puzzleAcessivel[0].imprime)
        {
            numBloco = puzzleAcessivel[0].imprime - inventory.myInventory[Imprime].numberHeld;
            BlockInstantiate(numBloco, Imprime);
        }

        if(inventory.myInventory[Matematica].numberHeld < puzzleAcessivel[0].matematica)
        {
            numBloco = puzzleAcessivel[0].matematica - inventory.myInventory[Matematica].numberHeld;
            BlockInstantiate(numBloco, Matematica);
        }

        if(inventory.myInventory[Condicional].numberHeld < puzzleAcessivel[0].condicional)
        {
            numBloco = puzzleAcessivel[0].condicional - inventory.myInventory[Condicional].numberHeld;
            BlockInstantiate(numBloco, Condicional);
        }

        if(inventory.myInventory[LoopDefinido].numberHeld < puzzleAcessivel[0].loopDefinido)
        {
            numBloco = puzzleAcessivel[0].loopDefinido - inventory.myInventory[LoopDefinido].numberHeld;
            BlockInstantiate(numBloco, LoopDefinido);
        }

        if(inventory.myInventory[LoopIndefinido].numberHeld < puzzleAcessivel[0].loopIndefinido)
        {
            numBloco = puzzleAcessivel[0].loopIndefinido - inventory.myInventory[LoopIndefinido].numberHeld;
            BlockInstantiate(numBloco, LoopIndefinido);
        }

        if(inventory.myInventory[Vetor].numberHeld < puzzleAcessivel[0].vetor)
        {
            numBloco = puzzleAcessivel[0].vetor - inventory.myInventory[Vetor].numberHeld;
            BlockInstantiate(numBloco, Vetor);
        }

        if(inventory.myInventory[Matriz].numberHeld < puzzleAcessivel[0].matriz)
        {
            numBloco = puzzleAcessivel[0].matriz - inventory.myInventory[Matriz].numberHeld;
            BlockInstantiate(numBloco, Matriz);
        }
    }
}
