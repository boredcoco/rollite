using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_life : MonoBehaviour
{
    [SerializeField] private float _health = 10f;

    //animate hit motion
    private Animator anim;

    private void Start()
    {
      anim = GetComponent<Animator>();
      anim.ResetTrigger("isHit");
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Attack")
      {
        _health--;
        anim.SetTrigger("isHit");
        Destroy(collision.gameObject);

        if (_health <= 0f)
        {
          Destroy(gameObject);
        }
      }
    }

}
