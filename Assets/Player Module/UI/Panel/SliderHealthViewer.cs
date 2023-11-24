using Assets.Player_Module.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealthViewer : MonoBehaviour, IHealthViewer
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _animationDuation = 1.5f;

    private Ease _animationType = Ease.Flash;
    private Tween _healthChangingTween;

    public void SetInitialHealthValue(float value)
    {
        _slider.value = value;
    }

    public void OnHealthChanged(float currentHealthValue)
    {
        UpdateHealth(currentHealthValue);
    }

    private void UpdateHealth(float targetValue)
    {
        if (_healthChangingTween != null && _healthChangingTween.IsActive())
        {
            _healthChangingTween.Kill();
        }

        _healthChangingTween = _slider
            .DOValue(targetValue, _animationDuation)
            .SetEase(_animationType);
    }
}
