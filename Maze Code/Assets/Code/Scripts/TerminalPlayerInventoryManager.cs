using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalPlayerInventoryManager : MonoBehaviour {
    public PlayerInventory playerInventory;
    public PlayerInventory playerInventoryDiff;
    // Start is called before the first frame update
    private void Awake () {
        TerminalInventoryManager.playerInventory = playerInventory;
        TerminalInventoryManager.done = false; 
    }
}