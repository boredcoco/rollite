using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] public float restoreAmount = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Player")
      {
        collision.GetComponent<Player_life>().heal(restoreAmount);
        gameObject.SetActive(false);
        GameObject spawner = GameObject.Find("SpawnController");
        spawner.gameObject.GetComponent<Spawnable_oneByOne>().decreaseObjCount();
      }
    }
}
