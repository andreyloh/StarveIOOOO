using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour, IBar
{
    private Slider _slider;
    private Health _health;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _health = FindObjectOfType<HealthSystem>().Health;

        SetMaxValue(_health.MaxHealth);
    }

    public void SetMaxValue(int _amount)
    {
        _slider.maxValue = _amount;
        _slider.value = _amount;
    }

    public void SetCurrentValue(int _amount)
    {
        _slider.value = _amount;
    }

    public void IncreaseBar(int _amount)
    {
        _slider.value += _amount;
    }

    public void DecreaseBar(int _amount)
    {
        _slider.value -= _amount;
    }
}
