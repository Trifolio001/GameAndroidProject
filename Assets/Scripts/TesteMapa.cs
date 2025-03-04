using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteMapa : MonoBehaviour
{

    public List<SpriteRenderer> spriteRenderers;
    // Start is called before the first frame update
    void Start()
    {
        //ColorRenderers = new List<Color>();
        //spriteRenderers = new List<SpriteRenderer>();

        foreach (var child in gameObject.GetComponentsInChildren<ConeSpawnPiece>())
        {
            Destroy(child);
        }
        foreach (var child in gameObject.GetComponentsInChildren<ArtPiece>())
        {
            Destroy(child);
        }
        foreach (var child in gameObject.GetComponentsInChildren<CriateWall>())
        {
            Destroy(child);
        }
        foreach (var child in gameObject.GetComponentsInChildren<RandomPredioStates>())
        {
            Destroy(child);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            
        }
    }
}
