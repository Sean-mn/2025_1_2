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
    [SerializeField] private int _currentItemAmount;
    [SerializeField] private int _maxItemAmount;
    public int MaxItemAmount => _maxItemAmount;

    [Header("아이템 무게")]
    [SerializeField] private float _currentItemWeight;
    public float CurrentItemWeight => _currentItemWeight;
    [SerializeField] private float _maxItemWeight;

    [Header("아이템 슬롯")]
    public List<SlotData> _slotData = new();

    public event Action onInventoryChanged;

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

        _slotData = new List<SlotData>(_maxItemAmount);
        for (int i = 0; i < _maxItemAmount; i++)
        {
            _slotData.Add(new SlotData(null, 0));
        }

        Debug.Log($"{_type} 인벤토리 크기: {_slotData.Count}");
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

        foreach (var slot in _slotData)
        {
            if (slot != null && slot.item != null && slot.item == newItem)
            {
                slot.count += amount;
                _currentItemWeight += itemWeight * amount; // 총 무게 갱신
                onInventoryChanged?.Invoke();
                return;
            }
        }

        for (int i = 0; i < _slotData.Count; i++)
        {
            if (_slotData[i] == null || _slotData[i].item == null) 
            {
                _currentItemAmount += 1;
                _slotData[i] = new SlotData(newItem, amount);
                _currentItemWeight += itemWeight * amount; // 총 무게 갱신
                onInventoryChanged?.Invoke();
                return;
            }
        }

        Debug.Log("인벤토리가 가득 참.");
    }

    public void RemoveItem(Item removeItem, int amount = 1)
    {
        for (int i = 0; i < _slotData.Count; i++)
        {
            if (_slotData[i] != null && _slotData[i].item == removeItem)
            {
                // 아이템 수량, 무게 감소.
                if (_slotData[i].count > amount)
                {
                    _slotData[i].count -= amount;
                    _currentItemWeight -= removeItem.ItemWeight * amount; // 총 무게 갱신
                }
                else
                {
                    _currentItemWeight -= removeItem.ItemWeight * _slotData[i].count; // 전체 수량만큼 무게 감소
                    _slotData[i] = null;
                }

                _currentItemAmount -= 1;

                onInventoryChanged?.Invoke();
                return;
            }
        }

        Debug.Log("제거할 아이템 X.");
    }

    public List<SlotData> GetInventoryData()
    {
        Debug.Log($"슬롯 데이터 크기: {_slotData.Count}");
        foreach (var slot in _slotData)
        {
            Debug.Log(slot != null ? $"아이템: {slot.item}, 개수: {slot.count}" : "빈 슬롯");
        }
        return _slotData;
    }
}
