using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InicialSceneText : MonoBehaviour
{
    public string TextoEnrada;
    string mensagem = "";
    char TextoSaida;
    string cursor = "";
    public bool controle;

    // Update is called once per frame
    void Update()
    {
        //Se Controle for Verdadeiro
        if (controle)
        {
            //Chama TypeWriter
            StartCoroutine(TypeRight());
        }
    }

    void OnGUI()
    {
        GUI.backgroundColor = new Color(0, 0, 0, 0.0f);
        //Cria uma Area "Invisivel" que conterá a TextArea
        GUILayout.BeginArea(new Rect(10, 10, Screen.width - 50, 400));
        //Cria um GUILayout do Tipo TextArea
        GUILayout.TextArea(mensagem);
        //Encerra a Area "Invisivil" criada
        GUILayout.EndArea();
    }

    IEnumerator TypeRight()
    {
        //Desliga o controle para que ele não se inicialize a cada frame da função Update()
        controle = false;
        for (int i = 0; i < TextoEnrada.Length; i++)
        {
            //Pega Caracter por Caracter da string TextoEntrada
            TextoSaida = TextoEnrada[i];
            //Agrupa todos os caracteres da String a cada Loop
            mensagem += TextoSaida;
            //Cria um Tempo Aleatório de 0 segundos á 5 milessimos de segundos
            yield return new WaitForSeconds(Random.Range(.05f, .05f));
        }
        //Após completar o Loop espera 2 Segundos.
        yield return new WaitForSeconds(2);
        //Apaga menssagem.
        //mensagem = "";
    }
}

