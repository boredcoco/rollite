using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float lagTime = 5f;

    [SerializeField] private GameObject staminaBar;
    private AttackStamina staminaComp;

    [SerializeField] private float bp1 = 1;
    [SerializeField] private float bp2 = 3;
    [SerializeField] private float bp3 = 2;
    [SerializeField] private float bp4 = 2;
    [SerializeField] private float bp5 = 5;

    private GameObject[] attack1_stored;
    private GameObject[] attack2_stored;
    private GameObject[] attack3_stored;
    private GameObject[] attack4_stored;
    private GameObject[] attack5_stored;

    private int count = 0;

    private int maxAttackUnlocked = 1;
    private float timer;

    private void Start()
    {
      timer = lagTime;
      staminaComp = staminaBar.GetComponent<AttackStamina>();

      attack1_stored = GameObject.FindGameObjectsWithTag("Attack");
      attack2_stored = GameObject.FindGameObjectsWithTag("BulletController");
      attack3_stored = GameObject.FindGameObjectsWithTag("VertiController");
      attack4_stored = GameObject.FindGameObjectsWithTag("HoriController");
      attack5_stored = GameObject.FindGameObjectsWithTag("RandomExplosionController");

      for (int i = 0; i < attack1_stored.Length; i++)
      {
        attack1_stored[i].SetActive(false);
        if (i < attack2_stored.Length) attack2_stored[i].SetActive(false);
        if (i < attack3_stored.Length) attack3_stored[i].SetActive(false);
        if (i < attack4_stored.Length) attack4_stored[i].SetActive(false);
        if (i < attack5_stored.Length) attack5_stored[i].SetActive(false);
      }

    }

    private void Update()
    {
        if (timer <= 0)
        {
          spawn();
          timer = lagTime;
        } else
        {
          timer = timer -= Time.deltaTime;
        }

    }

    public void unlockAttack()
    {
      maxAttackUnlocked++;
    }

    public int maxAttack_Unlocked()
    {
      return maxAttackUnlocked;
    }

    private void spawn()
    {
      if (!Quit.quitting)
      {
        if (_player.position.x == transform.position.x && _player.position.y < transform.position.y)
        {
          general_instantiate(attack1_stored, bp1);
        } else if (Mathf.Abs(_player.position.x - transform.position.x) <= 1 && maxAttackUnlocked >= 3)
        {
          general_instantiate(attack3_stored, bp3);
        } else if (Mathf.Abs(_player.position.y - transform.position.y) <= 1 && maxAttackUnlocked >= 4)
        {
          general_instantiate(attack4_stored, bp4);
        } else
        {
          int chosen = (int) Random.Range(0, maxAttackUnlocked);
          if (chosen == 0) general_instantiate(attack1_stored, bp1);
          if (chosen == 1) general_instantiate(attack2_stored, bp2);
          if (chosen == 2) general_instantiate(attack3_stored, bp3);
          if (chosen == 3) general_instantiate(attack4_stored, bp4);
          if (chosen == 4) general_instantiate(attack5_stored, bp5);
        }
      }
    }

    private void general_instantiate(GameObject[] arr, float bp)
    {
      int index = count % arr.Length;

      if (staminaComp.canAttack(bp))
      {
        arr[index].transform.position = transform.position;
        arr[index].SetActive(true);
        staminaComp.depleteStamina(bp);
        count++;
      }
    }

}
