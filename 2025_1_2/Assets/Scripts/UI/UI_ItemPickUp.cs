using UnityEngine;

public class UI_ItemPickUp : UI
{
    [SerializeField] private GameObject _itemPickUpPanel;

    protected override void InitUI()
    {
        _itemPickUpPanel?.SetActive(false);
    }

    public void UIFunction(bool isActive)
    {
        _itemPickUpPanel?.SetActive(isActive);
    }
}
