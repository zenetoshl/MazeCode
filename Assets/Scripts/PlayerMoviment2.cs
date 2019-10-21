using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment2 : MonoBehaviour
{
    public Animator animator;
    public float velocidade;

    // Update is called once per frame
    void Update()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        animator.SetFloat("X", movimento.x);
        animator.SetFloat("Y", movimento.y);
        animator.SetFloat("velocidade", movimento.magnitude);

        transform.position = transform.position + movimento * velocidade * Time.deltaTime;
    }
}
