using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // PARAMETER
    [Header("Config")]
    [SerializeField] private float speed;

    private readonly int moveX = Animator.StringToHash("MoveX"); //technique to avoid misspelling in string references
    private readonly int moveY = Animator.StringToHash("MoveY");
    private readonly int moving = Animator.StringToHash("Moving"); //hash to boolean moving

    // REFERENCES
    private PlayerActions actions; //refers to class we create before in Actions folder
    private Rigidbody2D rb2D; //refers to rigidbody2d component
    private Animator animator; // refers to animator setting
    private Vector2 moveDirection;

    private void Awake() {
        actions = new PlayerActions(); //we need to toggle this
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    //call methode ReadMovement
    private void Update()
    {
        ReadMovement();
    }

    //call methode Move in fixedupdate
    private void FixedUpdate() {
        Move();    
    }

    //method to Player move
    private void Move()
    {
        rb2D.MovePosition(rb2D.position + moveDirection * (speed * Time.fixedDeltaTime)); //use fixedDeltaTime to ignore the frame rate (independent)
    }

    //method to read PlayerActions
    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized; //access to PlayerActions value
        // conditional if player in 0,0 position, animation not run
        if (moveDirection == Vector2.zero)
        {
            animator.SetBool(moving, false);
            return;
        }
        // if player does move, run this code
        animator.SetBool(moving, true);
        animator.SetFloat(moveX, moveDirection.x);
        animator.SetFloat(moveY, moveDirection.y);
    }

    //method for toggle in awake method
    private void OnEnable() {
        actions.Enable();
    }

    private void OnDisable() {
        actions.Disable();
    }
}
