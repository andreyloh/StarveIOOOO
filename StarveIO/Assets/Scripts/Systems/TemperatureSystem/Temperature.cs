public class Temperature
{
    public int MaxTemperature;
    public int CurrentTemperature;

    public int MaxOverTemperature;
    public int CurrentOverTemperature;

    public Temperature(int _maxTemperature, int _maxOverTemperature)
    {
        MaxTemperature = _maxTemperature;
        CurrentTemperature = MaxTemperature;

        MaxOverTemperature = _maxOverTemperature;
        CurrentOverTemperature = 30;
    }
}
