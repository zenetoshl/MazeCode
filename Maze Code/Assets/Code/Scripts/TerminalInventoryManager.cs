using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using TMPro;
using UnityEngine;

public class TerminalInventoryManager : MonoBehaviour {

    private static TextMeshProUGUI varText;
    private static TextMeshProUGUI vetText;
    private static TextMeshProUGUI matText;
    private static TextMeshProUGUI ifText;
    private static TextMeshProUGUI forText;
    private static TextMeshProUGUI whileText;
    private static TextMeshProUGUI readText;
    private static TextMeshProUGUI writeText;
    private static TextMeshProUGUI mathText;
    public static PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start () {
        varText = this.transform.Find ("Variavel/Count").GetComponent<TextMeshProUGUI> ();
        vetText = this.transform.Find ("Vetor/Count").GetComponent<TextMeshProUGUI> ();
        matText = this.transform.Find ("Matriz/Count").GetComponent<TextMeshProUGUI> ();
        ifText = this.transform.Find ("Condicao/Count").GetComponent<TextMeshProUGUI> ();
        forText = this.transform.Find ("LacoDefinido/Count").GetComponent<TextMeshProUGUI> ();
        whileText = this.transform.Find ("LacoIndefinido/Count").GetComponent<TextMeshProUGUI> ();
        readText = this.transform.Find ("Leitura/Count").GetComponent<TextMeshProUGUI> ();
        writeText = this.transform.Find ("Imprime/Count").GetComponent<TextMeshProUGUI> ();
        mathText = this.transform.Find ("Matematica/Count").GetComponent<TextMeshProUGUI> ();
        InitializeCount();
    }

    private static void InitializeCount () {
        if (playerInventory) {
            foreach (InventoryItem item in playerInventory.myInventory) {
                if (item.numberHeld >= 0) {
                    switch (item.itemName) {
                        case "Variavel":
                            varText.text = "x" + item.numberHeld;
                            break;
                        case "Vetor":
                            vetText.text = "x" + item.numberHeld;
                            break;
                        case "Matriz":
                            matText.text = "x" + item.numberHeld;
                            break;
                        case "Loop Indefinido":
                            whileText.text = "x" + item.numberHeld;
                            break;
                        case "Loop Definido":
                            forText.text = "x" + item.numberHeld;
                            break;
                        case "Condicional":
                            ifText.text = "x" + item.numberHeld;
                            break;
                        case "Imprime":
                            writeText.text = "x" + item.numberHeld;
                            break;
                        case "Leitura":
                            readText.text = "x" + item.numberHeld;
                            break;
                        case "Metematica":
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