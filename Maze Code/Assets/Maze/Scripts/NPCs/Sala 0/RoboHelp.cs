using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboHelp : Sign
{
    private Vector3 directionVector;
    private Transform myTransform;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;
    protected JoyButtonAction joybutton;
    private int quantConversasRobo = 3;
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
            if (quantConversasRobo == 3)
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "U2-V2: Olá jovem garoto, vejo que está um pouco perdido nesse labirinto, mas não se preocupe, estou aqui para te ajudar. \n\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversasRobo--;
                }
            }

            else if (quantConversasRobo == 2)
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "U2-V2: Primeiro Gostaria de avisar que essa ainda não é a versão final desse labirinto. \n\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversasRobo--;
                }
            }
            else if (quantConversasRobo == 1)
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "U2-V2: Para você conseguir completar o labirinto, você precisa resolver alguns puzzles que estão localizados nos computadores de cada sala. \n\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversasRobo--;
                }
            }
            else if (quantConversasRobo == 0)
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "U2-V2:  E para resolver os puzzles, você precisa coletar blocos que estão espalhados pelas salas. \n\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversasRobo--;
                }
            }
            else if (quantConversasRobo == -1)
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "U2-V2:  Além disso, na hora de resolver os puzzles, lembre-se bem dos conceitos de lógica de programação aprendidos no curso até agora. \n\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversasRobo--;
                }
            }
            else
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "U2-V2: Caso não tenha entendido muito bem, pode continuar conversando comigo aqui. Tchauzinho!! ";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    podeConversar = true;
                    quantConversasRobo = 3;
                }
            }
        }

    }
}
