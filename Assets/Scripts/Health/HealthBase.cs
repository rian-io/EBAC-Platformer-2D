using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    [SerializeField] private int _currentHealth = 100;

    [SerializeField] private bool _destroyOnDeath = true;

    [SerializeField] private float _delayToKill = 4000f;

    [SerializeField] private FlashColour _flashColour;

    [SerializeField] private Animator animator;

    private bool _isDead = false;

    private void Awake() {
        Init();
        if (_flashColour == null)
        {
            _flashColour = GetComponent<FlashColour>();
        }
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

        if(_flashColour != null)
        {
            _flashColour.Flash();
        }

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
            animator.SetTrigger("Death");
            Destroy(gameObject, _delayToKill);
        }
    }
}
