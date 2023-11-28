using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Stats")] //require to scriptable object

public class PlayerStats : ScriptableObject
{
    [Header("Config")]
    public int Level;

    [Header("Health")]
    public float Health;
    public float MaxHealth;

    [Header("Mana")]
    public float Mana;
    public float MaxMana;

    // require to custom editor button
    public void ResetPlayer()
    {
        Health = MaxHealth;
        Mana = MaxMana;
    }
}
