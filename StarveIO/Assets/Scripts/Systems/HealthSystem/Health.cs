using UnityEngine;

public class Health
{
    public int CurrenthHealth;
    public int MaxHealth;

    public Health(int _maxValue)
    {
        MaxHealth = _maxValue;
        CurrenthHealth = MaxHealth;
    }
}
