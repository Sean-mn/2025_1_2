using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerBreath : UI
{
    [SerializeField] private Slider _breathBar;
    [SerializeField] private PlayerBreath _playerBreath;

    protected override void InitUI()
    {
        _breathBar = GetComponent<Slider>();
    }

    private void Start()
    {
        _breathBar.maxValue = _playerBreath.MaxBreathAmount;
        _breathBar.value = _playerBreath.CurrnetBreathAmount;
    }

    public override void UIFunction()
    {
        if (_playerBreath != null)
            _breathBar.value = _playerBreath.CurrnetBreathAmount;
    }
}
