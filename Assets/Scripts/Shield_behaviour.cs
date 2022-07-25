using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_behaviour : MonoBehaviour, Health
{
    private GameObject player;
    [SerializeField] public float _shieldHealth = 3f;
    private float currentHealth;

    [SerializeField] private AudioSource shieldSound;

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
      if (collision.tag == "Player" && player == null
      && !collision.GetComponent<Player_life>().isActiveShield())
      {
        collision.GetComponent<Player_life>().activateShield();
        shieldSound.Play();
        player = collision.gameObject;
      }
    }

    public void loseHealth(float amount)
    {
      if (player != null)
      {
        if (currentHealth - amount <= 0)
        {
          player.GetComponent<Player_life>().deactivateShield();
          gameObject.SetActive(false);
          currentHealth = _shieldHealth;
          player = null;
          GameObject spawner = GameObject.Find("SpawnController");
          spawner.gameObject.GetComponent<Spawnable_oneByOne>().decreaseObjCount();
        } else
        {
          currentHealth = currentHealth - amount;
        }
        Debug.Log("shield health: " + currentHealth);
      }
    }

    public bool isDashing()
    {
      if (player == null) return false;
      return player.GetComponent<BasicMovement>().isDashing;
    }

    public bool isActiveShield() {
      return player != null;
    }
}
