using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<Item, int> items = new(); // Key; ���� ������, Value: ������ ����

    public const int MaxInventorySize = 8;
    public const float MaxInventoryWeight = 450f;

    [Header("Current Max Value")]
    [SerializeField] private int _currentMaxInventorySize;
    [SerializeField] private float _currentMaxInventoryWeight;

    public float CurrentMaxInventoryWeight
    {
        get => _currentMaxInventoryWeight;
        set => _currentMaxInventoryWeight = Mathf.Clamp(value, 1f, MaxInventoryWeight);
    }
    public int CurrentMaxInventorySize
    {
        get => _currentMaxInventorySize;
        set => _currentMaxInventorySize = Mathf.Clamp(value, 1, MaxInventorySize);
    }

    [Header("Current Value")]
    [SerializeField] private int _currentInventorySize;
    public int CurrentInventorySize
    {
        get => _currentInventorySize;
        set => _currentInventorySize = Mathf.Clamp(value, 0, _currentMaxInventorySize);
    }

    [SerializeField] private float _currentInventoryWeight;
    public float CurrentInventoryWeight
    {
        get => _currentInventoryWeight;
        set => _currentInventoryWeight = Mathf.Clamp(value, 0, _currentMaxInventoryWeight);
    }

    [SerializeField] private int _maxSlotSize;
    public int MaxSlotSize => _maxSlotSize;

    [SerializeField] private bool _isInventoryFull = false;
    public bool IsInventoryFull => _isInventoryFull;

    [SerializeField] private UI_Inventory _InventoryUI;

    private void Awake()
    {
        _maxSlotSize = 4;
    }

    public void AddItem(Item item)
    {
        float itemWeight = item.ItemWeight;

        // �κ��丮 ���� ���� Ȯ��
        if (CurrentInventorySize >= CurrentMaxInventorySize)
        {
            Debug.Log("�κ��丮 ���� ����!");
            _isInventoryFull = true;
            return;
        }

        // �κ��丮 ���� �ʰ� Ȯ��
        if (CurrentInventoryWeight + itemWeight > CurrentMaxInventoryWeight)
        {
            Debug.Log("�κ��丮 ���� �ʰ�!");
            _isInventoryFull = true;
            return;
        }

        if (items.TryGetValue(item, out int count))
        {
            Debug.Log("�ߺ� ������ ȹ��");
            items[item] = count + 1;
        }
        else
        {
            Debug.Log("������ ȹ��!");
            items[item] = 1;
            CurrentInventorySize++;
        }

        CurrentInventoryWeight += itemWeight;
        _InventoryUI?.SetInventoryWeighText();
        _InventoryUI?.UIFunction(items);
    }

    public void RemoveItem(Item item)
    {
        if (items.TryGetValue(item, out int count))
        {
            if (count > 1)
            {
                items[item] = count - 1;
            }
            else
            {
                items.Remove(item);
                CurrentInventorySize--;
            }

            CurrentInventoryWeight -= item.ItemWeight;
            _InventoryUI?.SetInventoryWeighText();
            _InventoryUI?.UIFunction(items);

            if (_isInventoryFull)
                _isInventoryFull = false;
        }
    }

    public void SetInventorySize(int size)
    {
        CurrentInventorySize = size;
    }
    public void SetMaxInventorySize(int size)
    {
        CurrentMaxInventorySize = size;
    }
    public void SetMaxInventoryWeight(float weight)
    {
        CurrentMaxInventoryWeight = weight;
    }
}
