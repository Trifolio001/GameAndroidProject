using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeSpawnPiece : MonoBehaviour
{
    //public int ContCone;

    private void Start()
    {
        ConeManager.Instance.Randomize();
        int Reference = Random.Range(0, ConeManager.Instance.conePosition.Count);
        for (int i = 0; i < Reference; i++)
        {
            Vector3 positionObj = new Vector3(transform.position.x + ConeManager.Instance.conePosition[i].positionUnderCone.x, transform.position.y + ConeManager.Instance.conePosition[i].positionUnderCone.y, transform.position.z + ConeManager.Instance.conePosition[i].positionUnderCone.z);
            GameObject instance = Instantiate(ConeManager.Instance.coneObject[Random.Range(0, ConeManager.Instance.coneObject.Count)].ObjectContein, positionObj, ConeManager.Instance.coneObject[0].ObjectContein.transform.rotation);
            instance.transform.SetParent(transform);
        }
    }
}
