using System.Collections;
using UnityEngine;

public class PlayerBreath : MonoBehaviour
{
    [SerializeField] private float _currentBreathAmount;
    public float CurrnetBreathAmount => _currentBreathAmount;

    [SerializeField] private float _maxBreathAmount;
    public float MaxBreathAmount => _maxBreathAmount;

    [SerializeField] private float _breathAmount;
    public float BreathAmount => _breathAmount;

    [SerializeField] private UI_PlayerBreath _breathUI;

    private void Awake()
    {
        SetMaxBreathAmount(200);
        _currentBreathAmount = _maxBreathAmount;
    }

    private void Start()
    {
        SetBreathAmount(2f);
        StartCoroutine(Breath());
    }

    private IEnumerator Breath()
    {
        while (_currentBreathAmount > 0)
        {
            if (_currentBreathAmount > 0)
            {
                yield return new WaitForSeconds(1.3f);

                _currentBreathAmount -= _breathAmount;
                _breathUI?.UIFunction();

            }
            else if (_currentBreathAmount <= 0)
            {
                OnDie();
            }
        }
    }

    public void SetMaxBreathAmount(float amount)
    {
        _maxBreathAmount = amount;
        _currentBreathAmount = _maxBreathAmount;
        _breathUI?.UIFunction();
    }

    public void SetBreathAmount(float amount)
    {
        _breathAmount = amount;
    }

    public void HealBreath(float amount)
    {
        _currentBreathAmount = amount;
        _breathUI?.UIFunction();
    }

    private void OnDie()
    {
        Debug.Log("Áú½Ä»ç..");
    }
}
