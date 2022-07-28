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

    private GameObject portal1;
    private GameObject portal2;

    private bool portalSpawned = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Player" && !portalSpawned)
      {
        spawnPortal();
        portalSpawned = true;
        gameObject.SetActive(false);
        GameObject spawner = GameObject.Find("SpawnController");
        spawner.gameObject.GetComponent<Spawnable_oneByOne>().decreaseObjCount();
      }
    }

    private void spawnPortal()
    {
      float portal1_x = Random.Range(_lowerX, _upperX / 2);
      float portal1_y = Random.Range(_lowerY, _upperY);
      Vector3 portal1_v = new Vector3(portal1_x, portal1_y, transform.position.z);

      float portal2_x = Random.Range(_upperX / 2, _upperX);
      float portal2_y = Random.Range(_lowerY, _upperY);
      Vector3 portal2_v = new Vector3(portal2_x, portal2_y, transform.position.z);

      if (portal1 == null && portal2 == null)
      {
        portal1 = Instantiate(portalTemplate, portal1_v, Quaternion.identity) as GameObject;
        portal2 = Instantiate(portalTemplate, portal2_v, Quaternion.identity) as GameObject;
        portal1.GetComponent<Portal>().linkPortals(portal2, gameObject);
        portal2.GetComponent<Portal>().linkPortals(portal1, gameObject);
      } else if (portal1 == null)
      {
        portal2.gameObject.SetActive(true);
        portal2.transform.position = portal2_v;
        portal1 = Instantiate(portalTemplate, portal1_v, Quaternion.identity) as GameObject;
        portal1.GetComponent<Portal>().linkPortals(portal2, gameObject);
      } else if (portal2 == null)
      {
        portal1.gameObject.SetActive(true);
        portal1.transform.position = portal1_v;
        portal2 = Instantiate(portalTemplate, portal2_v, Quaternion.identity) as GameObject;
        portal2.GetComponent<Portal>().linkPortals(portal1, gameObject);
      } else
      {
        portal1.gameObject.SetActive(true);
        portal1.transform.position = portal1_v;
        portal2.gameObject.SetActive(true);
        portal2.transform.position = portal2_v;
      }

    }

    public void deactivatePortals()
    {
      portalSpawned = false;
    }
}
