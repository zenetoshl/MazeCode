using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWindow : MonoBehaviour
{
    [HideInInspector] public Bloco myBlock;

    public void OnOk(){
        myBlock.UpdateUI(true);
    }

    public void OnCancel(){
        myBlock.UpdateUI(false);
    }
}
