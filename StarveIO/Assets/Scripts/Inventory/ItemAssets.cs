using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite Berry;
    public Sprite Meat;
    public Sprite WoodenPickaxe;
    public Sprite WoodenSword;
}