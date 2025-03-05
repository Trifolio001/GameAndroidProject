using System.Collections;
using System.Collections.Generic;
using generic.core.Singleton;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class CoinsAnimatorManager : Singleton<CoinsAnimatorManager>
{
    public List<Item_coin_Collet> itens;
    
    [Header("Animation Start")]
    public float scaleDuration = .2f;
    public float scaleTimeBetweenPiece = .1f;
    public Ease easeStartGame = Ease.OutBack;

    void Start()
    {
        itens = new List<Item_coin_Collet>();
    }

    public void StartAnimator()
    {
        StartCoroutine(ScalePieceTime());
    }

    IEnumerator ScalePieceTime()
    {
        foreach (var p in itens)
        {
            p.transform.localScale = Vector3.zero;
        }
        SORT();

        yield return null;


        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].transform.DOScale(1, scaleDuration).SetEase(easeStartGame);
            yield return new WaitForSeconds(scaleTimeBetweenPiece);
        }

    }

    public void registercoins(Item_coin_Collet i)
    {
        if (!itens.Contains(i))
            itens.Add(i);
    }

    private void SORT()
    {
        itens = itens.OrderBy(x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }
}
