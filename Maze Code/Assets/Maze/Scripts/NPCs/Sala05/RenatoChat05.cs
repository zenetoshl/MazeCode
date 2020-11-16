using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenatoChat05 : Sign
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
                dialog = "Renato: Parabéns por ter chegado até aqui, antes de lhe entregar o Emblema do Raciocínio Lógico, gostaria de falar algumas coisas. \n\nAperte para continuar...";
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
                    dialog = "Renato: Para ser um bom programador, você precisa aprimorar seu raciocínio lógico, pois com ele, você conseguirá não apenas resolver questões matemáticas, mas também vários problemas do seu dia a dia.\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversasLucas--;
                }
            }
            else if (quantConversasLucas == 2)
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "Renato: Se você for capaz de melhorar isso, você conseguiria ir muito além do que apenas esse labirinto. Boa sorte Garoto.\nAperte para continuar...";
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
                    dialog = "Parabéns, você recebeu o emblema do raciocionio lógico.";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    podeConversar = true;
                    //quantConversasLucas = 3;
                }
            }
        }

    }
}
