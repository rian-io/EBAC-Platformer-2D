using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    [SerializeField] private int _currentHealth = 100;

    [SerializeField] private bool _destroyOnDeath = true;

    private bool _isDead = false;

    private void Awake() {
        Init();
    }

    public void Init()
    {
        _currentHealth = _maxHealth;
        _isDead = false;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _isDead = true;

        if (_destroyOnDeath)
        {
            Destroy(gameObject);
        }
    }
}
