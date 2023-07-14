using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class WaterBar : MonoBehaviour
{
    private Slider _slider;

    [SerializeField] private Water _water;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _water = FindObjectOfType<WaterSystem>().Water;

        SetMaxValue(_water.MaxWater);
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
