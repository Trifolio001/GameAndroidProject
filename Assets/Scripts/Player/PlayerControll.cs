using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;
    public string tagToCheckEnimy; 
    public string tagToCheckVictory;
    public SOCoordenateMenu springMenu;
    //public CircleCollider2D colliderPlayer;

    private bool _canRun;
    private Vector3 _pos;


    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;



        transform.position = Vector3.Lerp(transform.position, new Vector3 (target.position.x, transform.position.y, transform.position.z), lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("ooooo " + collision.transform.tag + "  adgasjokihg " + tagToCheckEnimy);
        if(collision.transform.tag == tagToCheckEnimy)
        {
            springMenu.OpenLost();
            _canRun = false;
        }
        if (collision.transform.tag == tagToCheckVictory)
        {
            springMenu.OpenVictory();
            _canRun = false;
        }
    }

    public void StarToRun()
    {
        _canRun = true;
    }
}
