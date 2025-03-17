using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<Item, int> items = new();

    public const int MaxInventorySize = 8;
    public const float MaxInventoryWeight = 450f;

    [Header("Currnet Max Value")]
    [SerializeField] private int _currentMaxInventorySize;
    [SerializeField] private float _currentMaxInventoryWeight;

    public float CurrnetMaxInventoryWeight
    {
        get => _currentMaxInventoryWeight;
        set => Mathf.Clamp(value, _currentInventoryWeight, MaxInventoryWeight);
    }
    public int CurrentMaxInventorySize
    {
        get => _currentMaxInventorySize;
        set => Mathf.Clamp(value, _currentInventorySize, MaxInventorySize);
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

    [SerializeField] private UI_Inventory _InventoryUI;

    private void Awake()
    {
        _currentInventorySize = 4;
    }

    public void AddItem(Item item)
    {
        float itemWeight = item.ItemWeight;

        if (_currentInventorySize >= _currentMaxInventorySize)
        {
            Debug.Log("인벤토리 공간 부족!.");
            return;
        }

        if (_currentInventoryWeight + itemWeight > _currentMaxInventoryWeight)
        {
            Debug.Log("인벤토리 무게 초과!");
            return;
        }

        if (items.TryGetValue(item, out int count))
        {
            Debug.Log("중복 아이템 획득");
            items[item] = count + 1;
        }
        else
        {
            Debug.Log("아이템 획득!");
            items[item] = 1;
        }

        // 무게 추가
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
            }

            // 무게 감소
            CurrentInventoryWeight -= item.ItemWeight;
            _InventoryUI?.SetInventoryWeighText();
        }
    }

    public void SetInventorySize(int size)
    {
        CurrentInventorySize = size;
    }
    public  void SetMaxInventorySize(int size)
    {
        _currentMaxInventorySize = Mathf.Max(size, 1); // 최소 1 이상의 값으로 설정
    }
    public  void SetMaxInventoryWeight(float weight)
    {
        _currentMaxInventoryWeight = Mathf.Max(weight, 1f); // 최소 1 이상의 값으로 설정
    }
}
