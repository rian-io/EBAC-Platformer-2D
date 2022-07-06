using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoin : ItemCollactableBase
{
    protected override void Collect()
    {
        base.Collect();
        ItemManager.Instance.AddCoins();
    }
}
