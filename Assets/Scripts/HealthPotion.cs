using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private float restoreAmount = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Player")
      {
        collision.GetComponent<Player_life>().heal(restoreAmount);
        Destroy(gameObject);
      }
    }
}
