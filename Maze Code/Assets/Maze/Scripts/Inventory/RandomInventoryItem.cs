using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory = null;
    [SerializeField] private InventoryItem thisItem = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            AddItemToInventory();
            Destroy(this.gameObject);
        }
    }

    void AddItemToInventory()
    {
        if(playerInventory && thisItem)
        {
            SomItem.current.PlayMusic();
            if (playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld += 1;
            } else {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
            }
        }
    }
}