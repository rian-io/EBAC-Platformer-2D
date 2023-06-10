using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public const string TRIGGER_ATTACK = "Attack";

    [SerializeField] private int _damage = 10;

    [SerializeField] private Animator animator;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var health = other.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(_damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(TRIGGER_ATTACK);
    }
}
