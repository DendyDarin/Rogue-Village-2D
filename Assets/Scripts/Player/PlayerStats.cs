using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Stats")] //require to scriptable object

public class PlayerStats : ScriptableObject
{
    // -- parameter

    [Header("Config")]
    public int Level;

    [Header("Health")]
    public float Health;
    public float MaxHealth;

    [Header("Mana")]
    public float Mana;
    public float MaxMana;

    [Header("Exp")]
    public float CurrentExp;
    public float NextLevelExp;
    public float InitialNextLevelExp;
    [Range(1f, 100f)] public float ExpMultiplier;

    // require to custom editor button
    public void ResetPlayer()
    {
        Health = MaxHealth;
        Mana = MaxMana;
        Level = 1;
        CurrentExp = 0f;
        NextLevelExp = InitialNextLevelExp;
    }
}
