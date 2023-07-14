using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Eat Parameters")]
    [SerializeField] private int _berry;
    [SerializeField] private int _meat;

    [SerializeField] private UI_Inventory _uiInventory;

    private Inventory _inventory;
    private HungerSystem _hungerSystem;

    private void Awake()
    {
        _inventory = new Inventory(UseItem);
        _uiInventory.SetInventory(_inventory);
    }

    private void Start()
    {
        _hungerSystem = FindObjectOfType<HungerSystem>();
    }

    private void UseItem(Item _item)
    {
        switch (_item.itemType)
        {
            case Item.ItemType.Berry:
                _hungerSystem.AddValue(_berry);
                break;
            case Item.ItemType.Meat:
                _hungerSystem.AddValue(_meat);
                break;
        }
    }
}