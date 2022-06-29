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
    public float regenSpeed = 0.5f;
    private Coroutine regen;

    private Rigidbody2D plane;

    public ScreenBounds screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        plane = GetComponent<Rigidbody2D>();
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
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
      if (!Quit.quitting && currentStamina < maxStamina)
      {
        currentStamina = currentStamina + (regenSpeed) * Time.deltaTime;
      }
      if (currentStamina > maxStamina) {
        currentStamina = maxStamina;
      }
      //regen = StartCoroutine(LagTime());
    }

    private IEnumerator LagTime()
    {
      yield return new WaitForSeconds(regenLagTime);
      currentStamina = currentStamina + (regenSpeed) * Time.deltaTime;
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
