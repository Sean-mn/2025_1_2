using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : UI
{
    [SerializeField] private GameObject _ui; // 인벤토리 UI

    [SerializeField] private Inventory _inventory;
    [SerializeField] private List<UI_ItemSlot> _items; // 슬롯 리스트

    [SerializeField] protected Text _inventoryWeghtTxt;

    [SerializeField] private bool _isInventoryActive = false;

    [Header("Item Slot")]
    [SerializeField] private UI_ItemSlot _itemSlotPrefab;
    [SerializeField] private Transform _itemSlotsParent;

    protected override void InitUI()
    {
        _items = new List<UI_ItemSlot>();
    }

    private void Start()
    {
        SetItemSlots(4);
        SetInventoryWeighText();
        _ui?.gameObject.SetActive(false);       
    }

    private void Update()
    {
        if (Input.GetKeyDown(Define.Keys.OpenInventory))
            TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        _isInventoryActive = !_isInventoryActive;

        if (!_isInventoryActive)
            OpenInventory();
        else
            CloseInventory();
    }
    private void OpenInventory()
    {
        _ui?.gameObject.SetActive(true);
        Managers.Util.UnLockCursor();
    }
    private void CloseInventory()
    {
        _ui?.gameObject.SetActive(false);
        Managers.Util.LockCursor();
    }

    public void SetItemSlots(int size)
    {
        foreach (var item in _items)
        {
            Destroy(item.gameObject);
        }
        _items.Clear();

        // size 크기만큼 슬롯 추가
        for (int i = 0; i < size; i++)
        {
            UI_ItemSlot newSlot = Instantiate(_itemSlotPrefab, _itemSlotsParent);
            _items.Add(newSlot);
        }
    }
    public void SetInventoryWeighText()
    {
        _inventoryWeghtTxt.text = $"무게: {_inventory.CurrentInventoryWeight} / {_inventory.CurrnetMaxInventoryWeight}";
    }

    public void UIFunction(Item item)
    {
        
    }
}
