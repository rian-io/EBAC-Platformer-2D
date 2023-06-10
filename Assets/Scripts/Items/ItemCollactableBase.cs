using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemCollactableBase : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        gameObject.SetActive(false);
        OnCollect();
    }

    protected virtual void OnCollect()
    { }
}
