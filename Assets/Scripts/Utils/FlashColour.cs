using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColour : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _spriteRenderers;
    [SerializeField] private Color _color = Color.red;
    [SerializeField] private float _duration = .3f;

    private Tween _currentTween;

    private void OnValidate()
    {
        _spriteRenderers = new List<SpriteRenderer>();
        foreach(var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            _spriteRenderers.Add(child);
        }
    }

    public void Flash()
    {
        if (_currentTween != null)
        {
            _currentTween.Kill();
            _spriteRenderers.ForEach(i => i.color = Color.white);
        }
        foreach(var spriteRenderer in _spriteRenderers)
        {
            spriteRenderer.DOColor(_color, _duration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
