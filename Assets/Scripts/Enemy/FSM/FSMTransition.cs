using System;
using UnityEngine;

[Serializable]
public class FSMTransition : MonoBehaviour
{
    public FSMDecision Decision; // ex: if we create method referencing to this class called PlayerInAttackRange it will create two condition true or false
    public string TrueState;
    public string FalseState;
}
