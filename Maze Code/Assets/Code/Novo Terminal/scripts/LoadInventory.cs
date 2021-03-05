using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInventory : MonoBehaviour
{
   public SaveInventory saveInventoryManager;

   private void Start() {
       saveInventoryManager.LoadScriptables ();
   }
}
