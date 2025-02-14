using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeight : PowerUpBase
{
    [Header("Power Up Height")]
    public float amountHeight = 2;
    public float animationDuration = .1f;
    public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerControll.Instance.SetPowerUpText("Fly");
        PlayerControll.Instance.ChangeHeight(amountHeight, duration, animationDuration, ease);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerControll.Instance.ResetHeight();
        PlayerControll.Instance.SetPowerUpText("");
    }
}
