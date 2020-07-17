using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

public class Compiler : MonoBehaviour
{
    public Transform inicial;
    public GameObject executar;
    public GameObject enviar;

    public void Compile(){
        if(ConnectionManager.Compile(inicial.GetComponent<RectTransform>())){
            executar.SetActive (true);
            enviar.SetActive (true);
        }else{
            executar.SetActive (false);
            enviar.SetActive (false);
        }
    }

    public void Uncompile(){
        executar.SetActive (false);
        enviar.SetActive (false);
    }
}
