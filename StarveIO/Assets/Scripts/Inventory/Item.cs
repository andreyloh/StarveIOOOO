using UnityEngine;

public class Item
{
    public enum ItemType
    {
        WoodenSword,
        WoodenPickaxe,
        Berry,
        Meat,
    }

    public ItemType itemType;
    public int Amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.WoodenSword: return ItemAssets.Instance.WoodenSword;
            case ItemType.Berry: return ItemAssets.Instance.Berry;
            case ItemType.Meat: return ItemAssets.Instance.Meat;
            case ItemType.WoodenPickaxe: return ItemAssets.Instance.WoodenPickaxe;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Berry:
            case ItemType.Meat:
                return true;
            case ItemType.WoodenSword:
            case ItemType.WoodenPickaxe:
                return false;
        }
    }
}