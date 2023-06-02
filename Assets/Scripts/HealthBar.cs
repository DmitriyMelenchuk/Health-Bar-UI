using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _duration;
    [SerializeField] private float _heal;
    [SerializeField] private float _damage;

    private Coroutine _currentCoroutine;

    private void Awake()
    {
        InitializeSliderValue();
    }

    private void OnEnable()
    {
        _player.ChangedHealth += OnChangeValue;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= OnChangeValue;
    }

    private void OnChangeValue(float currentHealth)
    {
        StartState(SmoothlyChangeValue(currentHealth));
    }

    private void InitializeSliderValue()
    {
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.CurrentHealth;
    }

    private IEnumerator SmoothlyChangeValue(float currentHealth)
    {
        while (_slider.value != currentHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, currentHealth, _duration * Time.deltaTime);

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
