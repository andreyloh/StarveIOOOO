using UnityEngine;

public class WaterSystem : MonoBehaviour
{
    public Water Water;

    private WaterBar _waterBar;

    private void Awake()
    {
        Water = new(100);

        _waterBar = FindObjectOfType<WaterBar>();
    }

    public void AddValue(int _amount)
    {
        Water.CurrentWater += _amount;

        if (Water.CurrentWater > Water.MaxWater)
            Water.CurrentWater = Water.MaxWater;

        _waterBar.IncreaseBar(_amount);
    }

    public void TakeValue(int _amount)
    {
        Water.CurrentWater -= _amount;

        if (Water.CurrentWater < 0)
            Water.CurrentWater = 0;

        _waterBar.DecreaseBar(_amount);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            AddValue(15);
        }
    }

    public int GetCurrentWater()
    {
        return Water.CurrentWater;
    }
}