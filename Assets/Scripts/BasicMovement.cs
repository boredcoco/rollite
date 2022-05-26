using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed = 7f;
    public float dashSpeed = 20f;
    private float Hdirection = 0f;
    private float Vdirection = 0f;
    private Rigidbody2D plane;

    // Start is called before the first frame update
    void Start()
    {
        plane = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Hdirection = Input.GetAxis("Horizontal");
        Vdirection = Input.GetAxis("Vertical");

        // Basic Movement
        if (Hdirection != 0)
        {
            plane.velocity = new Vector2(Hdirection * speed, plane.velocity.y);
        } else
        {
            plane.velocity = new Vector2(0, plane.velocity.y);
        }

        if (Vdirection != 0)
        {
            plane.velocity = new Vector2(plane.velocity.x, Vdirection * speed);
        }
        else
        {
            plane.velocity = new Vector2(plane.velocity.x, 0);
        }


    }
}
