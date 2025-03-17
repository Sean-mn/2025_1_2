using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_ItemSlot : UI
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private Text _itemCountTxt;
    [SerializeField] private Button _useItemBtn;

    private Item _currentItem;

    protected override void InitUI() { }
    public void SetItemSlot(Item item ,Sprite itemImage, int itemCount)
    {
        _currentItem = item;

        if (_itemImage != null)
            _itemImage.sprite = itemImage;

        if (_itemCountTxt != null)
            _itemCountTxt.text = itemCount.ToString();

        if (_useItemBtn != null)
        {
            _useItemBtn.onClick.RemoveAllListeners();
            _useItemBtn.onClick.AddListener(OnUseItemClicked);
            Debug.Log("아이템 사용 가능!");
        }
    }

    private void OnUseItemClicked()
    {
        if (_currentItem != null)
            _currentItem.GetableItem.UseItem();
        else
            Debug.Log("오루@#@#");
    }
}
