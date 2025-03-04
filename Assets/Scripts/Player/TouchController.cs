using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Vector2 pastposition;
    public float velocity;
    private float limit = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - pastposition.x);
        }
        pastposition = Input.mousePosition;

        if(transform.position.x < -limit)
        {
            transform.position = new Vector3(-limit, 0, 0);
        }
        if (transform.position.x > limit)
        {
            transform.position = new Vector3(limit, 0, 0);
        }

    }

    public void LimitUpdate(float num) 
    {
        limit = num;
    }

    public void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * velocity;
    }
}
