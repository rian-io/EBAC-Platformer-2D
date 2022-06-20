using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{

    [Header("Player")]
    public GameObject PlayerPrefab;

    [Header("Enemies")]
    public List<GameObject> Enemies;

    [Header("References")]
    [SerializeField] private Transform StartPoint;

    [Header("Animation")]
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private float _delay = 0.1f;
    [SerializeField] private Ease _ease = Ease.OutBack;

    private GameObject _currentPlayer;

    private void Start() {
        SpawnPlayer();   
    }

    private void SpawnPlayer() {
        _currentPlayer = Instantiate(PlayerPrefab, StartPoint.transform);
        _currentPlayer.transform.DOScale(Vector3.zero, _duration).From().SetDelay(_delay).SetEase(_ease);
    }
}
