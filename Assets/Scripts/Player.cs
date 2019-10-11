using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidadeMaxima;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigibody = GetComponent<Rigidbody2D>();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Debug.Log("X = " + horizontal);
        Debug.Log("Y = " + vertical);

        rigibody.velocity = new Vector2(vertical * velocidadeMaxima, rigibody.velocity.y);
        rigibody.velocity = new Vector2(horizontal * velocidadeMaxima, rigibody.velocity.x);


        if (vertical < 0)
        {
            GetComponent<Animator>().SetBool("Andando Para Frente", true);
            GetComponent<Animator>().SetBool("Parado de Frente", true);
            GetComponent<Animator>().SetBool("Parado de Costas", false);
            GetComponent<Animator>().SetBool("Parado Direita", false);
            GetComponent<Animator>().SetBool("Parado Esquerda", false);
            GetComponent<Animator>().SetBool("Andando Para Esquerda", false);
            GetComponent<Animator>().SetBool("Andando Para Atrás", false);
            GetComponent<Animator>().SetBool("Andando Para Direita", false);
        }

        else if(vertical > 0)
        {
            GetComponent<Animator>().SetBool("Andando Para Atrás", true);
            GetComponent<Animator>().SetBool("Parado de Costas", true);
            GetComponent<Animator>().SetBool("Parado de Frente", false);
            GetComponent<Animator>().SetBool("Parado Esquerda", false);
            GetComponent<Animator>().SetBool("Parado Direita", false);
            GetComponent<Animator>().SetBool("Andando Para Frente", false);
            GetComponent<Animator>().SetBool("Andando Para Esquerda", false);
            GetComponent<Animator>().SetBool("Andando Para Direita", false);
        }
        if(horizontal < 0)
        {
            GetComponent<Animator>().SetBool("Andando Para Esquerda", true);
            GetComponent<Animator>().SetBool("Parado Esquerda", true);
            GetComponent<Animator>().SetBool("Parado de Costas", true);
            GetComponent<Animator>().SetBool("Parado de Frente", true);
            GetComponent<Animator>().SetBool("Parado Direita", false);
            GetComponent<Animator>().SetBool("Andando Para Frente", false);
            GetComponent<Animator>().SetBool("Andando Para Atrás", false);
            GetComponent<Animator>().SetBool("Andando Para Direita", false);

        }
        
        else if(horizontal > 0)
        {
            GetComponent<Animator>().SetBool("Andando Para Direita", true);
            GetComponent<Animator>().SetBool("Parado Direita", true);
            GetComponent<Animator>().SetBool("Parado de Costas", false);
            GetComponent<Animator>().SetBool("Parado de Frente", false);
            GetComponent<Animator>().SetBool("Parado Esquerda", false);
            GetComponent<Animator>().SetBool("Andando Para Esquerda", false);
            GetComponent<Animator>().SetBool("Andando Para Frente", false);
            GetComponent<Animator>().SetBool("Andando Para Atrás", false);
        }

        if(horizontal == 0 && vertical == 0)
        {
            GetComponent<Animator>().SetBool("Andando Para Frente", false);
            GetComponent<Animator>().SetBool("Andando Para Atrás", false);
            GetComponent<Animator>().SetBool("Andando Para Esquerda", false);
            GetComponent<Animator>().SetBool("Andando Para Direita", false);
        }
        if (horizontal < 0 && vertical < 0)
        {
            GetComponent<Animator>().SetBool("Parado de Frente", true);
            GetComponent<Animator>().SetBool("Andando Para Frente", true);
            GetComponent<Animator>().SetBool("Andando Para Esquerda", false);
            GetComponent<Animator>().SetBool("Parado Esquerda", false);
            GetComponent<Animator>().SetBool("Parado de Costas", false);
            GetComponent<Animator>().SetBool("Parado Direita", false);
            GetComponent<Animator>().SetBool("Andando Para Atrás", false);
            GetComponent<Animator>().SetBool("Andando Para Direita", false);
        }

        if (horizontal < 0 && vertical > 0)
        {
            GetComponent<Animator>().SetBool("Parado de Costas", true);
            GetComponent<Animator>().SetBool("Andando Para Atrás", true);
            GetComponent<Animator>().SetBool("Parado de Frente", false);
            GetComponent<Animator>().SetBool("Andando Para Frente", false);
            GetComponent<Animator>().SetBool("Andando Para Esquerda", false);
            GetComponent<Animator>().SetBool("Parado Esquerda", false);
            GetComponent<Animator>().SetBool("Parado Direita", false);
            GetComponent<Animator>().SetBool("Andando Para Direita", false);
        }
        if (horizontal > 0 && vertical < 0)
        {
            GetComponent<Animator>().SetBool("Parado de Frente", true);
            GetComponent<Animator>().SetBool("Andando Para Frente", true);
            GetComponent<Animator>().SetBool("Andando Para Esquerda", false);
            GetComponent<Animator>().SetBool("Parado Esquerda", false);
            GetComponent<Animator>().SetBool("Parado de Costas", false);
            GetComponent<Animator>().SetBool("Parado Direita", false);
            GetComponent<Animator>().SetBool("Andando Para Atrás", false);
            GetComponent<Animator>().SetBool("Andando Para Direita", false);
        }

        if (horizontal > 0 && vertical > 0)
        {
            GetComponent<Animator>().SetBool("Parado de Costas", true);
            GetComponent<Animator>().SetBool("Andando Para Atrás", true);
            GetComponent<Animator>().SetBool("Parado de Frente", false);
            GetComponent<Animator>().SetBool("Andando Para Frente", false);
            GetComponent<Animator>().SetBool("Andando Para Esquerda", false);
            GetComponent<Animator>().SetBool("Parado Esquerda", false);
            GetComponent<Animator>().SetBool("Parado Direita", false);
            GetComponent<Animator>().SetBool("Andando Para Direita", false);
        }

    }
}
