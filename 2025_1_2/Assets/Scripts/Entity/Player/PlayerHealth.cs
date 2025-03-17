using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _currentHP;
    public float CurrentHealth => _currentHP;

    [SerializeField] private float _maxHP;
    public float MaxHealth => _maxHP;

    [SerializeField] private UI_HealthBar _healthUI;

    private void Awake()
    {
        _currentHP = _maxHP;
    }

    public void TakeDamage(float damage)
    {
        if (_currentHP > 0)
        {
            _currentHP -= damage;
            Debug.Log($"현재 체력: {_currentHP}");

            _healthUI?.UIFunction();
        }
        else if (_currentHP <= 0)
        {
            OnDie();
        }
    }

    public void OnDie()
    {
        Debug.Log("죽음");
        _currentHP = 0;
    }

    public void Heal(float amount)
    {
        _currentHP += Mathf.Clamp(_currentHP + amount, _currentHP, _maxHP);
        _healthUI?.UIFunction();
    }
}
