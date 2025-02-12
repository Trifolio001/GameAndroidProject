using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using generic.core.Singleton;
using TMPro;

public class Item_manager : Singleton<Item_manager>
{

    public SOInfoUI infoUI;
    //public TextMeshProUGUI textNumCoin;

    private void Reset()
    {
        infoUI.Coins = 0;
        UpdateUi();
    }

    public void AddCoin(int ammount = 1)
    {
        infoUI.Coins += ammount;
        UpdateUi();
    }

    private void UpdateUi()
    {
        //UIGameManeger.Instance.UpdateTextCoins(coins.Value.ToString());
    }

}
