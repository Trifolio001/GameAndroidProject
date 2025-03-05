using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{

    [Header("Animation Start")]
    public float scaleDuration = .2f;
    public float scaleBounce = 1.2f;
    public Ease easeStartGame = Ease.OutBack;

    public void Bounce()
    {
        transform.DOScale(scaleBounce, scaleDuration).SetLoops(2, LoopType.Yoyo);
    }
}
