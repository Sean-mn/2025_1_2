using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Rigidbody _rb;
    public Rigidbody Rigid => _rb;

    [Header("Get Axis")]
    protected float _hAxis;
    protected float _vAxis;

    protected void Awake()
    {
        InitPlayer();
    }

    protected virtual void InitPlayer()
    {
        if (_rb == null) _rb = GetComponent<Rigidbody>();
    }

    protected void Update()
    {
        _hAxis = Input.GetAxis("Horizontal");
        _vAxis = Input.GetAxis("Vertical");

        OnUpdate();
    }

    protected virtual void OnUpdate() { }
}