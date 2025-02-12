using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using generic.core.Singleton;

public class UIGameManeger : Singleton<UIGameManeger>
{
    public TextMeshProUGUI uiTextCoins;

    public void UpdateTextCoins(string s)
    {
        uiTextCoins.text = s;
    }

    public void PressOption()
    {

    }
    
}
