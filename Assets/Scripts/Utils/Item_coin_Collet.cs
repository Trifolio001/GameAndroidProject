using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_coin_Collet : Colect_Base
{

    [Header("setup")]
    public SOValueCoins soCoinSetup;
    //public SpriteRenderer spritRender;



    private void Awake()
    {
        //spritRender = GetComponentInChildren<SpriteRenderer>();
        //spritRender.color = soCoinSetup.color;
    }

    protected override void OnCollect()
    {        
        base.OnCollect();
        Item_manager.Instance.AddCoin(soCoinSetup.value);
        
    }


}
