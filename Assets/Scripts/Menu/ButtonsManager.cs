using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _buttons;

    [Header("Animation")]
    [SerializeField] private float _duration = 0.2f;
    [SerializeField] private float _delay = 0.05f;
    [SerializeField] private Ease _ease = Ease.OutBack;

    private void Awake() {
        HideButtons();
        ShowButtons();
    }

    private void HideButtons() {
        foreach (var button in _buttons) {
            button.transform.localScale = Vector3.zero;
            button.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            var button = _buttons[i];
            button.SetActive(true);
            button.transform.DOScale(Vector3.one, _duration).SetDelay(_delay * i).SetEase(_ease);
        }
    }
}
