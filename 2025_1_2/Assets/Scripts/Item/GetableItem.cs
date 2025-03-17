using UnityEngine;

public interface IGetableItem
{
    public Item GetItem();
}

public abstract class GetableItem : MonoBehaviour, IGetableItem
{
    [SerializeField] protected Item _item;


    public abstract void UseItem();
    public Item GetItem()
    {
        return _item;
    }
}
