using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : UI
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private PlayerHealth _playerHealth;

    protected override void InitUI()
    {
        _hpSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        _hpSlider.maxValue = _playerHealth.MaxHealth;
        _hpSlider.value = _playerHealth.CurrentHealth;
    }

    public override void UIFunction()
    {
        if (_hpSlider != null && _playerHealth != null)
            _hpSlider.value = _playerHealth.CurrentHealth;
        //else
            //Debug.Log("Null");
    }
}
