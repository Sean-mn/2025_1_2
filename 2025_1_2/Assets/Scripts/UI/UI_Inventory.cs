using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : UI
{
    [SerializeField] private GameObject _ui; // 인벤토리 UI

    [SerializeField] private Inventory _inventory;
    [SerializeField] private List<UI_ItemSlot> _slots; // 슬롯 리스트

    [SerializeField] protected Text _inventoryWeghtTxt;

    [SerializeField] private bool _isInventoryActive = false;

    [Header("Item Slot")]
    [SerializeField] private UI_ItemSlot _itemSlotPrefab;
    [SerializeField] private Transform _itemSlotsParent;

    protected override void InitUI()
    {
        _slots = new List<UI_ItemSlot>();
    }

    private void Start()
    {
        SetItemSlots(_inventory.MaxSlotSize);
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

    // 슬롯 수에 맞게 인벤토리 슬롯을 설정
    public void SetItemSlots(int size)
    {
        int currentSlots = _slots.Count;

        if (currentSlots > size)
        {
            for (int i = size; i < currentSlots; i++)
            {
                _slots[i].SetItemSlot(null, null, 0); // 빈 슬롯으로 설정
            }
        }
        else if (currentSlots < size)
        {
            // 새 슬롯 추가
            for (int i = currentSlots; i < size; i++)
            {
                UI_ItemSlot newSlot = Instantiate(_itemSlotPrefab, _itemSlotsParent);
                newSlot.SetItemSlot(null, null, 0); // 빈 슬롯 세팅
                _slots.Add(newSlot);
            }
        }
    }


    // 인벤토리 무게 텍스트 업데이트
    public void SetInventoryWeighText()
    {
        _inventoryWeghtTxt.text = $"무게: {_inventory.CurrentInventoryWeight} / {_inventory.CurrentMaxInventoryWeight}";
    }

    // 인벤토리의 아이템을 UI에 표시
    public void UIFunction(Dictionary<Item, int> inventoryItems)
    {
        Debug.Log("인벤토리 UI");

        int index = 0;

        foreach (var kvp in inventoryItems)
        {
            if (index >= _slots.Count)
            {
                Debug.Log("index >= _slots.Count");
                break;
            }

            Item item = kvp.Key;
            int count = kvp.Value;

            // 슬롯에 아이템과 카운트 설정
            _slots[index].SetItemSlot(item, item.ItemImage, count);
            index++;
        }
    }
}
