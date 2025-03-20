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
    private Dictionary<Item, int> _items = new();

    [Header("인벤토리 타입")]
    [SerializeField] private InventoryType _type = InventoryType.Basic;

    [Header("아이템 수량")]
    [SerializeField] private int _maxItemAmount;
    [SerializeField] private int _currentItemAmount;

    [Header("아이텝 무게")]
    [SerializeField] private float _maxItemWeight;
    [SerializeField] private float _currentItemWeight;

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
                _maxItemWeight = 400f;
                break;
            default:
                _maxItemAmount = 4;
                _maxItemWeight = 150f;
                break;
        }
    }

    public void AddItem(Item newItem, int amount = 1)
    {
        float itemWeight = newItem.ItemWeight * amount;

        if (_currentItemWeight + itemWeight > _maxItemWeight)
        {
            Debug.Log("아이템 무게 초과");
            return;
        }

        if (_items.ContainsKey(newItem))
        {
            _items[newItem] += amount;
        }
        else
        {
            if (_currentItemAmount >= _maxItemAmount)
            {
                Debug.Log("인벤토리 수량 초과.");
                return;
            }

            _items.Add(newItem, amount);
            _currentItemAmount++;
            _currentItemWeight += itemWeight;
            Debug.Log($"[아이템 추가] {newItem.name} x {amount} (총 개수: {_items[newItem]}, 총 무게: {_currentItemWeight}/{_maxItemWeight})");
        }
    }

    public void RemoveItem(Item item, int amount = 1)
    {
        if (_items.ContainsKey(item))
        {
            if (_items[item] > amount)
            {
                _items[item] -= amount;
                _currentItemWeight -= item.ItemWeight * amount;
                Debug.Log($"[아이템 삭제] {item.name} x {amount} (남은 개수: {_items[item]})");
            }
            else
            {
                Debug.Log($"[아이템 삭제] {item.name} x {_items[item]} (완전히 삭제됨)");
                _currentItemWeight -= item.ItemWeight * _items[item];
                _items.Remove(item);
                _currentItemAmount--;
            }
        }
        else
        {
            Debug.Log("제거할 아이템이 없습니다.");
            return;
        }

        _currentItemWeight -= item.ItemWeight * amount;
    }
}
