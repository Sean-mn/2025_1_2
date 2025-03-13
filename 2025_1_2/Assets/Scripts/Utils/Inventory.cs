using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<Item, int> items = new();

    [SerializeField] private int _maxInventorySize;

    [Header("Inventory Weight")]
    [SerializeField] private float _maxInventoryWeight;
    [SerializeField] private float _currentInventoryWeight;
    public float CurrentInventoryWeight => _currentInventoryWeight;
    public float MaxInventoryWeight
    {
        get { return _maxInventoryWeight; }
        set { _maxInventoryWeight = value; }
    }

    public void AddItem(Item item)
    {
        if (items.Count > _maxInventorySize 
            || _currentInventoryWeight >= _maxInventoryWeight)
        {
            Debug.Log("ÀÎº¥Åä¸® °¡µæ Âü!");
            return;
        }

        if (items.TryGetValue(item, out int count)) 
        {
            Debug.Log("Áßº¹ ¾ÆÀÌÅÛ È¹µæ");
            items[item] = count + 1;
        }
        else
        {
            Debug.Log("¾ÆÀÌÅÛ È¹µæ!");
            items[item] = 1;
        }
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
        }
    }
}
