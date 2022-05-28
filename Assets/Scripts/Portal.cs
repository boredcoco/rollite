using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject otherPortal;

    [SerializeField] private float howFarFromPortal = 1.5f;

    public void linkPortals(GameObject other)
    {
      otherPortal = other;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.tag == "Player")
      {
        Vector3 newPos = new Vector3(otherPortal.transform.position.x + howFarFromPortal,
                                      otherPortal.transform.position.y + howFarFromPortal,
                                      otherPortal.transform.position.z);
        collision.transform.position = newPos;
      }
    }
}
