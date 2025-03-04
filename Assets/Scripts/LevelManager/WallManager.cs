using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using generic.core.Singleton;

public class WallManager : Singleton<WallManager>
{

    public GameObject WallObject;

    public List<WallSetup> setupWall;


    public void Randomize()
    {
        //System.Random random = new System.Random();
        Shuffle(setupWall);
    }

    private void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int a = 1;
        int b = 2;
        int n = 5;
        while (n > 1)
        {
            a = Random.Range(0, setupWall.Count);
            b = Random.Range(0, setupWall.Count);
            n--;
            int k = random.Next(n + 1);
            T value = list[a];
            list[a] = list[b];
            list[b] = value;
        }
    }

    public Vector3 GetSetupObject(int i)
    {
        return setupWall[i].positionObject;
    }

}

[System.Serializable]
public class WallSetup
{
    public Vector3 positionObject;
}