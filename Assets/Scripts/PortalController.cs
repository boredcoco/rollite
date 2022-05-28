using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] private GameObject portalTemplate;

    [SerializeField] private float portal1_x = -1;
    [SerializeField] private float portal1_y = -1;
    [SerializeField] private float portal2_x = 1;
    [SerializeField] private float portal2_y = 1;

    private GameObject portal1;
    private GameObject portal2;

    private void Start()
    {
      Vector3 portal1_v = new Vector3(portal1_x, portal1_y, transform.position.z);
      Vector3 portal2_v = new Vector3(portal2_x, portal2_y, transform.position.z);
      portal1 = Instantiate(portalTemplate, portal1_v, Quaternion.identity) as GameObject;
      portal2 = Instantiate(portalTemplate, portal2_v, Quaternion.identity) as GameObject;

      portal1.GetComponent<Portal>().linkPortals(portal2);
      portal2.GetComponent<Portal>().linkPortals(portal1);
    }

    private void Update()
    {

    }
}
