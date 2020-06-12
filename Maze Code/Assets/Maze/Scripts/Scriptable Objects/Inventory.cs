using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Inventory : ScriptableObject 
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfBlocks;

    public void AddItem(Item itemToAdd)
    {
        if(itemToAdd.isBlock)
        {
            
            numberOfBlocks++;
        } else {
            if(!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }
}