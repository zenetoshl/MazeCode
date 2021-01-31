using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsabellaChat20 : Sign
{
    private Vector3 directionVector;
    private Transform myTransform;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;
    protected JoyButtonAction joybutton;
    private int quantConversasIsabella = 5;
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
            if (joybutton.Pressed && playerInRange)
            {
                if (quantConversasIsabella == 5)
                {
                    dialog = "Lucas: Oii Isabella.\n\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversasIsabella--;
                }

                else if (quantConversasIsabella == 4)
                {
                    timeChat -= Time.deltaTime;
                    if (timeChat <= 0)
                    {
                        timeChat = 0.2f;
                        dialog = "Isabella: Oi Lucas. Não se esqueça de sempre rever desafios que você deixou pra trás, eles são importantes, pois alguns deles são portas para encontrar algum professor.\n\nAperte para continuar...";
                        dialogBox.SetActive(true);
                        dialogText.text = dialog;
                        quantConversasIsabella--;
                    }
                }
                else if (quantConversasIsabella == 3)
                {
                    timeChat -= Time.deltaTime;
                    if (timeChat <= 0)
                    {
                        timeChat = 0.2f;
                        dialog = "Lucas: Muito obrigado pela dica Isabella. \n\nAperte para continuar...";
                        dialogBox.SetActive(true);
                        dialogText.text = dialog;
                        quantConversasIsabella--;
                    }
                }
                else if (quantConversasIsabella == 2)
                {
                    timeChat -= Time.deltaTime;
                    if (timeChat <= 0)
                    {
                        timeChat = 0.2f;
                        dialog = "Isabella: Até mais!!";
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
                        dialog = "Isabella: Até mais!!";
                        dialogBox.SetActive(true);
                        dialogText.text = dialog;
                        //quantConversasIsabella = 3;
                    }
                }
            }

        }
        
}
