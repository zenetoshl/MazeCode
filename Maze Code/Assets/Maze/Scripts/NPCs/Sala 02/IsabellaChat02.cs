using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsabellaChat02 : Sign
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
                        dialog = "Isabella: ... [choro] O... Oi.\n\nAperte para continuar...";
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
                        dialog = "Lucas: O que aconteceu? Porque está chorando?.\n\nAperte para continuar...";
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
                        dialog = "Isabella: Eu não consigo resolver esse desafio, estou precisando de um bloco e já procurei pela sala inteira e não encontrei.\n\nAperte para continuar...";
                        dialogBox.SetActive(true);
                        dialogText.text = dialog;
                        quantConversasIsabella--;
                    }
                }
            else if (quantConversasIsabella == 1)
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "Lucas: Calma, respira fundo, eu tenho um bloco sobrando, e vou te ajudar, toma um bloco aqui.\n\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversasIsabella--;
                }
            }
            else if (quantConversasIsabella == 0)
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "Isabella: Muito obrigado Lucas, você salvou meu dia!!\n\nAperte para continuar...";
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
                        dialog = "Lucas: Estamos juntos nessa, te vejo no final.";
                        dialogBox.SetActive(true);
                        dialogText.text = dialog;
                        //quantConversasIsabella = 3;
                    }
                }
            }

        }
        
}
