using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsabellaChat12 : Sign
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
                    dialog = "Lucas: Olá Isabella, como você está? Já está melhor desde o último encontro? \n\nAperte para continuar...";
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
                        dialog = "Isabella: Oii Lucas, estou melhor sim, eu refleti bastante depois daquilo, e o que mais estava me deixando triste era pensar sobre o desafio final.\n\nAperte para continuar...";
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
                        dialog = "Lucas: Como assim? \n\nAperte para continuar...";
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
                        dialog = "Isabella: Eu estava muita ansiosa pelo desafio final, que acabei me esquecendo de que eu deveria focar em um desafio de cada vez.\n\nAperte para continuar...";
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
                    dialog = "Isabella: Pois se eu não conseguir focar nesse desafio de agora, eu com certeza não irei conseguir resolver o próximo.\n\nAperte para continuar...";
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
                    dialog = "Lucas: Realmente, isso é uma coisa muito interessante de se pensar. Vou focar nisso também. Obrigado Isabella, até mais!!\n\nAperte para continuar...";
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
