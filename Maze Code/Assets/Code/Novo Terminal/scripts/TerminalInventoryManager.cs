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

    public static bool done = false;

    public static int varUsed;
    public static int vetUsed;
    public static int matUsed;
    public static int ifUsed;
    public static int forUsed;
    public static int whileUsed;
    public static int readUsed;
    public static int writeUsed;
    public static int mathUsed;

    public static int var = 0;
    public static int vet = 0;
    public static int mat = 0;
    public static int ifVar = 0;
    public static int forLoop = 0;
    public static int whileLoop = 0;
    public static int read = 0;
    public static int write = 0;
    public static int math = 0;

    public static int puzzleDone;

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
        varUsed = 0;
        vetUsed = 0;
        matUsed = 0;
        ifUsed = 0;
        forUsed = 0;
        whileUsed = 0;
        readUsed = 0;
        writeUsed = 0;
        mathUsed = 0;
        done = false;
        puzzleDone = 0;
    }

    private static void InitializeCount () {
        if (playerInventory) {

            foreach (InventoryItem item in playerInventory.myInventory) {
                if (item.numberHeld >= 0) {
                    switch (item.itemName) {
                        case "variavel":
                            varText.text = "x" + item.numberHeld;
                            var = item.numberHeld;
                            break;
                        case "vetor":
                            vetText.text = "x" + item.numberHeld;
                            vet = item.numberHeld;
                            break;
                        case "matriz":
                            matText.text = "x" + item.numberHeld;
                            mat = item.numberHeld;
                            break;
                        case "loopIndefinido":
                            whileText.text = "x" + item.numberHeld;
                            whileLoop = item.numberHeld;
                            break;
                        case "loopDefinido":
                            forText.text = "x" + item.numberHeld;
                            forLoop = item.numberHeld;
                            break;
                        case "condicional":
                            ifText.text = "x" + item.numberHeld;
                            ifVar = item.numberHeld;
                            break;
                        case "imprime":
                            writeText.text = "x" + item.numberHeld;
                            write = item.numberHeld;
                            break;
                        case "leitura":
                            readText.text = "x" + item.numberHeld;
                            read = item.numberHeld;
                            break;
                        case "matematica":
                            mathText.text = "x" + item.numberHeld;
                            math = item.numberHeld;
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

        Debug.Log (thisItem.itemName + " " + qtd);
        switch (thisItem.itemName) {
            case "variavel":
                varUsed -= qtd;
                break;
            case "vetor":
                vetUsed -= qtd;
                break;
            case "matriz":
                matUsed -= qtd;
                break;
            case "loopIndefinido":
                whileUsed -= qtd;
                break;
            case "loopDefinido":
                forUsed -= qtd;
                break;
            case "condicional":
                ifUsed -= qtd;
                break;
            case "imprime":
                writeUsed -= qtd;
                break;
            case "leitura":
                readUsed -= qtd;
                break;
            case "matematica":
                mathUsed -= qtd;
                break;
        }
        UpdateUI (thisItem, qtd);
    }

    private static void UpdateUI (InventoryItem thisItem, int qtd) {

        switch (thisItem.itemName) {
            case "variavel":
                var += qtd;
                varText.text = "x" + var;
                break;
            case "vetor":
                vet += qtd;
                vetText.text = "x" + vet;
                break;
            case "matriz":
                mat += qtd;
                matText.text = "x" + mat;
                break;
            case "loopIndefinido":
                whileLoop += qtd;
                whileText.text = "x" + whileLoop;
                break;
            case "loopDefinido":
                forLoop += qtd;
                forText.text = "x" + forLoop;
                break;
            case "condicional":
                ifVar += qtd;
                ifText.text = "x" + ifVar;
                break;
            case "imprime":
                write += qtd;
                writeText.text = "x" + write;
                break;
            case "leitura":
                read += qtd;
                readText.text = "x" + read;
                break;
            case "matematica":
                math += qtd;
                mathText.text = "x" + math;
                break;
        }
        CheckDisabled ();
    }
}