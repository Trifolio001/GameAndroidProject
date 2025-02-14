using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoins : PowerUpBase
{
    [Header("Coin Collector")]
    public float sizeAmount = 7;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerControll.Instance.SetPowerUpText("Magnetism");
        PlayerControll.Instance.ChangeCoinCollectorSize(sizeAmount);
    }
    protected override void EndPowerUp()
    {
        PlayerControll.Instance.SetPowerUpText("");
        base.EndPowerUp();
        PlayerControll.Instance.ChangeCoinCollectorSize(1);
    }
}
