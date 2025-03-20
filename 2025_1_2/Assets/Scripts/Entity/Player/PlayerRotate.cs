using System.Threading;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField, Header("Stat")]
    private float _rotateSpeed;

    private float _mouseX;
    private float _mouseY;

    public static bool canRotate = true;

    private void Update()
    {
        if (canRotate)
            OnRotate();
    }

    private void OnRotate()
    {
        _mouseX += Input.GetAxisRaw("Mouse X") * _rotateSpeed * Time.deltaTime;
        _mouseY -= Input.GetAxisRaw("Mouse Y") * _rotateSpeed * Time.deltaTime;

        _mouseY = Mathf.Clamp(_mouseY, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_mouseY, _mouseX, 0f);
    }
}
