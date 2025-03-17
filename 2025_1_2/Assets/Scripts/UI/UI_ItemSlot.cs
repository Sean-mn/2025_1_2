using UnityEngine;
using UnityEngine.UI;

public class UI_ItemSlot : UI
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private Text _itemCountTxt;

    protected override void InitUI() { }
    public void SetItemSlot(Sprite itemImage, int itemCount)
    {
        if (_itemImage != null)
            _itemImage.sprite = itemImage;

        if (_itemCountTxt != null)
            _itemCountTxt.text = itemCount.ToString();
    }
}
