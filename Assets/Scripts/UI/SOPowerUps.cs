using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPowerUps : ScriptableObject
{
    [Header("PowerUp Magnetic")]
    public float DurationMagnetic;
    public float SizeAmountMagnetic;

    [Header("PowerUp Fly")]
    public float DurationFly;
    public float AmountHeight;
    public float AnimationUp;

    [Header("PowerUp Invencible")]
    public float DurationInvencible;

    [Header("PowerUp ´Speed")]
    public float DurationSpeed;
    public float AmountToSpeed;

}
