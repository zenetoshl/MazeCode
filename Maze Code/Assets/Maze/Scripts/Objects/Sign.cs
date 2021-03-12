using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
    protected JoyButtonAction joybutton;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    
    // Start is called before the first frame update
    void Start()
    {
        joybutton = FindObjectOfType<JoyButtonAction>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(joybutton.Pressed && playerInRange)
        {
            dialogBox.SetActive(true);
            dialogText.text = dialog;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
