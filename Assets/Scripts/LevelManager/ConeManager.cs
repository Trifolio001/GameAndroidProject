using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using generic.core.Singleton;

public class ConeManager : Singleton<ConeManager>
{
    public List<ConeSetupObject> coneObject;

    public List<ConeSetupPosition> conePosition;
    public void Randomize()
    {
        Shuffle(conePosition);
    }

    private void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int a = 1;
        int b = 2;
        int n = 5;
        while (n > 1)
        {
            a = Random.Range(0, conePosition.Count);
            b = Random.Range(0, conePosition.Count);
            n--;
            int k = random.Next(n + 1);
            T value = list[a];
            list[a] = list[b];
            list[b] = value;
        }
    }
}


[System.Serializable]
public class ConeSetupPosition
{
    public Vector3 positionUnderCone;
}

[System.Serializable]
public class ConeSetupObject
{
    public GameObject ObjectContein;
}

