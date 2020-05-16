using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

public class Compiler : MonoBehaviour
{
    public Transform inicial;
    public LeanButton executar;
    public LeanButton enviar;

    public void Compile(){
        if(ConnectionManager.Compile(inicial.GetComponent<RectTransform>())){
            executar.interactable = true;
            enviar.interactable = true;
        }else{
            executar.interactable = false;
            enviar.interactable = false;
        }
    }

    public void Uncompile(){
         executar.interactable = false;
         enviar.interactable = false;
    }
}
