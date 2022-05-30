using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float basePower = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Player")
      {
        gameObject.SetActive(false);
        collision.gameObject.GetComponent<Player_life>().loseHealth(basePower);
      } else if (collision.tag == "Shield")
      {
        gameObject.SetActive(false);
        collision.gameObject.GetComponent<Shield_behaviour>().loseHealth(basePower);
      }
    }
}
