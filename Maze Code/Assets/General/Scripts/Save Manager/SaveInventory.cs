using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveInventory : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory = null;

    private void OnEnable()
    {
        //inventory.myInventory.Clear();
        LoadScriptables();
        //Debug.Log("Load Inv OK");
    }

    private void OnDisable()
    {
        SaveScriptables();
        //Debug.Log("Save Inv OK");
    }

    public void SaveScriptables()
    {
        //ResetScriptables();
        for (int i = 0; i < inventory.myInventory.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.inv", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(inventory.myInventory[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()
    {
        for (int i= 0; i < inventory.myInventory.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
            {
                var temp = ScriptableObject.CreateInstance<InventoryItem>();
                FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.inv", i), FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), temp);
                file.Close();
                //inventory.myInventory.Add(temp);
                inventory.myInventory[i].numberHeld = temp.numberHeld;
            }
        }
    }

    public void ResetScriptables()
    {
        for (int i= 0; i < inventory.myInventory.Count; i++)
        {
            // Zera inventário
            inventory.myInventory[i].numberHeld = 0;
            // Exclui arquivos
            if(File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
            {
                File.Delete(Application.persistentDataPath + string.Format("/{0}.inv", i));
            }
        }
        //Debug.Log("Reset Inv OK");
    }
}