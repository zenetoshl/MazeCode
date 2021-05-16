using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveItem : MonoBehaviour
{
    [Header("Lista de todos os blocos visíveis no Labirinto")]
    public List<BoolValue> objects = new List<BoolValue>();

    [System.Serializable]
    public class Items
    {
        [SerializeField] public List<bool> saveItems = new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,};

        public Items()
        {
            saveItems = new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,};
        }
    }
    public Items items = new Items();
    public static bool loaded = false;

    public Items SaveScriptables()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            items.saveItems[i] = objects[i].runtimeValue;
            Debug.Log("save " + items.saveItems[i]);
        }
        return items;
    }

    public void LoadScriptables(List<bool> _items)
    {
        items.saveItems = _items;
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].runtimeValue = items.saveItems[i];
            Debug.Log("load " + items.saveItems[i]);
        }
    }

    public Items ResetScriptables()
    {
        return new Items();
    }
}

