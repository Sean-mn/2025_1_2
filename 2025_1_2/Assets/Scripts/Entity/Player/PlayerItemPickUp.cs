using UnityEngine;

public class PlayerItemPickUp : MonoBehaviour
{
    [SerializeField] private float _getDistance = 5f;
    private Camera _camera;

    [SerializeField] private Inventory _inventory;

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
            Debug.Log("æ∆¿Ã≈€ ¡›±‚");
            IGetableItem item = hit.collider.GetComponent<IGetableItem>();

            if (item != null && Input.GetKeyDown(Define.Keys.GetItem))
            {
                if (item != null)
                {
                    _inventory.AddItem(item.GetItem());
                    Debug.Log($"æ∆¿Ã≈€ »πµÊ: {item.GetItem().name}");
                    Destroy(hit.collider.gameObject);
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
