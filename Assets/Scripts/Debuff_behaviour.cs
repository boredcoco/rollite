using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff_behaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Player")
      {
        gameObject.SetActive(false);
      }
    }
}
