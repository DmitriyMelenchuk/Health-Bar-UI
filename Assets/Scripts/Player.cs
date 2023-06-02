using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _currentHealth;

    public event UnityAction<float> ChangedHealth;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        ChangedHealth?.Invoke(_currentHealth);
    }

    public void TakeHeal(float heal)
    {        
        _currentHealth += heal;

        if (_currentHealth > MaxHealth)
        {
            _currentHealth = _maxHealth;
        }

        ChangedHealth?.Invoke(_currentHealth);
    }
}




//public void TakeDamage(float damage)
//{
//    _currentHealth += damage;

//    if (_currentHealth > MaxHealth)
//    {
//        _currentHealth = _maxHealth;
//    }
//    if (_currentHealth < 0)
//    {
//        _currentHealth = 0;
//    }
//}