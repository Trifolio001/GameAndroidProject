using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOCoordenateMenu : MonoBehaviour
{
    public SOInfoUI soInfoUI;
    public GameObject uiVisible;
    public TextMeshProUGUI uiTextValue;
    public TextMeshProUGUI uiTextTitulo;
    public GameObject ButtonPlay;
    public GameObject ButtonReset;
    public string TxMenu = "Options";
    public string TxVictori = "Vitoria";
    public string TxLost = "Derrota";

    public bool isPaused;



    // Start is called before the first frame update
    void Start()
    {
        soInfoUI.Coins = 0;
        uiTextValue.text = soInfoUI.Coins.ToString();
        isPaused = true;
        OpenOption();
    }

    // Update is called once per frame
    void Update()
    {
        uiTextValue.text = soInfoUI.Coins.ToString(); 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*if (uiOptions.active == false)
            {
                OpenOption();
            }
            else if (uiVolume.active == true)*/
            if (uiVisible.active == false)
            {
                OpenOption();
                Pause();
            }
            else
            {
                CloseOption(); 
                UnPause();
            }
        }
    }


    public void OpenOption()
    {
        uiVisible.SetActive(true);
        uiTextTitulo.text = TxMenu;
        ButtonPlay.SetActive(true);
        ButtonReset.SetActive(false);
    }

    public void OpenVictory()
    {
        uiVisible.SetActive(true);
        uiTextTitulo.text = TxVictori;
        ButtonPlay.SetActive(false);
        ButtonReset.SetActive(true);
    }

    public void OpenLost()
    {
        uiVisible.SetActive(true);
        uiTextTitulo.text = TxLost;
        ButtonPlay.SetActive(false);
        ButtonReset.SetActive(true);
    }

    public void ResetGame()
    {
        uiVisible.SetActive(false);
    }

    public void OpenVolume()
    {
        uiVisible.SetActive(true);
    }


    public void CloseOption()
    {
        uiVisible.SetActive(false);
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

}
