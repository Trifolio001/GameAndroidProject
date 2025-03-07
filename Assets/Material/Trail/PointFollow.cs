using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFollow : MonoBehaviour
{
    public Transform followPoint;

    void Start()
    {
        followPoint = PlayerControll.Instance.gameObject.transform;    
    }

    void Update()
    {
        transform.position = new Vector3(followPoint.localPosition.x, transform.position.y, transform.position.z);
    }
}
