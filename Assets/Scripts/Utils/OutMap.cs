using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutMap : MonoBehaviour
{
    public SOCoordenateMenu springMenu;
    public string tagToCheckPlayer = "Player";
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == tagToCheckPlayer)
        {
            springMenu.OpenLost();
        }else
        {
            Destroy(collision.gameObject);
        }

    }
}
