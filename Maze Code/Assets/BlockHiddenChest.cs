using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockHiddenChest : Interactable {
    public bool wasCollected;
    public BoolValue storedCollected;
    public GameObject dialogBox;
    public Text dialogText;
    protected JoyButtonAction joybutton;
    [SerializeField] private PlayerInventory playerInventory = null;
    [SerializeField] private InventoryItem thisItem = null;
    public BoxCollider2D bc;
    void Start () {
        joybutton = FindObjectOfType<JoyButtonAction> ();
        wasCollected = storedCollected.runtimeValue;
        // Instancia se o bloco não tiver sido coletado
        if (!wasCollected) {
            this.gameObject.SetActive (true);
            bc.enabled = true;
        } else {
            this.gameObject.SetActive (false);
        }
    }

    private void Update(){
        if(!playerInRange) return;
        if(joybutton.Pressed){
            AddItemToInventory();
            // O bloco foi foi coletado
            wasCollected = true;
            storedCollected.runtimeValue = wasCollected;
            bc.enabled = false;
        }
    }

    void AddItemToInventory()
    {
        if(playerInventory && thisItem && !wasCollected)
        {
            SomItem.current.PlayMusic();
            
            if (playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld += 1;
            } else {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
            }
            StartCoroutine(BlockFound());
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag ("Player") && !other.isTrigger) {
            context.Raise ();
            playerInRange = false;
        }
    }

    private IEnumerator BlockFound () {
        dialogBox.SetActive (true);
        dialogText.text = "Você encontrou um bloco " + thisItem.itemName;
        yield return new WaitForSeconds (3f);
        dialogBox.SetActive (false);
        this.gameObject.SetActive (false);
    }
}