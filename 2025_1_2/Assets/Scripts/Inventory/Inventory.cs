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
    [SerializeField] private int _maxItemAmount;
    public int MaxItemAmount => _maxItemAmount;

    [Header("아이템 슬롯")]
    [SerializeField] private List<SlotData> _slots = new();

    public delegate void OnInventoryChanged();
    public event OnInventoryChanged onInventoryChanged;

    private void Start()
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
                break;
            case InventoryType.VeryLarge:
                _maxItemAmount = 8;
                break;
            default:
                _maxItemAmount = 4;
                break;
        }

        _slots = new List<SlotData>(_maxItemAmount);
        for (int i = 0; i < _maxItemAmount; i++)
        {
            _slots.Add(null);
        }

        Debug.Log($"{_type} 인벤토리 크기: {_maxItemAmount}");
    }

    public void AddItem(GetableItem newItem, int amount = 1)
    {
        if (newItem == null || newItem.GetItem() == null)
        {
            Debug.LogWarning("추가하려는 아이템이 존재하지 않습니다.");
            return;
        }

        Item item = newItem.GetItem();

        foreach (var slot in _slots)
        {
            if (slot != null && slot.item.GetItem() == item)
            {
                slot.count += amount;
                onInventoryChanged?.Invoke();
                return;
            }
        }

        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i] == null)
            {
                _slots[i] = new SlotData(newItem, amount);
                onInventoryChanged?.Invoke();
                return;
            }
        }

        Debug.Log("인벤토리가 가득 찼습니다.");
    }

    public void RemoveItem(Item removeItem, int amount = 1)
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i] != null && _slots[i].item.GetItem() == removeItem)
            {
                if (_slots[i].count > amount)
                {
                    _slots[i].count -= amount;
                }
                else
                {
                    _slots[i] = null;
                }

                onInventoryChanged?.Invoke();
                return;
            }
        }

        Debug.Log("제거할 아이템이 없습니다.");
    }

    public List<SlotData> GetInventoryData()
    {
        return _slots;
    }
}