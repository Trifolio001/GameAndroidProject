using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using generic.core.Singleton;

public class PowerUpManager : Singleton<PowerUpManager>
{
    public List<PowerUpSetupObject> powerUpObject;

    public List<PowerUpSetupPosition> powerUpPosition;

}


[System.Serializable]
public class PowerUpSetupPosition
{
    public Vector3 positionPowerUp;
}

[System.Serializable]
public class PowerUpSetupObject
{
    public GameObject ObjectPowerUp;
}
