using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucasChat23 : Sign
{
    private Vector3 directionVector;
    private Transform myTransform;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;
    protected JoyButtonAction joybutton;
    private int quantConversasLucas = 3;
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
            if (quantConversasLucas == 3)
            {
                dialog = "Lucas: Fala Yago. O que tá fazendo aqui ainda?\n\nAperte para continuar...";
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                quantConversasLucas--;
            }

            else if (quantConversasLucas == 2)
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "Yago: Parece que deixei uns emblemas pra trás, agora estou pensando pra onde ir.\n\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversasLucas--;
                }
            }
            else if (quantConversasLucas == 1)
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "Lucas: Tenta voltar no inicio e refazer seus passos, tenho certeza que você vai encontrar.\n\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversasLucas--;
                }
            }
            else if (quantConversasLucas == 0)
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "Yago: Ok ok, muito obrigado pelo conselho. Vou nessa. Até mais.\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversasLucas--;
                }
            }
            else
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    dialog = "Lucas: Entendi. Até mais então.";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    podeConversar = true;
                    //quantConversasLucas = 3;
                }
            }
        }

    }
}
