using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_life : MonoBehaviour
{
    [SerializeField] private float _health = 10f;
    private float currentHealth;

    //animate hit motion
    private Animator anim;

    private void Start()
    {
      anim = GetComponent<Animator>();
      anim.ResetTrigger("isHit");
      currentHealth = _health;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Attack")
      {
        anim.SetTrigger("isHit");
      }
    }

    public void heal(float amount)
    {
      if (currentHealth + amount > _health)
      {
        currentHealth = _health;
      } else
      {
        currentHealth = currentHealth + amount;
      }
      Debug.Log(currentHealth);
    }

    public void loseHealth(float amount)
    {
      if (currentHealth - amount <= 0)
      {
        Destroy(gameObject);
      } else
      {
        currentHealth = currentHealth - amount;
      }
      Debug.Log("player health:" + currentHealth);
    }

}
