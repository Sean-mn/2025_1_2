using UnityEngine;

public interface IGetableItem
{
    public Item GetItem();
}

public class GetableItem : MonoBehaviour, IGetableItem
{
    [SerializeField] protected Item _item;

    protected virtual void Awake()
    {
        InitItem();
    }

    protected virtual void InitItem() { }
    protected virtual void Start()
    {
        if (_item.ItemType == ItemType.UsableItem)
            _item.CanUse = true;
        else 
            _item.CanUse = false;
    }
    public Item GetItem() => _item;
}
