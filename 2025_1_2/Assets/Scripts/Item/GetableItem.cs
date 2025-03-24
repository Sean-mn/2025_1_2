using UnityEngine;

public interface IGetableItem
{
    public Item GetItem();
}

public class GetableItem : MonoBehaviour, IGetableItem
{
    [SerializeField] protected Item _item;
    [SerializeField] protected ItemType _type;

    protected virtual void Awake()
    {
        InitItem();
    }

    protected virtual void InitItem() { }
    protected virtual void Start()
    {
        if (_type == ItemType.UsableItem)
            _item.CanUse = true;
        else 
            _item.CanUse = false;
    }
    public Item GetItem() => _item;
}
