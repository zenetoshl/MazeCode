using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsabellaChat : Sign
{
    private Vector3 directionVector;
    private Transform myTransform;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;
    protected JoyButtonAction joybutton;
    private int quantConversasIsabella = 3;
    private float timeChat = 0.2f;
    public GameObject lucas01;
    // Start is called before the first frame update
    void Start()
    {
        joybutton = FindObjectOfType<JoyButtonAction>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lucas01.GetComponent<LucasChat>().podeConversar == true)
        {
            
            if (joybutton.Pressed && playerInRange)
            {
                if (quantConversasIsabella == 3)
                {
                    dialog = "Lucas: E você Isabella? \n\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversasIsabella--;
                }

                else if (quantConversasIsabella == 2)
                {
                    timeChat -= Time.deltaTime;
                    if (timeChat <= 0)
                    {
                        timeChat = 0.2f;
                        dialog = "Isabella: Eu já sabia que queria isso desde o ensino médio. \n\nAperte para continuar...";
                        dialogBox.SetActive(true);
                        dialogText.text = dialog;
                        quantConversasIsabella--;
                    }
                }
                else
                {
                    timeChat -= Time.deltaTime;
                    if (timeChat <= 0)
                    {
                        dialog = "Lucas: Entendo. Boa sorte pra você também, vamos todos conseguir. Tchau!!";
                        dialogBox.SetActive(true);
                        dialogText.text = dialog;
                        //quantConversasIsabella = 3;
                    }
                }
            }

        }
    }
        
}
