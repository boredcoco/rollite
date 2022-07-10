using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff_behaviour : MonoBehaviour
{
    private GameObject attackStamina;
    private GameObject[] temp;

    private void Start()
    {
        temp = GameObject.FindGameObjectsWithTag("Attack Stamina");

        if (temp != null)
        {
            attackStamina = temp[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Player")
      {
            attackStamina.GetComponent<AttackStamina>().debuffStamina();
            gameObject.SetActive(false);
            GameObject spawner = GameObject.Find("SpawnController");
            spawner.gameObject.GetComponent<Spawnable_oneByOne>().decreaseObjCount();
      }
    }
}
