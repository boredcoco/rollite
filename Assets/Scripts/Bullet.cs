using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float basePower = 1f;

    [SerializeField] private float _lowerX = -5f;
    [SerializeField] private float _upperX = 10f;
    [SerializeField] private float _lowerY = -5f;
    [SerializeField] private float _upperY = 5f;

    private void Update()
    {
      if (transform.position.x < _lowerX || transform.position.x > _upperX
      || transform.position.y < _lowerY || transform.position.y > _upperY)
      {
        gameObject.SetActive(false);
      }
    }

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
