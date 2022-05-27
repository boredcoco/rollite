using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_life : MonoBehaviour
{
    [SerializeField] private float _health = 10f;

    private void Update()
    {
      if (_health <= 0f)
      {
        Destroy(gameObject);
      }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Attack")
      {
        Destroy(collision.gameObject);
        _health--;
      }
    }
}
