using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colect_Base : MonoBehaviour
{

    public string compareTag = "Player";

    public ParticleSystem particlesystem;
    public float timeToHide = 2;
    public GameObject graphicItem;

    private bool capture = false;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
       capture = false;
        /*if (particlesystem != null)
        {
            particlesystem.transform.SetParent(null);
        }*/
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        if (graphicItem != null) { 
            graphicItem.SetActive(false); 
        }

        Invoke("HideObject", timeToHide);
        OnCollect();
    }

    protected virtual void OnCollect()
    {
        if (!capture)
        {
            if (particlesystem != null)
            {
                particlesystem.transform.SetParent(null);
                particlesystem.Play();
                capture = true;
            }

            if (audioSource != null) 
            { 
                audioSource.Play(); 
            }
        }
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

}
