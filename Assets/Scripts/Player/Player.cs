using UnityEngine;

// to store references of our classes (exp, health, mana etc)
public class Player : MonoBehaviour
{
    // -- PARAMETER --

    // -- REFERENCES --
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    public PlayerStats Stats => stats; //make new public variable refers to private
}
