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
    public void BlockInstantiate(int numBloco, int idBloco)
    {
        int area;
        Vector2 position;

        while(numBloco != 0)
        {
            // Primeiro random -> Qual área aleatória
            area = ChooseArea();
            // Segundo random -> Posição em que o bloco vai aparecer
            position = BlockPosition(area);
            Instantiate(blocks[idBloco] , position, Quaternion.identity);
            numBloco--;
        }
    }

    // Função determina a quantidade de blocos aleatórios, levando em consideração o bonus recebido
    public int BonusControl(int numBloco, int idBloco)
    {
        if(areasGeradoras.Count > 0 && numBloco > 0)
        {
            for(int i=0; i<areasGeradoras.Count; i++){
                if(idBloco == 0){    // 1 - Vermelho
                    numBloco = numBloco - areasGeradoras[i].variavel;
                }
                if(idBloco == 1){    // 2 - Laranja
                    numBloco = numBloco - areasGeradoras[i].leitura;
                }
                if(idBloco == 2){    // 3 - Amarelo
                    numBloco = numBloco - areasGeradoras[i].imprime;
                }
                if(idBloco == 3){    // 4 - Verde
                    numBloco = numBloco - areasGeradoras[i].matematica;
                }
                if(idBloco == 4){    // 5 - Azul
                    numBloco = numBloco - areasGeradoras[i].condicional;
                }
                if(idBloco == 5){    // 6 - Roxo
                    numBloco = numBloco - areasGeradoras[i].loopDefinido;
                }
                if(idBloco == 6){     // 7 - Rosa
                    numBloco = numBloco - areasGeradoras[i].loopIndefinido;
                }
                if(idBloco == 7){    // 8 - Marrom
                    numBloco = numBloco - areasGeradoras[i].vetor;
                }
                if(idBloco == 8){    // 9 - Cinza
                    numBloco = numBloco - areasGeradoras[i].matriz;
                }
            }
        }
        return numBloco;
    }



    // Gera os blocos aleatórios necessários para resolver o primeiro problema da lista puzzles
    public void SpawnBlock()
    {
        // Posição dos blocos na lista blocks
        int variavel = 0;
        int leitura = 1;
        int imprime = 2;
        int matematica = 3;
        int condicional = 4;
        int loopDefinido = 5;
        int loopIndefinido = 6;
        int vetor = 7;
        int matriz = 8;

        // Numero de blocos necessários para o primeiro problema da lista
        int numBloco;

        if (puzzleAcessivel.Count > 0)
        {
            if(inventory.myInventory[variavel].numberHeld < puzzleAcessivel[0].variavel)
            {
                numBloco = puzzleAcessivel[0].variavel - inventory.myInventory[variavel].numberHeld;
                numBloco = BonusControl(numBloco, variavel);
                BlockInstantiate(numBloco, variavel);
            }

            if(inventory.myInventory[leitura].numberHeld < puzzleAcessivel[0].leitura)
            {
                numBloco = puzzleAcessivel[0].leitura - inventory.myInventory[leitura].numberHeld;
                numBloco = BonusControl(numBloco, leitura);
                BlockInstantiate(numBloco, leitura);
            }

            if(inventory.myInventory[imprime].numberHeld < puzzleAcessivel[0].imprime)
            {
                numBloco = puzzleAcessivel[0].imprime - inventory.myInventory[imprime].numberHeld;
                numBloco = BonusControl(numBloco, imprime);
                BlockInstantiate(numBloco, imprime);
            }

            if(inventory.myInventory[matematica].numberHeld < puzzleAcessivel[0].matematica)
            {
                numBloco = puzzleAcessivel[0].matematica - inventory.myInventory[matematica].numberHeld;
                numBloco = BonusControl(numBloco, matematica);
                BlockInstantiate(numBloco, matematica);
            }

            if(inventory.myInventory[condicional].numberHeld < puzzleAcessivel[0].condicional)
            {
                numBloco = puzzleAcessivel[0].condicional - inventory.myInventory[condicional].numberHeld;
                numBloco = BonusControl(numBloco, condicional);
                BlockInstantiate(numBloco, condicional);
            }

            if(inventory.myInventory[loopDefinido].numberHeld < puzzleAcessivel[0].loopDefinido)
            {
                numBloco = puzzleAcessivel[0].loopDefinido - inventory.myInventory[loopDefinido].numberHeld;
                numBloco = BonusControl(numBloco, loopDefinido);
                BlockInstantiate(numBloco, loopDefinido);
            }

            if(inventory.myInventory[loopIndefinido].numberHeld < puzzleAcessivel[0].loopIndefinido)
            {
                numBloco = puzzleAcessivel[0].loopIndefinido - inventory.myInventory[loopIndefinido].numberHeld;
                numBloco = BonusControl(numBloco, loopIndefinido);
                BlockInstantiate(numBloco, loopIndefinido);
            }

            if(inventory.myInventory[vetor].numberHeld < puzzleAcessivel[0].vetor)
            {
                numBloco = puzzleAcessivel[0].vetor - inventory.myInventory[vetor].numberHeld;
                numBloco = BonusControl(numBloco, vetor);
                BlockInstantiate(numBloco, vetor);
            }

            if(inventory.myInventory[matriz].numberHeld < puzzleAcessivel[0].matriz)
            {
                numBloco = puzzleAcessivel[0].matriz - inventory.myInventory[matriz].numberHeld;
                numBloco = BonusControl(numBloco, matriz);
                BlockInstantiate(numBloco, matriz);
            }
        } else {
            Debug.Log("Todos os problemas foram resolvidos");
        }
    }
}
