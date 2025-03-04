using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using generic.core.Singleton;

public class ArtManager : Singleton<ArtManager>
{
    public enum ArtType
    {
        Road,
        Florest,
        RoadDanger
    }

    public List<ArtSetup> setupArt;

    public GameObject GetSetupByType(ArtType artType)
    {
        //return setupArt.Find(i => i.arttype == artType);

        for (int i = 0; i < setupArt.Count; i++)
        {
            if (setupArt[i].arttype == artType)
            {                
                return setupArt[i].objectsinArt[Random.Range(0, setupArt[i].objectsinArt.Count)].gameobject;
                break; 
            }
        }

        return null;
    }

       
}

[System.Serializable]
public class ArtSetup
{
    public ArtManager.ArtType arttype;
    public List<ObjectsArt> objectsinArt;
}

[System.Serializable]
public class ObjectsArt
{
    public GameObject gameobject;
}

