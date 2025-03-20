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
    [SerializeField] private int _currentAmount;
    [SerializeField] private int _maxItemAmount;
    public int MaxItemAmount => _maxItemAmount;

    [Header("아이템 무게")]
    [SerializeField] private float _currentItemWeight;
    public float CurrentItemWeight => _currentItemWeight;
    [SerializeField] private float _maxItemWeight;

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
            return;
        }

        Item item = newItem.GetItem();
        float itemWeight = newItem.GetItem().ItemWeight; // 아이템 무게

        // 아이템이 이미 존재하는 슬롯을 찾아 수량을 추가.
        foreach (var slot in _slots)
        {
            if (slot != null && slot.item.GetItem() == item)
            {
                slot.count += amount;
                _currentItemWeight += itemWeight * amount; // 총 무게 갱신
                onInventoryChanged?.Invoke();
                return;
            }
        }

        // 빈 슬롯에 아이템을 추가.
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i] == null)
            {
                _slots[i] = new SlotData(newItem, amount);
                _currentItemWeight += itemWeight * amount; // 총 무게 갱신
                onInventoryChanged?.Invoke();
                return;
            }
        }

        Debug.Log("인벤토리가 가득 참.");
    }

    public void RemoveItem(GetableItem removeItem, int amount = 1)
    {
        Item item = removeItem.GetItem();
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i] != null && _slots[i].item.GetItem() == item)
            {
                // 아이템 수량, 무게 감소.
                if (_slots[i].count > amount)
                {
                    _slots[i].count -= amount;
                    _currentItemWeight -= removeItem.GetItem().ItemWeight * amount; // 총 무게 갱신
                }
                else
                {
                    _currentItemWeight -= removeItem.GetItem().ItemWeight * _slots[i].count; // 전체 수량만큼 무게 감소
                    _slots[i] = null;
                }

                onInventoryChanged?.Invoke();
                return;
            }
        }

        Debug.Log("제거할 아이템 X.");
    }

    public List<SlotData> GetInventoryData()
    {
        return _slots;
    }
}
