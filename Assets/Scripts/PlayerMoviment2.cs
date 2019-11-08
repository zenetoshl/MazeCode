﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Rewired;

public class PlayerMoviment2 : MonoBehaviour
{
    public int playerId;
    //Player player;
    public Vector2 movementDirection;
    public float velocidade;
    public float MOVEMENT_BASE_SPEED = 1.0f;
    public Animator animator;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {

        ProcessInputs();
        Move();
        Animate();
    }
    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocidade = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }
    void Move()
    {
        rb.velocity = movementDirection * velocidade * MOVEMENT_BASE_SPEED;
    }
        
    void Animate()
    {
        if(movementDirection != Vector2.zero)
        {
            animator.SetFloat("X", movementDirection.x);
            animator.SetFloat("Y", movementDirection.y);
        }
        animator.SetFloat("speed", velocidade);
    }
}
