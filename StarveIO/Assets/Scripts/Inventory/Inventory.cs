using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private Action<Item> _useItemAction;

    private List<Item> _itemList;

    public Inventory(Action<Item> _useItemAction)
    {
        this._useItemAction = _useItemAction;

        _itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.WoodenPickaxe, Amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Meat, Amount = 5 });
        AddItem(new Item { itemType = Item.ItemType.Berry, Amount = 13 });
        AddItem(new Item { itemType = Item.ItemType.WoodenSword, Amount = 1 });
    }

    public void AddItem(Item _item)
    {
        if (_item.IsStackable())
        {
            bool _itemAlreadyInList = false;
            foreach (Item _inventoryItem in _itemList)
            {
                if (_inventoryItem.itemType == _item.itemType)
                {
                    _inventoryItem.Amount += _item.Amount;
                    _itemAlreadyInList = true;
                }
            }
            if (!_itemAlreadyInList)
            {
                _itemList.Add(_item);
            }
        }
        else
            _itemList.Add(_item);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item _item)
    {
        if (_item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in _itemList)
            {
                if (inventoryItem.itemType == _item.itemType)
                {
                    inventoryItem.Amount -= _item.Amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.Amount <= 0)
            {
                _itemList.Remove(itemInInventory);
            }
        }
        else
        {
            _itemList.Remove(_item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public void UseItem(Item _item)
    {
        _useItemAction(_item);
    }

    public List<Item> GetItemList()
    {
        return _itemList;
    }
}