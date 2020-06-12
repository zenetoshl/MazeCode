using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    public bool wasCollected;
    public BoolValue storedCollected;
    [SerializeField] private PlayerInventory playerInventory = null;
    [SerializeField] private InventoryItem thisItem = null;

    void Start()
    {
        wasCollected = storedCollected.runtimeValue;
        // Instancia se o bloco não tiver sido coletado
        if(!wasCollected)
        {
            this.gameObject.SetActive(true);
        } else {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            AddItemToInventory();
            // O bloco foi foi coletado
            wasCollected = true;
            storedCollected.runtimeValue = wasCollected;
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