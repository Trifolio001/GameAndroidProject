using UnityEngine;

public class PowerUpBase : Colect_Base
{
    [Header("Power Up")]
    public float duration;
    public float RestantTimeFinish = 4;

    protected override void OnCollect()
    {
        PlayerControll.Instance.Bounce();
        base.OnCollect(); 
        StartPowerUp();     
    }

    protected virtual void StartPowerUp()
    {
        Debug.Log("passo no 1");

        PlayerControll.Instance.timePowerUpLast(duration - RestantTimeFinish);
        Invoke(nameof(EndPowerUp), duration);     
    }

    protected virtual void EndPowerUp() 
    { 
        Debug.Log("End Power Up"); 
    }
}
