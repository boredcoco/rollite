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

    [SerializeField] private float _lagTime = 0f;
    private float timer;
    private bool activeBullet = false;

    private void Start()
    {
      timer = _lagTime;
    }

    private void Update()
    {
      if (transform.position.x < _lowerX || transform.position.x > _upperX
      || transform.position.y < _lowerY || transform.position.y > _upperY)
      {
        gameObject.SetActive(false);
      }
      if (gameObject.activeSelf)
      {
        if (timer <= 0)
        {
          activeBullet = true;
        } else
        {
          timer -= Time.deltaTime;
          activeBullet = false;
        }
      }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Player" && timer <= 0)
      {
        gameObject.SetActive(false);
        collision.gameObject.GetComponent<Player_life>().loseHealth(basePower);
        timer = _lagTime;
      } else if (collision.tag == "Shield" && timer <= 0)
      {
        gameObject.SetActive(false);
        collision.gameObject.GetComponent<Shield_behaviour>().loseHealth(basePower);
        timer = _lagTime;
      }
    }

    public bool isActiveBullet()
    {
      return activeBullet;
    }
}
