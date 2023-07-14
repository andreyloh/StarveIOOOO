using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MeatBar : MonoBehaviour, IBar
{
    private Slider _slider;

    [SerializeField] private Hunger _hunger;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _hunger = FindObjectOfType<HungerSystem>().Hunger;

        SetMaxValue(_hunger.MaxHunger);
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
