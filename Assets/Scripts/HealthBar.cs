using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _duration;
    
    private Coroutine _currentCoroutine;

    public void ChangeValue(float damage)
    {
        _player.TakeDamage(damage);

        StartState(SmoothlyChangeValue());
    }

    private void Awake()
    {
        InitializeSliderValue();
    }

    private void InitializeSliderValue()
    {
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.CurrentHealth;
    }

    private IEnumerator SmoothlyChangeValue()
    {     
        while (_slider.value != _player.CurrentHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _player.CurrentHealth, _duration * Time.deltaTime);

            yield return null;
        }
    }

    private void StartState(IEnumerator coroutine)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(coroutine);
    }
}
