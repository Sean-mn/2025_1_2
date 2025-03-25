using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public List<GetableItem> items = new();

    private void Awake()
    {
        items.AddRange(FindObjectsOfType<GetableItem>());
    }


}
