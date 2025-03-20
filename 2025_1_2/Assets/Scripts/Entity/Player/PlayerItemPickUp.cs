using UnityEngine;

public class PlayerItemPickUp : MonoBehaviour
{
    [SerializeField] private float _getDistance = 5f;
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
        
    }

    private void OnDrawGizmos()
    {
        if (_camera == null) return;

        Gizmos.color = Color.green;
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
        Gizmos.DrawRay(ray.origin, ray.direction * _getDistance);
    }
}
