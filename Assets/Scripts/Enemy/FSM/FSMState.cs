using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// - logic to all states

[Serializable]
public class FSMState
{
    public string ID; // every state need an ID
    public FSMAction[] Actions; // every state can perform different action & transition
    public FSMTransition[] Transitions;

    // -- method

    public void UpdateState(EnemyBrain enemyBrain)
    {
        ExecuteActions();
        ExecuteTransitions(enemyBrain);
    }

    private void ExecuteTransitions(EnemyBrain enemyBrain)
    {
        throw new NotImplementedException();
    }

    private void ExecuteActions()
    {
        for (int i = 0; i < Actions.Length; i++)
        {
            Actions[i].Act(); // call each action available
        }
    }
}
