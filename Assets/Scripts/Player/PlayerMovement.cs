using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // -- PARAMETER --
    [Header("Config")]
    [SerializeField] private float speed;

    // -- REFERENCES --
    private PlayerActions actions; //refers to class we create before in Actions folder
    private Rigidbody2D rb2D; //refers to rigidbody2d component
    private PlayerAnimations playerAnimations; // reference to PlayerAnimations class
    private Player player;
    private Vector2 moveDirection;

    private void Awake()
    {
        player = GetComponent<Player>();
        actions = new PlayerActions(); //we need to toggle this
        rb2D = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
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
        if (player.Stats.Health <= 0) return; // if this true then ignore code below
        rb2D.MovePosition(rb2D.position + moveDirection * (speed * Time.fixedDeltaTime)); //use fixedDeltaTime to ignore the frame rate (independent)
    }

    //method to read PlayerActions
    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized; //access to PlayerActions value
        // conditional if player in 0,0 position, animation not run
        if (moveDirection == Vector2.zero)
        {
            playerAnimations.SetMoveBoolTransition(false);
            return;
        }
        // if player does move, run this code
        playerAnimations.SetMoveBoolTransition(true);
        playerAnimations.SetMoveAnimation(moveDirection);
    }

    //method for toggle in awake method
    private void OnEnable() {
        actions.Enable();
    }

    private void OnDisable() {
        actions.Disable();
    }
}
