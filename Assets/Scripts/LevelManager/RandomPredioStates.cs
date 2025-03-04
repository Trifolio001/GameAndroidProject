using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPredioStates : MonoBehaviour
{

    public List<GameObject> predios;

    void Start()
    {
        int RandomStart = ((int)Random.Range(0, 2) * 2 - 1);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * RandomStart);


        for (int i = 0; i < predios.Count; i++)
        {
            Renderer rend = predios[i].GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material = ColorManager.Instance.materialColorPredioSetups[Random.Range(0, ColorManager.Instance.materialColorPredioSetups.Count)];
            }
        }
    }
}
