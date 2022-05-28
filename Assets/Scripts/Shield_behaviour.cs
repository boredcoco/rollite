using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_behaviour : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float _shieldHealth = 3f;

    private void Update()
    {
      if (player != null)
      {
        transform.position = player.transform.position;
      }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Attack")
      {
        _shieldHealth--;
        Destroy(collision.gameObject);

        if (_shieldHealth <= 0f)
        {
          Destroy(gameObject);
        }
      }

      if (collision.tag == "Player" && player == null)
      {
        player = collision.gameObject;
      }
    }
}
