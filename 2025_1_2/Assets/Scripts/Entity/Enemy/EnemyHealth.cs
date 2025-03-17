using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _currentHealth;
    public float CurrentHealth => _currentHealth;

    [SerializeField] private float _maxHealth;

    private Renderer _rend;
    private Color _originColor;

    private void Awake()
    {
        _rend = GetComponent<Renderer>();
        _originColor = _rend.material.color;
    }

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
            StartCoroutine(Damaged(0.3f));
        }
        else if (_currentHealth <= 0)
        {
            OnDie();
        }
    }

    private IEnumerator Damaged(float duration)
    {
        _rend.material.color = Color.red;
        yield return new WaitForSeconds(duration);
        _rend.material.color = _originColor;
    }

    private void OnDie()
    {
        Debug.Log("Á×À½");
        _currentHealth = 0f;
        Destroy(gameObject);
    }
}
