using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElenaChat07 : Sign
{
    private Vector3 directionVector;
    private Transform myTransform;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;
    protected JoyButtonAction joybutton;
    private int quantConversas = 3;
    private float timeChat = 0.2f;
    public bool podeConversar = false;
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
            if (quantConversas == 3)
            {
                dialog = "Elena: Parabéns por ter chegado até aqui, antes de lhe entregar o Emblema da Perspicácia, gostaria de falar algumas coisas.\n\nAperte para continuar...";
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                quantConversas--;
            }

            else if (quantConversas == 2)
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "Elena: Para ser um bom programador, você precisa aprimorar o seu senso de observação, é muito importante que você treine a sua capacidade de observar onde você está errando e como consertar esse erro.\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversas--;
                }
            }
            else if (quantConversas == 1)
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "Elena: Se você for capaz de melhorar isso, você conseguirá ir muito além do que apenas esse labirinto. Boa sorte Garoto.\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversas--;
                }
            }
            else
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    dialog = "Parabéns, você recebeu o Emblema da Perspicácia.";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    podeConversar = true;
                    //quantConversasLucas = 3;
                }
            }
        }

    }
}
