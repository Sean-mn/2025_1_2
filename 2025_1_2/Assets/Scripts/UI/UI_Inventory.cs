using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : UI
{
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private Inventory _inventory;
    private bool _isInventoryActive = false;

    [Header("아이템 슬롯")]
    [SerializeField] private List<Slot> _itemSlots = new();
    [SerializeField] private GameObject _itemSlotPrefab;
    [SerializeField] private Transform _itemSlotsParent;

    [Header("아이템 무게")]
    [SerializeField] private Text _inventoryWeightTxt;

    protected override void InitUI()
    {
        _inventoryPanel.SetActive(false);

        if (_inventory == null)
        {
            _inventory = FindAnyObjectByType<Inventory>();
        }
    }

    private void Start()
    {
        SetItemSlots(4);

        if (_inventory != null)
        {
            _inventory.onInventoryChanged += UpdateInventoryUI;
            _inventory.onInventoryChanged += UpdateInventoryWeight;
        }
        else
        {
            Debug.LogError("인벤토리가 없습니다.");
        }
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

    public void UpdateInventoryWeight()
    {
        _inventoryWeightTxt.text = $"무게 : {_inventory.CurrentItemWeight}";
    }

    public void UpdateInventoryUI()
    {
        for (int i = 0; i < _inventory.MaxItemAmount; i++)
        {
            if (i < _inventory.CurrentItemAmount && _inventory.slotData[i] != null)
            {
                Debug.Log("슬롯 업데이트");
                _itemSlots[i].SetItemSlot(_inventory.slotData[i].item, _inventory.slotData[i].count);
            }
            else
            {
                Debug.Log("슬롯 초기화");
                _itemSlots[i].ClearSlot();
            }
        }
    }
}
