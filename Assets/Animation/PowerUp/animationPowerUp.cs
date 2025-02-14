using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class animationPowerUp : MonoBehaviour
{
    public GameObject ObjectAnimator; 
    public Vector3 ObjetoRodando = new Vector3(0, 20, 0);
    public float Movement = 5f; 
    public float duracao = 2;
    public Ease ease = Ease.InOutQuad;

    private Tween _curretTween;
    private bool Referencetime = false;



    void Update()
    {
        ObjectAnimator.transform.Rotate(ObjetoRodando * Time.deltaTime);
        if (_curretTween == null)
        {
            _curretTween = ObjectAnimator.transform.DOLocalMoveY(Movement, duracao).SetEase(ease, 1);
            Invoke(nameof(OperacaodeTempo), duracao + 0.1f);
        }
    }

    private void OperacaodeTempo()
    {
        Movement *= -1;
        _curretTween = null;
    }
}
