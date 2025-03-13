using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Stat")]
    [SerializeField] private float _attackDamage;
    public float AttackDamage => _attackDamage;

    [SerializeField] private float _attackDelay;
    private bool _isAttacking = false;

    [Header("Reference")]
    [SerializeField] private GameObject _arm;


    private void Update()
    {
        if (Input.GetMouseButtonDown(Define.Keys.MouseLeftClick) && !_isAttacking)
        {
            StartCoroutine(SetAttackMove());
        }
    }

    private IEnumerator SetAttackMove()
    {
        _isAttacking = true;

        yield return new WaitForSeconds(0.3f);

        Quaternion startRot = _arm.transform.localRotation;
        Quaternion attackRot1 = Quaternion.Euler(-20, 0, 0) * startRot;
        Quaternion attackRot2 = Quaternion.Euler(30, 0, 0) * startRot;

        yield return RotateArm(attackRot1, _attackDelay);
        yield return RotateArm(attackRot2, _attackDelay);
        yield return RotateArm(startRot, _attackDelay);

        _isAttacking = false;
    }

    private IEnumerator RotateArm(Quaternion targetRot, float duration)
    {
        float time = 0;
        Quaternion initRot = _arm.transform.localRotation;

        while (time < duration)
        {
            _arm.transform.localRotation = Quaternion.Lerp(initRot, targetRot, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        _arm.transform.localRotation = targetRot;
    }
}
