using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed = 7f;

    private float Hdirection = 0f;
    private float Vdirection = 0f;

    public float dashForce = 15f;
    public float startDashTimer;
    public float currentDashTimer;
    private bool isDashing = false;

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

        // Dashing
        if (Input.GetKeyDown(KeyCode.Space) && (Hdirection != 0 || Vdirection != 0))
        {
            isDashing = true;
            currentDashTimer = startDashTimer;
            plane.velocity = Vector2.zero;
        }

        if (isDashing)
        {

            if (Vdirection != 0)
            {
                plane.velocity = new Vector2(plane.velocity.x, Vdirection * dashForce);
            }

            if (Hdirection != 0)
            {
                plane.velocity = new Vector2(Hdirection * dashForce, plane.velocity.y);
            }
            
            

            currentDashTimer -= Time.deltaTime;

            if (currentDashTimer <= 0)
            {
                isDashing = false;
            }
        }

    }
}
