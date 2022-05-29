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
        currentHealth--;
        anim.SetTrigger("isHit");
        Destroy(collision.gameObject);

        if (currentHealth <= 0f)
        {
          Destroy(gameObject);
        }
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

}
