using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public static float speed = 8f;

    private float Hdirection = 0f;
    private float Vdirection = 0f;

    // Dashing
    public static float dashForce = 15f;
    public float startDashTimer;
    private float currentDashTimer;
    public bool isDashing = false;

    // Stamina
    public float maxStamina = 10f;
    public float currentStamina = 10f;
    public float regenLagTime = 0.1f;
    public float regenSpeed = 0.5f;

    private Rigidbody2D plane;

    public ScreenBounds screenBounds;

    private void Start()
    {
        plane = GetComponent<Rigidbody2D>();
        currentStamina = maxStamina;
    }

    private void Update()
    {
        screenWrap(transform.localPosition);

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
            if (Input.GetKeyDown(KeyCode.Space) && (Hdirection != 0 || Vdirection != 0) && !isDashing)
            {
                if (currentStamina >= 1f)
                {
                    isDashing = true;
                    currentDashTimer = startDashTimer;
                    plane.velocity = Vector2.zero;
                    currentStamina--;
                }
            }

            if (isDashing)
            {
                transform.localScale = new Vector3(0.03f, 0.03f, 1f);
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

            if (!isDashing)
            {
              transform.localScale = new Vector3(0.05f, 0.05f, 1f);
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
      if (!Quit.quitting && currentStamina < maxStamina)
      {
        currentStamina = currentStamina + (regenSpeed) * Time.deltaTime;
      }
      if (currentStamina > maxStamina) {
        currentStamina = maxStamina;
      }
    }


    // Screen Wrap
    private void screenWrap(Vector3 tempPosition)
    {
        if (screenBounds.AmIOutOfBounds(tempPosition))
        {
            Vector2 newPosition = screenBounds.CalculateWrappedPosition(tempPosition);
            transform.position = newPosition;
        }
        else
        {
            transform.position = tempPosition;
        }
    }
}
