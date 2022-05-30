using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_behaviour : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float _shieldHealth = 3f;
    private float currentHealth;

    private void Start()
    {
      currentHealth = _shieldHealth;
    }

    private void Update()
    {
      if (player != null)
      {
        transform.position = player.transform.position;
      }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Player" && player == null)
      {
        player = collision.gameObject;
      }
    }

    public void loseHealth(float amount)
    {
      if (player != null)
      {
        if (currentHealth - amount <= 0)
        {
          Destroy(gameObject);
        } else
        {
          currentHealth = currentHealth - amount;
        }
        Debug.Log("shield health: " + currentHealth);
      }
    }
}
