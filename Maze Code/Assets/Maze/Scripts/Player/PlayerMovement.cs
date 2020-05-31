using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    walk,
    attack,
    interact,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    protected Joystick joystick;
    private Touch oneTouch;
    private Vector2 touchPosition;
    private Vector2 moveDirection;

    public PlayerState currentState;
    private Rigidbody2D myRigidbody;
    public float speed;
    
    private Vector3 change;
    private Animator animator;
    //public VectorValue startingPosition;
    public Inventory playerInventory;
    public SpriteRenderer receivedItemSprite;

    // Use this for initialization
    void Start() {
        joystick = FindObjectOfType<Joystick>();
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        //transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void FixedUpdate() {
        
        // Is the player in an interaction
        if(currentState == PlayerState.interact)
        {
            return;
        }
        change = Vector3.zero;
        change.x = joystick.Horizontal;
        change.y = joystick.Vertical;

        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }

        if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        // When you attack, switch to this:
        animator.SetBool("moving", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("moving", false);
        yield return new WaitForSeconds(.3f);
        if(currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }
    
    public void RaiseItem()
    {
        if(playerInventory.currentItem != null)
        {
            if(currentState != PlayerState.interact)
            {
                animator.SetBool("receive item", true);
                currentState = PlayerState.interact;
                receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            } else {
                animator.SetBool("receive item", false);
                currentState = PlayerState.idle;
                receivedItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }
    }
    
    void UpdateAnimationAndMove()
    {
        if(change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        } else {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }
}