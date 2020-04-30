using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactable
{

    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(playerInRange && thisDoorType == DoorType.key)
            {
                // Change block for key
                if(playerInventory.numberOfBlocks > 0)
                {
                    playerInventory.numberOfBlocks--;
                    Open();
                }

                // If so, then call the open method
            }
        }
    }

    public void Open()
    {
        // Turn off the door's sprite renderer
        doorSprite.enabled = false;
        open = true;
        // Turn off the door's box collider
        physicsCollider.enabled = false;
    }

    public void Close()
    {

    }
}
