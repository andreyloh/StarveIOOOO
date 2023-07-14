using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private float _itemSlotCellSize;

    private Inventory _inventory;
    [SerializeField] private Transform _itemSlotContainer;
    [SerializeField] private Transform _itemSlotTemplate;

    public void SetInventory(Inventory _inventory)
    {
        this._inventory = _inventory;

        _inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform _child in _itemSlotContainer)
        {
            if (_child == _itemSlotTemplate)
                continue;
            Destroy(_child.gameObject);
        }

        int _x = 0;
        int _y = 0;
        foreach (Item _item in _inventory.GetItemList())
        {
            RectTransform _itemSlotRectTransform = Instantiate(_itemSlotTemplate, _itemSlotContainer)
                .GetComponent<RectTransform>();
            _itemSlotRectTransform.gameObject.SetActive(true);

            _itemSlotRectTransform.GetComponent<ButtonUI>().ClickFunc = () =>
            {
                if (_item.Amount > 1)
                    _item.Amount--;
                else if (_item.Amount == 1)
                    _inventory.RemoveItem(_item);

                _inventory.UseItem(_item);
                RefreshInventoryItems();
            };
            _itemSlotRectTransform.GetComponent<ButtonUI>().MouseRightClickFunc = () =>
            {
                Item _duplicateItem = new Item { itemType = _item.itemType, Amount = _item.Amount };
                _inventory.RemoveItem(_item);
            };



            _itemSlotRectTransform.anchoredPosition = new Vector2(_x * _itemSlotCellSize,
                _y * _itemSlotCellSize);
            Image _itemImage = _itemSlotRectTransform.Find("ItemImage").GetComponent<Image>();
            _itemImage.gameObject.SetActive(true);
            _itemImage.sprite = _item.GetSprite();

            TextMeshProUGUI _text = _itemSlotRectTransform.Find("Text").GetComponent<TextMeshProUGUI>();
            if (_item.Amount > 1)
                _text.SetText("x" + _item.Amount.ToString());
            else
            {
                _text.SetText("");
            }

            _x++;
        }
    }   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _inventory.AddItem(new Item { itemType = Item.ItemType.Berry, Amount = 1 });
        }
    }
}