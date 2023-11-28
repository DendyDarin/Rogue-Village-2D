using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    // -- parameter

    // -- reference
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    // -- method
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddExp(300f);
        }
    }

    public void AddExp(float amount)
    {
        stats.CurrentExp += amount;
        while (stats.CurrentExp >= stats.NextLevelExp)
        {
            // this will reset exp to 0 when player reach next level
            stats.CurrentExp -= stats.NextLevelExp;
            NextLevel();
        }
    }

    private void NextLevel()
    {
        // increase level
        stats.Level++;

        // variable for store nextlevelexp value
        float currentExpRequired = stats.NextLevelExp;

        // calculate new next level exp
        float newNextLevelExp = Mathf.Round(currentExpRequired + stats.NextLevelExp * (stats.ExpMultiplier / 100f));

        // assign to nextlevelexp
        stats.NextLevelExp = newNextLevelExp;
    }
}
