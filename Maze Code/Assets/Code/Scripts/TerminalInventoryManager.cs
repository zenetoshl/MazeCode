using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class TerminalInventoryManager : MonoBehaviour {

    private static Text varText;
    private static Text vetText;
    private static Text matText;
    private static Text ifText;
    private static Text forText;
    private static Text whileText;
    private static Text readText;
    private static Text writeText;
    private static Text mathText;
    public static PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start () {
        varText = this.transform.Find ("Variavel/Count").GetComponent<Text> ();
        vetText = this.transform.Find ("Vetor/Count").GetComponent<Text> ();
        matText = this.transform.Find ("Matriz/Count").GetComponent<Text> ();
        ifText = this.transform.Find ("Condicao/Count").GetComponent<Text> ();
        forText = this.transform.Find ("LacoDefinido/Count").GetComponent<Text> ();
        whileText = this.transform.Find ("LacoIndefinido/Count").GetComponent<Text> ();
        readText = this.transform.Find ("Leitura/Count").GetComponent<Text> ();
        writeText = this.transform.Find ("Imprime/Count").GetComponent<Text> ();
        mathText = this.transform.Find ("Matematica/Count").GetComponent<Text> ();
        InitializeCount();
    }

    private static void InitializeCount () {
        if (playerInventory) {
            
            foreach (InventoryItem item in playerInventory.myInventory) {
                if (item.numberHeld >= 0) {
                    switch (item.itemName) {
                        case "variavel":
                            varText.text = "x" + item.numberHeld;
                            break;
                        case "vetor":
                            vetText.text = "x" + item.numberHeld;
                            break;
                        case "matriz":
                            matText.text = "x" + item.numberHeld;
                            break;
                        case "loopIndefinido":
                            whileText.text = "x" + item.numberHeld;
                            break;
                        case "loopDefinido":
                            forText.text = "x" + item.numberHeld;
                            break;
                        case "condicional":
                            ifText.text = "x" + item.numberHeld;
                            break;
                        case "imprime":
                            writeText.text = "x" + item.numberHeld;
                            break;
                        case "leitura":
                            readText.text = "x" + item.numberHeld;
                            break;
                        case "matematica":
                            mathText.text = "x" + item.numberHeld;
                            break;
                    }
                    CheckDisabled ();
                }
            }
        }
    }

    private static void CheckDisabled () {
        if (varText.text == "0") {
            varText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            varText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (vetText.text == "0") {
            vetText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            vetText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (matText.text == "0") {
            matText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            matText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (ifText.text == "0") {
            ifText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            ifText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (whileText.text == "0") {
            whileText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            whileText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (forText.text == "0") {
            forText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            forText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (writeText.text == "0") {
            writeText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            writeText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (readText.text == "0") {
            readText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            readText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (mathText.text == "0") {
            mathText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            mathText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
    }

    public static void UpdateItemInventory(InventoryItem thisItem, int qtd)
    {
        if(playerInventory && thisItem)
        {
            if(playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld += qtd;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += qtd;
            }
        }
        InitializeCount();
    }
}