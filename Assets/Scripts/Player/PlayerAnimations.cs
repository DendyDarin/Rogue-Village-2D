using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // -- PARAMETER --

    private readonly int moveX = Animator.StringToHash("MoveX"); //technique to avoid misspelling in string references
    private readonly int moveY = Animator.StringToHash("MoveY");
    private readonly int moving = Animator.StringToHash("Moving"); //hash to boolean moving
    private readonly int dead = Animator.StringToHash("Dead");
    private readonly int revive = Animator.StringToHash("Revive");

    private Animator animator; // refers to animator setting

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetDeadAnimation()
    {
        animator.SetTrigger(dead);
    }

    //method to back and forth between idle and move
    public void SetMoveBoolTransition(bool value)
    {
        animator.SetBool(moving, value);
    }

    public void SetMoveAnimation(Vector2 dir)
    {
        animator.SetFloat(moveX, dir.x);
        animator.SetFloat(moveY, dir.y);
    }

    public void ResetPlayer()
    {
        // player will in idle mode when revive
        SetMoveAnimation(Vector2.down);
        animator.SetTrigger(revive);
    }
}
