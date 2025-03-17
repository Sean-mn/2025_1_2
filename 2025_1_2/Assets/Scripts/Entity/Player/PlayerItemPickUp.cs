using UnityEngine;

public class PlayerItemPickUp : MonoBehaviour
{
    [SerializeField] private float _getDistance = 5f;
    [SerializeField] private Inventory _inventory;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        TryItemPickUp();
    }

    private void TryItemPickUp()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));

        if (Physics.Raycast(ray, out RaycastHit hit, _getDistance, Define.Layers.ITEM))
        {
            GetableItem getableItem = hit.collider.GetComponent<GetableItem>();
            Debug.Log("줍기 가능");

            if (getableItem != null)
            {
                if (Input.GetKeyDown(Define.Keys.GetItem))
                {
                    if (!_inventory.IsInventoryFull)
                    {
                        _inventory.AddItem(getableItem.GetItem());
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        Debug.Log("아이템 꽉 참");
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (_camera == null) return;

        Gizmos.color = Color.green;
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
        Gizmos.DrawRay(ray.origin, ray.direction * _getDistance);
    }
}
