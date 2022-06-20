using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public static float speed = 7f;

    private float Hdirection = 0f;
    private float Vdirection = 0f;

    // Dashing
    public float dashForce = 15f;
    public float startDashTimer;
    private float currentDashTimer;
    public bool isDashing = false;

    // Stamina
    public float maxStamina = 10f;
    public float currentStamina = 10f;
    public float regenLagTime = 0.1f;
    public float regenSpeed = 0.1f;
    private Coroutine regen;

    private Rigidbody2D plane;

    // Start is called before the first frame update
    void Start()
    {
        plane = GetComponent<Rigidbody2D>();
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        Hdirection = Input.GetAxis("Horizontal");
        Vdirection = Input.GetAxis("Vertical");

        if (!Quit.quitting)
        {
            // Basic Movement
            if (Hdirection != 0)
            {
                plane.velocity = new Vector2(Hdirection * speed, plane.velocity.y);
            }
            else
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
                if (currentStamina >= 1f)
                {
                    isDashing = true;
                    currentDashTimer = startDashTimer;
                    plane.velocity = Vector2.zero;
                    currentStamina--;
                }
                else
                {
                    isDashing = false;
                }
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

            useStamina();

        }

    }

    // Stamina
    public float getCurrStamina()
    {
      return currentStamina / maxStamina;
    }

    private void useStamina()
    {
      currentStamina = currentStamina + (regenSpeed) * Time.deltaTime;
      //regen = StartCoroutine(LagTime());
    }

    private IEnumerator LagTime()
    {
      yield return new WaitForSeconds(regenLagTime);
      currentStamina = currentStamina + (regenSpeed) * Time.deltaTime;
    }
}
