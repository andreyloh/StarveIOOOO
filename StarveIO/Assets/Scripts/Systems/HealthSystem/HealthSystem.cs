using UnityEngine;

public class HealthSystem : MonoBehaviour, ISystem
{
    public Health Health;

    private HealthBar _healthBar;

    private void Awake()
    {
        Health = new(100);

        _healthBar = FindObjectOfType<HealthBar>();
    }

    public void AddValue(int _amount)
    {
        Health.CurrenthHealth += _amount;

        if (Health.CurrenthHealth > Health.MaxHealth)
            Health.CurrenthHealth = Health.MaxHealth;

        _healthBar.IncreaseBar(_amount);
    }

    public void TakeValue(int _amount)
    {
        Health.CurrenthHealth -= _amount;

        if (Health.CurrenthHealth < 0)
            Health.CurrenthHealth = 0;

        _healthBar.DecreaseBar(_amount);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            TakeValue(15);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            AddValue(15);
        }
    }
}