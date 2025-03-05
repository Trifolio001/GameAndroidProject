using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentHelper : MonoBehaviour
{
    public List<Transform> positions;//pontos que ira parar 

    public float duration = 1f;//tempo de espera na posição

    public int _index = 0;



    void Start()
    {

        transform.position = positions[_index].transform.position;
        NextIndex();

        Invoke(nameof(OperationStartTime), Random.Range(0, duration * 2));

    }

    private void OperationStartTime()
    {
        StartCoroutine(startMoviment());
    }

    private void NextIndex()
    {
        _index++;
        if (_index >= positions.Count) _index = 0;
    }

    IEnumerator startMoviment()
    {
        float time = 0;

        while(true)
        { 
            var currentposition = transform.position;

            while(time < duration)
            {
                transform.position = Vector3.Lerp(currentposition, positions[_index].transform.position, (time / duration));

                time += Time.deltaTime;
                yield return null;
            }

            NextIndex();
            time = 0;

            yield return null;
        }
    }


}
