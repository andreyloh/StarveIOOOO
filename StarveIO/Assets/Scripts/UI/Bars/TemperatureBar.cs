using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class TemperatureBar : MonoBehaviour, IBar
{
    private Slider _normalTemperatureSlider;
    private Slider _overTemperatureSlider;

    [SerializeField] private Temperature _temperature;

    private void Awake()
    {
        _normalTemperatureSlider = GetComponent<Slider>();
        _overTemperatureSlider = FindObjectOfType<OverTemperatureBar>().GetComponent<Slider>();
    }

    private void Start()
    {
        _temperature = FindObjectOfType<TemperatureSystem>().Temperature;

        SetMaxValue(_temperature.MaxTemperature);
        SetOverMaxValue(_temperature.MaxOverTemperature);
    }

    public void SetMaxValue(int _amount)
    {
        _normalTemperatureSlider.maxValue = _amount;
        _normalTemperatureSlider.value = _amount;
    }

    public void SetCurrentValue(int _amount)
    {
        _normalTemperatureSlider.value = _amount;
    }

    public void IncreaseBar(int _amount)
    {
        _normalTemperatureSlider.value += _amount;
    }

    public void DecreaseBar(int _amount)
    {
        _normalTemperatureSlider.value -= _amount;
    }

    public void SetOverMaxValue(int _amount)
    {
        _overTemperatureSlider.maxValue = _amount;
        _overTemperatureSlider.value = 0;
    }

    public void SetOverCurrentValue(int _amount)
    {
        _overTemperatureSlider.value = _amount;
    }

    public void IncreaseOverBar(int _amount)
    {
        _overTemperatureSlider.value += _amount;
    }

    public void DecreaseOverBar(int _amount)
    {
        _overTemperatureSlider.value -= _amount;
    }
}
