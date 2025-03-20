using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : UI
{
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private Inventory _inventory;
    private bool _isInventoryActive = false;

    [Header("아이템 슬롯")]
    [SerializeField] private List<Slot> _itemSlots = new();
    [SerializeField] private GameObject _itemSlotPrefab;
    [SerializeField] private Transform _itemSlotsParent;

    protected override void InitUI()
    {
        _inventoryPanel.SetActive(false);
        SetItemSlots(4);
        _inventory.onInventoryChanged += UpdateInventoryUI;
    }

    private void Update()
    {
        TryOpenInventory();
    }

    #region 인벤토리 열기/닫기
    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(Define.Keys.OpenInventory))
        {
            _isInventoryActive = !_isInventoryActive;

            if (_isInventoryActive)
                OpenInventory();
            else
                CloseInventory();
        }
    }

    private void OpenInventory()
    {
        _inventoryPanel.SetActive(true);
        Managers.Util.UnLockCursor();
        UpdateInventoryUI();
    }
    private void CloseInventory()
    {
        _inventoryPanel?.SetActive(false);
        Managers.Util.LockCursor();
    }
    #endregion

    private void SetItemSlots(int size)
    {
        foreach (Transform child in _itemSlotsParent)
        {
            Destroy(child.gameObject);
        }
        _itemSlots.Clear();

        for (int i = 0; i < size; i++)
        {
            GameObject slotObj = Instantiate(_itemSlotPrefab, _itemSlotsParent);
            Slot slot = slotObj.GetComponent<Slot>();
            _itemSlots.Add(slot);
        }

        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        List<SlotData> inventoryData = _inventory.GetInventoryData();

        for (int i = 0; i < _itemSlots.Count; i++)
        {
            if (i < inventoryData.Count && inventoryData[i] != null)
            {
                _itemSlots[i].SetItemSlot(inventoryData[i].item, inventoryData[i].count);
            }
            else
            {
                _itemSlots[i].ClearSlot();
            }
        }
    }
}
