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
    }
}
