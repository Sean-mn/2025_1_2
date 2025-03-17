using UnityEngine;

public class Item : ScriptableObject
{
    [Header("Item Value")]
    [SerializeField] private float _itemValue;
    public float ItemValue => _itemValue;

    [Header("Item Image")]
    [SerializeField] private Sprite _itemImage;
    public Sprite ItemImage => _itemImage;

    [Header("Item Weight")]
    [SerializeField] private float _itemWeight;
    public float ItemWeight => _itemWeight;
}
