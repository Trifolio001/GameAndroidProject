using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorChange2 : MonoBehaviour
{
    public float duration = .5f;



    public Material meshRender;

    public Color _startColor = Color.green;

    private Color _correctColor;

    private void Start()
    {
       

        //meshRender = Color.green;
        //meshRender = GetComponent<SkinnedMeshRenderer>();

    }
    private void OnValidate()
    {
    }

    private void InitiateAnimate()
    {
        _correctColor = Color.white;
        LerpColor();
    }

    private void LerpColor()
    {
        StartCoroutine(OperationDelay(meshRender, 0.5f));
    }

    IEnumerator OperationDelay(Material spriteSelect, float timesequence)
    {
        for (int i = 1; i <= 5; i++)
        {
            for (int f = 1; f <= 2; f++)
            {
                meshRender.DOColor(_startColor, duration).SetDelay(timesequence / i);
                yield return new WaitForSeconds(timesequence / i);
                meshRender.DOColor(Color.white, duration).SetDelay(timesequence / i);
                yield return new WaitForSeconds(timesequence / i);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LerpColor();
        }
    }
}
