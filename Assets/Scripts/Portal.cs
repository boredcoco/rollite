using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject portalController;
    private GameObject otherPortal;

    public void linkPortals(GameObject other, GameObject control)
    {
      otherPortal = other;
      portalController = control;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.tag == "Player")
      {
        Vector3 newPos = new Vector3(otherPortal.transform.position.x,
                                      otherPortal.transform.position.y,
                                      otherPortal.transform.position.z);
        collision.transform.position = newPos;

        portalController.gameObject.GetComponent<PortalController>().deactivatePortals();

        gameObject.SetActive(false);
        otherPortal.gameObject.SetActive(false);

      }
    }

}
