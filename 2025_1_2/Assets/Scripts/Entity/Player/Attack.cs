using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _attackDamage;
    [SerializeField] private bool _isPlayer;

    private void OnTriggerEnter(Collider other)
    {
        string targetTag = _isPlayer ? Define.Tags.ENEMY : Define.Tags.PLAYER;

        if (!other.CompareTag(targetTag)) return;

        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(_attackDamage);
            Debug.Log($"{other.gameObject.name}이(가) 피격됨, 데미지: {_attackDamage}");
        }
    }
}
