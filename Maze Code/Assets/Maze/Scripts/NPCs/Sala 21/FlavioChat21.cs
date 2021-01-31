using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlavioChat21 : Sign
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
                dialog = "Flavio: Parabéns por ter chegado até aqui, antes de lhe entregar o Emblema da Proatividade, gostaria de falar algumas coisas.\n\nAperte para continuar...";
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
                    dialog = "Flavio: Para ser um bom programador, você precisa ser uma pessoa proativa, você precisa tomar iniciativas e buscar soluções, não espere que os outros façam isso pra você se você pode resolver um problema.\nAperte para continuar...";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    quantConversas--;
                }
            }
            else if (quantConversas== 1)
            {
                timeChat -= Time.deltaTime;
                if (timeChat <= 0)
                {
                    timeChat = 0.2f;
                    dialog = "Flavio: Se você for capaz de melhorar isso, você conseguirá ir muito além do que apenas esse labirinto. Boa sorte Garoto.\nAperte para continuar...";
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
                    dialog = "Parabéns, você recebeu o Emblema da Proatividade.";
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    podeConversar = true;
                    //quantConversasLucas = 3;
                }
            }
        }

    }
}
