using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] private GameObject portalTemplate;

    [SerializeField] private float _lowerX = -20f;
    [SerializeField] private float _upperX = 20f;
    [SerializeField] private float _lowerY = -10f;
    [SerializeField] private float _upperY = 10f;

    private Vector3 portal1_v;
    private Vector3 portal2_v;

    private GameObject portal1;
    private GameObject portal2;

    private bool portalSpawned = false;

    private Vector3[] currOccupied;

    private void Start()
    {
      float portal1_x = UnityEngine.Random.Range(_lowerX, _upperX);
      float portal1_y = UnityEngine.Random.Range(_lowerY, _upperY);
      portal1_v = new Vector3(portal1_x, portal1_y, transform.position.z);

      while(Array.Exists(currOccupied, x => x == portal1_v))
      {
        portal1_x = UnityEngine.Random.Range(_lowerX, _upperX);
        portal1_y = UnityEngine.Random.Range(_lowerY, _upperY);
        portal1_v = new Vector3(portal1_x, portal1_y, transform.position.z);
      }

      float portal2_x = UnityEngine.Random.Range(_lowerX, _upperX);
      float portal2_y = UnityEngine.Random.Range(_lowerY, _upperY);
      portal2_v = new Vector3(portal2_x, portal2_y, transform.position.z);

      while(Array.Exists(currOccupied, x => x == portal1_v))
      {
        portal2_x = UnityEngine.Random.Range(_lowerX, _upperX);
        portal2_y = UnityEngine.Random.Range(_lowerY, _upperY);
        portal2_v = new Vector3(portal1_x, portal1_y, transform.position.z);
      }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Player" && !portalSpawned)
      {
        spawnPortal();
        portalSpawned = true;
      }
    }

    public void setCoords(Vector3[] arr)
    {
      currOccupied = arr;
    }

    private void spawnPortal()
    {
      portal1 = Instantiate(portalTemplate, portal1_v, Quaternion.identity) as GameObject;
      portal2 = Instantiate(portalTemplate, portal2_v, Quaternion.identity) as GameObject;

      portal1.GetComponent<Portal>().linkPortals(portal2);
      portal2.GetComponent<Portal>().linkPortals(portal1);

      Destroy(gameObject);
    }
}
