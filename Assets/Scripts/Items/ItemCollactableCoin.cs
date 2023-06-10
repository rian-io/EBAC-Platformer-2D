using UnityEngine;
using DG.Tweening;

public class ItemCollactableCoin : ItemCollactableBase
{
    protected override void Collect()
    {
        ItemManager.Instance.AddCoins();

        transform.DOScale(Vector3.zero, 0.25f).onComplete = base.Collect;
    }
}
