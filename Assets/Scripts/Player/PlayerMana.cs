using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    // -- references
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    // -- method

    // for use mana testing
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UseMana(1f);
        }
    }

    public void UseMana(float amount)
    {
        // logic: if current mana is greater than amount then mana will spent
        if (stats.Mana >= amount)
        {
            // check which has max value
            stats.Mana = Mathf.Max(stats.Mana -= amount, 0f); // simplified version of code below

            //stats.Mana -= amount;
            //// then check is current mana is zero then reset stats.Mana to zero
            //if (stats.Mana <= 0f)
            //{
            //    stats.Mana = 0f;
            //}
        }
    }
}
