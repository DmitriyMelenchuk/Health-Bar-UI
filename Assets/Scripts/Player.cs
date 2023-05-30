using UnityEngine;

public class Player : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _currentHealth;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;

    public void TakeDamage(float damage)
    {
        _currentHealth += damage;

        if (_currentHealth > MaxHealth)
        {
            _currentHealth = _maxHealth;
        }
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
    }
}
