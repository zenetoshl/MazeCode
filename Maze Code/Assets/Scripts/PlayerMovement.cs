using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    walk, 
    attack,
    interact, 
    stagger, 
    idle
}
public class PlayerMovement : MonoBehaviour
{
    protected Joystick joystick;
    [SerializeField]
    private GameObject circle, dot;

    private Touch oneTouch;
    private Vector2 touchPosition;
    private Vector2 moveDirection;

    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    /**/private Vector3 change;
    private Animator animator;
    public VectorValue startingPosition;
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
        transform.position = startingPosition.initialValue;

        circle.SetActive(false);
        dot.SetActive(false);


    }

    // Update is called once per frame
    void FixedUpdate() {
        
        // Is the player in an interaction
        if(currentState == PlayerState.interact)
        {
            return;
        }
        /* */
        change = Vector3.zero;
        change.x = joystick.Horizontal;
        change.y = joystick.Vertical;

        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack
            && currentState != PlayerState.stagger)
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
        animator.SetBool("moving", true); //animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("moving", false); //animator.SetBool("attacking", false);
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
        /*
        if(Input.touchCount > 0)
        {
            oneTouch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(oneTouch.position);

            switch (oneTouch.phase) 
            {
                case TouchPhase.Began:
                    circle.SetActive(true);
                    dot.SetActive(true);
                    circle.transform.position = touchPosition;
                    dot.transform.position = touchPosition;
                    break;
                case TouchPhase.Stationary:
                    MoveCharacter();
                    animator.SetFloat("moveX", moveDirection.x);
                    animator.SetFloat("moveY", moveDirection.y);
                    animator.SetBool("moving", true);
                    break;
                case TouchPhase.Moved:
                    animator.SetFloat("moveX", moveDirection.x);
                    animator.SetFloat("moveY", moveDirection.y);
                    animator.SetBool("moving", true);
                    MoveCharacter();
                    break;
                case TouchPhase.Ended:
                    circle.SetActive(false);
                    dot.SetActive(false);
                    animator.SetBool("moving", false);
                    break;
            }
        }
        */
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
        /*
        dot.transform.position = touchPosition;

        dot.transform.position = new Vector2(
            Mathf.Clamp(dot.transform.position.x,
            circle.transform.position.x - 0.8f,
            circle.transform.position.x + 0.8f),
            Mathf.Clamp(dot.transform.position.y,
            circle.transform.position.y - 0.8f,
            circle.transform.position.y + 0.8f));

        moveDirection = (dot.transform.position - circle.transform.position).normalized;
        myRigidbody.velocity = moveDirection * speed;
        */
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }
}
