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

    [Header("�κ��丮 Ÿ��")]
    [SerializeField] private InventoryType _type = InventoryType.Basic;

    [Header("������ ����")]
    [SerializeField] private int _maxItemAmount;
    [SerializeField] private int _currentItemAmount;

    [Header("������ ����")]
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
            Debug.Log("������ ���� �ʰ�");
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
                Debug.Log("�κ��丮 ���� �ʰ�.");
                return;
            }

            _items.Add(newItem, amount);
            _currentItemAmount++;
            _currentItemWeight += itemWeight;
            Debug.Log($"[������ �߰�] {newItem.name} x {amount} (�� ����: {_items[newItem]}, �� ����: {_currentItemWeight}/{_maxItemWeight})");
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
                Debug.Log($"[������ ����] {item.name} x {amount} (���� ����: {_items[item]})");
            }
            else
            {
                Debug.Log($"[������ ����] {item.name} x {_items[item]} (������ ������)");
                _currentItemWeight -= item.ItemWeight * _items[item];
                _items.Remove(item);
                _currentItemAmount--;
            }
        }
        else
        {
            Debug.Log("������ �������� �����ϴ�.");
            return;
        }

        _currentItemWeight -= item.ItemWeight * amount;
    }
}
