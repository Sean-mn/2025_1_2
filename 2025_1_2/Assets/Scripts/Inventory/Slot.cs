using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SlotData
{
    public GetableItem item;
    public int count;

    public SlotData(GetableItem newItem,  int count)
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

    private GetableItem _item;
    private int _count;

    public void SetItemSlot(GetableItem newItem, int count)
    {
        _item = newItem;
        _count = count;
        _itemImage.sprite = newItem.GetItem().ItemImage;
        _itemImage.enabled = true;
        _itemAmountTxt.text = count > 1 ? count.ToString() : "";
    }

    public void ClearSlot()
    {
        _item = null;
        _count = 0;
        _itemImage.sprite = null;
        _itemImage.enabled = false;
        _itemAmountTxt.text = "";
    }
}
