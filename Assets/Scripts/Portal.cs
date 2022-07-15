using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject portalController;
    private GameObject otherPortal;
    private ObstacleSpawnerScript obsSpawnScript;

    private AudioSource[] audios;

    private void Start()
    {
      GameObject obsSpawn = GameObject.Find("SpawnController");
      if (obsSpawn != null)
      {
        obsSpawnScript = obsSpawn.GetComponent<ObstacleSpawnerScript>();
      }
      if (obsSpawnScript != null &&
      obsSpawnScript.isObstacle((int) transform.position.x, (int) transform.position.y))
      {
        float x = Random.Range(-7, 7);
        float y = Random.Range(-5, 5);
        Vector3 pos = new Vector3(x, y, transform.position.z);
        transform.position = pos;
      }
    }

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
        audios = collision.GetComponents<AudioSource>();
        audios[0].Play();
        collision.transform.position = newPos;

        portalController.gameObject.GetComponent<PortalController>().deactivatePortals();

        gameObject.SetActive(false);
        otherPortal.gameObject.SetActive(false);

      }
    }

}
