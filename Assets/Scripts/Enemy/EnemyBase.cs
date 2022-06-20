using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private int _damage = 10;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var health = other.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(_damage);
        }    
    }
}
