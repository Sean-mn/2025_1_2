using UnityEngine;
using UnityEngine.UI;

public class UI_SellTreasure : UI
{
    [SerializeField] private GameObject _sellTreasurePanel;
    [SerializeField] private Text _sellTreasureTxt;

    protected override void InitUI()
    {
        _sellTreasurePanel?.SetActive(false);
    }

    public void UIFunction(bool isActive)
    {
        _sellTreasurePanel?.SetActive(isActive);
        SetTextMsg(isActive);
    }

    private void SetTextMsg(bool isSellable)
    {
        
    }
}
