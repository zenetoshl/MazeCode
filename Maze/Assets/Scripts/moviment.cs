using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class moviment : MonoBehaviour
{
    public Animator animator;
    public float velocidade = 3f;
    private float horizontal = 0;
    private float vertical = 0;
    float abs(float n) { return n > 0 ? n : -n; }

    void Update(){
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
    }
    
    void FixedUpdate()
    {
        if (abs(horizontal) >= abs(vertical)){
            vertical = 0;
            if (horizontal < -0.3)
                horizontal = -1;
            else if (horizontal > 0.3)
                horizontal = 1;
        } else {
            horizontal = 0;
            if (vertical < -0.3)
                vertical = -1;
            else if (vertical > 0.3)
                vertical = 1;
        }
        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);

        Vector3 moviment = new Vector3(horizontal, vertical, 0.0f);
        transform.position = velocidade * moviment * Time.deltaTime + transform.position;
    }
}
