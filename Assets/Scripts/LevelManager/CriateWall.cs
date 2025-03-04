using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriateWall : MonoBehaviour
{

    public int ContWall;

    private void Start()
    {
        WallManager.Instance.Randomize();
        for (int i = 0; i < ContWall; i++)
        {
            Vector3 positionObj = new Vector3(WallManager.Instance.GetSetupObject(i).x, transform.position.y + WallManager.Instance.GetSetupObject(i).y, transform.position.z);
            GameObject instance = Instantiate(WallManager.Instance.WallObject, positionObj, transform.rotation);
            instance.transform.SetParent(transform);
        }
    }
}


