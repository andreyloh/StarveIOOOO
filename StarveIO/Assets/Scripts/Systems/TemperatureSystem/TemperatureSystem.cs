using UnityEngine;

public class TemperatureSystem : MonoBehaviour
{
    public Temperature Temperature;
    private TemperatureBar _temperatureBar;

    public bool Day;

    private void Awake()
    {
        Temperature = new(100, 100);

        _temperatureBar = FindObjectOfType<TemperatureBar>();
    }

    public void AddValue(int _amount)
    {
        if (Temperature.CurrentTemperature + _amount > Temperature.MaxTemperature)
        {
            Temperature.CurrentTemperature = Temperature.MaxTemperature;
            _temperatureBar.IncreaseBar(_amount);

            Temperature.CurrentOverTemperature = _amount - (Temperature.MaxTemperature
                - Temperature.CurrentOverTemperature);
            _temperatureBar.IncreaseOverBar(_amount - (Temperature.MaxTemperature
                - Temperature.CurrentOverTemperature));

            if (Temperature.CurrentOverTemperature > Temperature.MaxOverTemperature)
            {
                Temperature.CurrentOverTemperature = Temperature.MaxOverTemperature;
                _temperatureBar.SetOverCurrentValue(Temperature.MaxOverTemperature);
            }
        }
    }

    public void TakeValue(int _amount)
    {
        if (Temperature.CurrentOverTemperature != 0)
        {
            if (Temperature.CurrentOverTemperature - _amount >= 0)
            {
                Temperature.CurrentOverTemperature -= _amount;
                _temperatureBar.DecreaseOverBar(_amount);
            }
            else if (Temperature.CurrentOverTemperature - _amount < 0)
            {
                _amount -= Temperature.CurrentOverTemperature;
                Temperature.CurrentOverTemperature = 0;
                _temperatureBar.SetOverCurrentValue(0);

                Temperature.CurrentTemperature -= _amount;
                _temperatureBar.SetCurrentValue(Temperature.CurrentTemperature);
            }
        }
        else if (Temperature.CurrentOverTemperature == 0)
        {
            Temperature.CurrentTemperature -= _amount;
            _temperatureBar.DecreaseBar(_amount);
        }
    }

    public int GetCurrentTemperature()
    {
        return Temperature.CurrentTemperature;
    }
}
