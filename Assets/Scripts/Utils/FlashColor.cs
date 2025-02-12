using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers; 
    public Color color = Color.red;
    public float duration = .001f;

    private Tween _curretTween;
    private bool Referencetime = false;
    private int timeMili = 0;

    public List<Color> ColorRenderers;

    private void Start()
    {
        Invoke(nameof(OnValidate), 1f);
    }

    

    private void OnValidate()
    {
        Referencetime = true;
        ColorRenderers = new List<Color>();
        spriteRenderers = new List<SpriteRenderer>();
        foreach(var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
            ColorRenderers.Add(child.color);
        }
    }

    private void Update()
    {
        
    }


    public void Flash()
    {
        /*Debug.Log(_curretTween);
        if (_curretTween != null)
        {
            Debug.Log("passo");
            spriteRenderers.ForEach(i => i.color = Color.white);
            _curretTween.Kill();
        }*/

        //Debug.Log(timeMili + " = e = " + Referencetime);

        if(Referencetime)
        {
            foreach (var s in spriteRenderers)
            {
                s.DOColor(color, duration).SetLoops(1, LoopType.Yoyo);
            }
            timeMili = 10;
            Referencetime = false;
            Invoke(nameof(OperaçãodeTempo), duration+0.1f);
        }
        
    }

    public void OperaçãodeTempo()
    {
        foreach (var s in ColorRenderers)
        {
            spriteRenderers.ForEach(i => i.color = s);
        }            
        Referencetime = true;
    }


    public void OnKill()
    {
        StartCoroutine(OperaçãodeTempoSumir());
    }

    IEnumerator OperaçãodeTempoSumir()
    {
        yield return new WaitForSeconds(2f);
        for (float i = 1; i >= 0; i -= 0.2f)
        {
            yield return new WaitForSeconds(0.3f);
            SetTransparency(i);
        }
        Destroy(gameObject, 0.1f);
    }
    public void SetTransparency(float alpha)
    {
        spriteRenderers.ForEach(i =>
        {
            Color color = i.color; 
            color.a = alpha; 
            i.color = color; 
        });

    }
}
