using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expandingcircle : MonoBehaviour
{
    [SerializeField] private float activeTime = 2f;
    [SerializeField] private float lagTime = 1f;
    [SerializeField] private float scaleFactor = 0.01f;

    private Bullet bulletScript;
    private float activeTimer;
    private float lagTimer;

    private void Start()
    {
        activeTimer = activeTime;
        lagTimer = lagTime;
        bulletScript = GetComponent<Bullet>();
        bulletScript.enabled = true;
    }

    private void Update()
    {
      if (lagTimer <= 0)
      {
        if (!bulletScript.enabled)
        {
          bulletScript.enabled = true;
        }

        if (activeTimer <= 0)
        {
          activeTimer = activeTime;
          gameObject.SetActive(false);
        } else
        {
          Vector3 scaleChange = new Vector3(scaleFactor, scaleFactor, 0);
          transform.localScale += scaleChange;
          activeTimer -= Time.deltaTime;
        }

      } else
      {
        lagTimer -= Time.deltaTime;
      }
    }
}
