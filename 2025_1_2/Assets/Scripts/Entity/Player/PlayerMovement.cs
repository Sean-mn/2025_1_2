using System.Collections;
using UnityEngine;

public class PlayerMovement : Player
{
    [Header("Stat")]
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed => _moveSpeed;

    protected override void OnUpdate()
    {
        OnMove();
    }

    public void OnMove()
    {
        Vector3 moveDir = transform.forward * _vAxis + transform.right * _hAxis;
        moveDir.Normalize();

        Rigid.velocity = new Vector3(moveDir.x * _moveSpeed, Rigid.velocity.y, moveDir.z * _moveSpeed);

        if (_hAxis == 0 && _vAxis == 0) Rigid.velocity = Vector3.zero;
    }

    public void StartSpeedUp(float value)
    {
        StartCoroutine(SpeedUp(value));
    }

    public IEnumerator SpeedUp(float value)
    {
        float originSpeed = _moveSpeed;

        _moveSpeed = value;

        yield return new WaitForSeconds(1.5f);

        _moveSpeed = originSpeed;
    }
}
