using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // PARAMETER
    [Header("Config")]
    [SerializeField] private float speed;

    // REFERENCES
    private PlayerActions actions; //refers to class we create before in Actions folder
    private Rigidbody2D rb2D; //refers to rigidbody2d component
    private Vector2 moveDirection;

    private void Awake() {
        actions = new PlayerActions(); //we need to enable this
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
    }

    //method for toggle in awake method
    private void OnEnable() {
        actions.Enable();
    }

    private void OnDisable() {
        actions.Disable();
    }
}
