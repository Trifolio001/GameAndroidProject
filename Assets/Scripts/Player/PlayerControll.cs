using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using generic.core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerControll : Singleton<PlayerControll>
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;
    public string tagToCheckEnimy; 
    public string tagToCheckVictory;
    public TextMeshPro uiTextPowerUp;
    public SOCoordenateMenu springMenu;
    public Rigidbody rigidbodyPlayer;

    [Header("Coin Setup")]
    public GameObject coinCollector;
    public Collider coinCollider;
    //public CircleCollider2D colliderPlayer;

    private Tween _curretTween;
    private bool Referencetime = false;

    private float _currentSpeed;

    private bool _canRun;
    private Vector3 _pos;
    private Vector3 _startPosition;
    public bool invencible = false;
    public bool fly = false;



    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;



        transform.position = Vector3.Lerp(transform.position, new Vector3 (target.position.x, transform.position.y, transform.position.z), lerpSpeed * Time.deltaTime);
        //transform.Translate(transform.forward * speed * Time.deltaTime); 
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);        
    }

    private void OnTriggerEnter(Collider collision)
    {
            if (collision.transform.tag == tagToCheckEnimy)
            {
                if (!invencible)
                {
                    springMenu.OpenLost();
                    _canRun = false;
                }
            }
            if (collision.transform.tag == tagToCheckVictory)
            {
                springMenu.OpenVictory();
                _canRun = false;            }
        
    }

    public void StarToRun()
    {
        _canRun = true;
    }

    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }
    public void SetInvencible(bool b)
    {
        invencible = b;
    }
    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        rigidbodyPlayer.useGravity = (false);
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);//.OnComplete(ResetHeight);a
        Invoke(nameof(InitialFly), animationDuration + 0.1f);
        Invoke(nameof(ResetHeight), duration);
    }

    public void InitialFly()
    {
        fly = true;
    }

    public void ResetHeight()
    {
        fly = false;
        rigidbodyPlayer.useGravity = (true);
        //transform.DOMoveY(_startPosition.y, .1f);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }

}
