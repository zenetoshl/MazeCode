using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

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
    public static PlayerInventory playerInventoryDiff;

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
        InitializeCount ();
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
        if (varText.text == "x0") {
            varText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            varText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (vetText.text == "x0") {
            vetText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            vetText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (matText.text == "x0") {
            matText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            matText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (ifText.text == "x0") {
            ifText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            ifText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (whileText.text == "x0") {
            whileText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            whileText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (forText.text == "x0") {
            forText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            forText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (writeText.text == "x0") {
            writeText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            writeText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (readText.text == "x0") {
            readText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            readText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
        if (mathText.text == "x0") {
            mathText.transform.parent.GetComponent<LeanButton> ().interactable = false;
        } else {
            mathText.transform.parent.GetComponent<LeanButton> ().interactable = true;
        }
    }

    public static void UpdateItemInventory (InventoryItem thisItem, int qtd) {
        Debug.Log("teste: " + (playerInventory  && thisItem));
        if (playerInventory && playerInventoryDiff) {
            if (playerInventoryDiff.myInventory.Contains (thisItem)) {
                thisItem.numberHeld += qtd;
            } else {
                playerInventoryDiff.myInventory.Add (thisItem);
                thisItem.numberHeld += qtd;
            }
            UpdateUI (thisItem, qtd);
        }
    }

    public static void CalculateDiff () {
        if (playerInventory && playerInventoryDiff) {
            foreach (InventoryItem itemDiff in playerInventoryDiff.myInventory) {
                foreach (InventoryItem item in playerInventory.myInventory) {
                    if (itemDiff.itemName == item.itemName) {
                        item.numberHeld -= itemDiff.numberHeld;
                        break;
                    }
                }
            }
        }
    }

    private static void UpdateUI (InventoryItem thisItem, int qtd) {
        switch (thisItem.itemName) {
            case "variavel":
                varText.text = "x" + thisItem.numberHeld;
                break;
            case "vetor":
                vetText.text = "x" + thisItem.numberHeld;
                break;
            case "matriz":
                matText.text = "x" + thisItem.numberHeld;
                break;
            case "loopIndefinido":
                whileText.text = "x" + thisItem.numberHeld;
                break;
            case "loopDefinido":
                forText.text = "x" + thisItem.numberHeld;
                break;
            case "condicional":
                ifText.text = "x" + thisItem.numberHeld;
                break;
            case "imprime":
                writeText.text = "x" + thisItem.numberHeld;
                break;
            case "leitura":
                readText.text = "x" + thisItem.numberHeld;
                break;
            case "matematica":
                mathText.text = "x" + thisItem.numberHeld;
                break;
        }
        CheckDisabled ();
    }
}