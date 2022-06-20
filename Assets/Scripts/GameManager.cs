using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

  [Header("Player")]
  public GameObject Player;

  [Header("Enemies")]
  public List<GameObject> Enemies;

}
