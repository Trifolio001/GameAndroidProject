using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_coin_Collet : Colect_Base
{

    [Header("setup")] 
    //public Collider collider2;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;

    public SOValueCoins soCoinSetup;
    public string compareTagPowerUp = "CoinCollect";
    //public SpriteRenderer spritRender;


    private void Awake()
    {
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTagPowerUp))
        {
            collect = true;
            Invoke(nameof(OperacaodeTempo), 5);
        }

        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected override void OnCollect()
    {        
        base.OnCollect();
        Item_manager.Instance.AddCoin(soCoinSetup.value);        
    }

    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerControll.Instance.transform.position, lerp * Time.deltaTime);
        }
    }


    private void OperacaodeTempo()
    {
        lerp *= 10;
    }

}
