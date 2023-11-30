using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public FSMState CurrentState { get; set; }

    private void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void ChangeState(string newStateID)
    {

    }
}
