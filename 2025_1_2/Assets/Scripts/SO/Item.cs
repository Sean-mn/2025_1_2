using UnityEngine;

public enum ItemType
{
    UsableItem,
    Treasure,
}

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [Header("Item Money")]
    [SerializeField] private int _itemMoney;
    public int ItemMoney => _itemMoney;

    [Header("Item Value")]
    [SerializeField] private float _itemValue;
    public float ItemValue => _itemValue;

    [Header("Item Image")]
    [SerializeField] private Sprite _itemImage;
    public Sprite ItemImage => _itemImage;

    [Header("Item Weight")]
    [SerializeField] private float _itemWeight;
    public float ItemWeight => _itemWeight;

    [Header("Can Use")]
    [SerializeField] private bool _canUse;
    public bool CanUse
    {
        get => _canUse;
        set => _canUse = value;
    }

    [SerializeField] private GetableItem _item;
    public GetableItem GetItem => _item;
}
