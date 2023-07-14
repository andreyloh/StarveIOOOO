using UnityEngine;

public class SystemTimer : MonoBehaviour
{
    [SerializeField] private float _cooldown;
    [Space(15)]
    [SerializeField] private int _starvation;
    [SerializeField] private int _freezingDay;
    [SerializeField] private int _freezingNight;
    [SerializeField] private int _dehydration;

    private HungerSystem _hungerSystem;
    private WaterSystem _waterSystem;
    private TemperatureSystem _temperatureSystem;

    private Temperature _temperature;

    private float _timer;

    private void Start()
    {
        _hungerSystem = FindObjectOfType<HungerSystem>();
        _temperatureSystem = FindObjectOfType<TemperatureSystem>();
        _temperature = _temperatureSystem.Temperature;
        _waterSystem = FindObjectOfType<WaterSystem>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _cooldown)
        {
            _hungerSystem.TakeValue(_starvation);
            _waterSystem.TakeValue(_dehydration);
            _timer = 0f;

            if (_temperatureSystem.Day)
                _temperatureSystem.TakeValue(_freezingDay);
            else if (!_temperatureSystem.Day)
                _temperatureSystem.TakeValue(_freezingNight);
        }
    }
}