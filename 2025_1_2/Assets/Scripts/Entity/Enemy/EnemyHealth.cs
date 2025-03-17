using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _currentHealth;
    public float CurrentHealth => _currentHealth;

    [SerializeField] private float _maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;
            Debug.Log($"ÇÇ°Ý µÊ: {damage}");
        }
        else if (_currentHealth <= 0)
        {
            OnDie();
        }
    }

    private void OnDie()
    {
        Debug.Log("Á×À½");
        _currentHealth = 0f;
        Destroy(gameObject);
    }
}
