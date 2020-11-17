using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveInventory : MonoBehaviour {
    [SerializeField] private PlayerInventory inventory;

    public void SaveScriptables () {
        //ResetScriptables();
        for (int i = 0; i < inventory.myInventory.Count; i++) {
            FileStream file = File.Create (Application.persistentDataPath + string.Format ("/{0}.ivt", i));
            BinaryFormatter binary = new BinaryFormatter ();
            var json = JsonUtility.ToJson (inventory.myInventory[i]);
            binary.Serialize (file, json);
            file.Close ();
        }
    }

    public void LoadScriptables () {
        if(inventory == null) return;
        for (int i = 0; i < inventory.myInventory.Count; i++) {
            if (File.Exists (Application.persistentDataPath + string.Format ("/{0}.ivt", i))) {
                Debug.Log("carregando variavel :"+ i);
                var temp = ScriptableObject.CreateInstance<InventoryItem> ();
                Debug.Log("antes do fileStream");
                FileStream file = File.Open (Application.persistentDataPath + string.Format ("/{0}.ivt", i), FileMode.Open);
                Debug.Log("depois do fileStream");
                BinaryFormatter binary = new BinaryFormatter ();
                JsonUtility.FromJsonOverwrite ((string) binary.Deserialize (file), temp);
                file.Close ();
                Debug.Log("close");
                //inventory.myInventory.Add(temp);
                inventory.myInventory[i].numberHeld = temp.numberHeld;
                
            }
        }
    }

    

    public void ResetScriptables () {
        for (int i = 0; i < inventory.myInventory.Count; i++) {
            // Zera inventário
            inventory.myInventory[i].numberHeld = 0;
            // Exclui arquivos
            if (File.Exists (Application.persistentDataPath + string.Format ("/{0}.ivt", i))) {
                File.Delete (Application.persistentDataPath + string.Format ("/{0}.ivt", i));
            }
        }
        //Debug.Log("Reset Inv OK");
    }
}