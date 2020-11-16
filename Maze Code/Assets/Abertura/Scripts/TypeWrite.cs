using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWrite : MonoBehaviour
{
    public Text textWriter;
    public float delayWriter = 0.5f;
    public string escrevaFrase = "Em alta, o Mazecode, um labirinto desafiador e com uma grande recompensa no final, que é uma bolsa de estudos em alguns dos cursos de tecnologia na FXL Academy, é um meio muito disputado e requisitado por estudantes na área da tecnologia, pois além de ter uma boa recompensa na conclusão do desafio, é uma grande oportunidade para aprender novas técnicas e ensinamentos em vários requisitos essenciais para se tornar um bom programador. Então muitos estudantes, mesmo não tendo conseguido concluir o desafio, saem de lá com grandes aprendizados. \n A história se concentra em um simples garoto chamado Lucas que acabou de concluir o ensino médio e está em busca de uma dessas bolsas de estudo e então entra nesse grande desafio. Lucas é um garoto que apesar de ser muito inteligente, ele sofre com problemas de ansiedade, algo que ele teme poder o atrapalhar em sua jornada. Porém, ele aceita esse desafio e embarca nessa aventura confiante de que ele saíra vencedor. ";

    // Start is called before the first frame update
    void Start()
    {
        escrevaFrase = "Em alta, o Mazecode, um labirinto desafiador e com uma grande recompensa no final, que é uma bolsa de estudos em alguns dos cursos de tecnologia na FXL Academy, é um meio muito disputado e requisitado por estudantes na área da tecnologia, pois além de ter uma boa recompensa na conclusão do desafio, é uma grande oportunidade para aprender novas técnicas e ensinamentos em vários requisitos essenciais para se tornar um bom programador. Então muitos estudantes, mesmo não tendo conseguido concluir o desafio, saem de lá com grandes aprendizados. \n A história se concentra em um simples garoto chamado Lucas que acabou de concluir o ensino médio e está em busca de uma dessas bolsas de estudo e então entra nesse grande desafio. Lucas é um garoto que apesar de ser muito inteligente, ele sofre com problemas de ansiedade, algo que ele teme poder o atrapalhar em sua jornada. Porém, ele aceita esse desafio e embarca nessa aventura confiante de que ele saíra vencedor. ";
        StartCoroutine("mostrarTexto", escrevaFrase);
    }
    
    IEnumerator mostrarTexto (string textType)
    {
        textWriter.text = "";
        for(int letter = 0; letter < textType.Length; letter++)
        {
            textWriter.text = textWriter.text + textType[letter];
            yield return new WaitForSeconds(delayWriter);
        }
    }
}
