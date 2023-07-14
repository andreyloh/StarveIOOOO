using UnityEngine;

public class HungerSystem : MonoBehaviour, ISystem
{
    public Hunger Hunger;

    private MeatBar _meatBar;

    private void Awake()
    {
        Hunger = new(100);

        _meatBar = FindObjectOfType<MeatBar>();
    }

    public void AddValue(int _amount)
    {
        Hunger.CurrentHunger += _amount;

        if (Hunger.CurrentHunger > Hunger.MaxHunger)
            Hunger.CurrentHunger = Hunger.MaxHunger;

        _meatBar.IncreaseBar(_amount);
    }

    public void TakeValue(int _amount)
    {
        Hunger.CurrentHunger -= _amount;

        if (Hunger.CurrentHunger < 0)
            Hunger.CurrentHunger = 0;

        _meatBar.DecreaseBar(_amount);

    }

    public int GetCurrentHunger()
    {
        return Hunger.CurrentHunger;
    }
}