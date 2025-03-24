using System;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryType
{
    Basic,
    Large,
    VeryLarge
}

public class Inventory : MonoBehaviour
{
    [Header("인벤토리 타입")]
    [SerializeField] private InventoryType _type = InventoryType.Basic;

    [Header("아이템 수량")]
    [SerializeField]private int _currentItemAmount;
    public int CurrentItemAmount => _currentItemAmount;
    [SerializeField] private int _maxItemAmount;
    public int MaxItemAmount => _maxItemAmount;

    [Header("아이템 무게")]
    [SerializeField] private float _currentItemWeight;
    public float CurrentItemWeight => _currentItemWeight;
    [SerializeField] private float _maxItemWeight;

    [Header("아이템 슬롯")]
    public List<SlotData> slotData;

    [SerializeField] private UI_Inventory _inventoryUI;

    private void Awake()
    {
        SetInventorySize(_type);
    }

    public void SetInventorySize(InventoryType type)
    {
        _type = type;

        switch (type)
        {
            case InventoryType.Large:
                _maxItemAmount = 6;
                _maxItemWeight = 250f;
                break;
            case InventoryType.VeryLarge:
                _maxItemAmount = 8;
                _maxItemWeight = 450f;
                break;
            default:
                _maxItemAmount = 4;
                _maxItemWeight = 200f;
                break;
        }

        slotData.Clear();
        for (int i = 0; i < _maxItemAmount; i++)
        {
            slotData.Add(new SlotData(null, 0));
        }

        Debug.Log($"{_type} 인벤토리 크기: {slotData.Count}");
    }

    public void AddItem(Item newItem, int amount = 1)
    {
        if (newItem == null)
        {
            return;
        }

        float itemWeight = newItem.ItemWeight; // 아이템 무게

        if (_currentItemWeight + itemWeight > _maxItemWeight)
        {
            Debug.Log("인벤토리 무게 초과");
            return;
        }

        if (_currentItemAmount > _maxItemAmount)
        {
            Debug.Log("인벤토리 수량 초과");
            return;
        }

        foreach (var slot in slotData)
        {
            if (slot != null && slot.item != null && slot.item == newItem)
            {
                slot.count += amount;
                _currentItemWeight += itemWeight * amount; // 총 무게 갱신
                _inventoryUI.UpdateInventoryWeight(_currentItemWeight);
                _inventoryUI.UpdateInventoryUI();
                return;
            }
        }

        for (int i = 0; i < slotData.Count; i++)
        {
            if (slotData[i] == null || slotData[i].item == null) 
            {
                _currentItemAmount += 1;
                slotData[i] = new SlotData(newItem, amount);
                _currentItemWeight += itemWeight * amount; // 총 무게 갱신
                _inventoryUI.UpdateInventoryWeight(_currentItemWeight);
                _inventoryUI.UpdateInventoryUI();
                return;
            }
        }

        Debug.Log("인벤토리가 가득 참.");
    }

    public void RemoveItem(Item removeItem, int amount = 1)
    {
        for (int i = 0; i < slotData.Count; i++)
        {
            if (slotData[i] != null && slotData[i].item == removeItem)
            {
                // 아이템 수량, 무게 감소.
                if (slotData[i].count > amount)
                {
                    slotData[i].count -= amount;
                    _currentItemWeight -= removeItem.ItemWeight * amount; // 총 무게 갱신
                    _inventoryUI?.UpdateInventoryUI();
                }
                else
                {
                    _currentItemAmount -= 1;
                    _currentItemWeight -= removeItem.ItemWeight * slotData[i].count; // 전체 수량만큼 무게 감소
                    slotData[i] = null;
                    _inventoryUI?.UpdateInventoryUI();

                }

                return;
            }
        }

        Debug.Log("제거할 아이템 X.");
    }

    public List<SlotData> GetInventoryData() => slotData;
}
