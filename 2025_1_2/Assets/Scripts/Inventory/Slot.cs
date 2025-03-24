using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SlotData
{
    public Item item;
    public int count;

    public SlotData(Item newItem,  int count)
    {
        this.item = newItem;
        this.count = count;
    }
}

public class Slot : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private Text _itemAmountTxt;
    [SerializeField] Button _itemUseBtn;

    private Item _item;
    private int _count;

    private void Start()
    {
        _itemUseBtn.onClick.AddListener(UseItem);
    }

    public void SetItemSlot(Item newItem, int count)
    {
        _item = newItem;
        _count = count;

        _itemImage.sprite = newItem.ItemImage;
        _itemImage.enabled = true;
        _itemAmountTxt.text = count > 1 ? count.ToString() : "";

        if (newItem.CanUse)
        {
            _itemUseBtn.gameObject.SetActive(true);
        }
        else
        {
            _itemUseBtn.gameObject.SetActive(false);
        }
    }

    public void ClearSlot()
    {
        _item = null;
        _count = 0;
        _itemImage.sprite = null;
        _itemImage.enabled = false;
        _itemAmountTxt.text = "";
        _itemUseBtn.gameObject.SetActive(false);
    }

    public void UseItem()
    {
        Debug.Log($"아이템 사용: {_item.name}");

        Inventory inventory = FindObjectOfType<Inventory>();
        _item.UseItem();
        inventory.RemoveItem(_item);

        if (_count <= 0)
            ClearSlot();
    }
}
