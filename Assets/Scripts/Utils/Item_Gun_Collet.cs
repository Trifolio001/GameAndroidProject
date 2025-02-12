using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Item_Gun_Collet : Colect_Base
{
    public SOInfoUI colected;
    public SpriteRenderer reference;

    public int codigo = 1;

    public UnityEvent eventCallback;

    
        //public GameObject coinObj;
        protected override void OnCollect()
        {

            /*colected.ListSlotsGuns[colected.selectrender].slot = reference.sprite;
            colected.ListSlotsGuns[colected.selectrender].codigo = codigo;*/

            eventCallback?.Invoke();
        
            base.OnCollect();
        }
    
}
