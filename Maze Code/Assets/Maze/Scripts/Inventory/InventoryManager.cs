using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    public InventoryItem currentItem;

    [SerializeField] private GameObject blankInventorySlot = null;
    [SerializeField] private GameObject inventoryPanel = null;
    [SerializeField] private TextMeshProUGUI descriptionText = null;

    public void SetText(string description)
    {
        descriptionText.text = description;
    }

    void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for (int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                if (playerInventory.myInventory[i].numberHeld > 0 || playerInventory.myInventory[i].itemName == "Bloco")
                {
                    GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventoryPanel.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if (newSlot)
                    {
                        newSlot.Setup(playerInventory.myInventory[i], this);
                    }
                }
            }
        }
    }

    void Start()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetText("Clique em algum bloco para ver os detalhes!");
    }

    public void RemakeInventory()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetText("Clique em algum bloco para ver os detalhes!");
    }

    public void SetupDescription(string newDescriptionString, InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
    }

    void ClearInventorySlots()
    {
        for(int i = 0; i < inventoryPanel.transform.childCount; i ++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }
}