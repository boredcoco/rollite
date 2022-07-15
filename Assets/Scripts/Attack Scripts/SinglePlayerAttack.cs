using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private int stored_num = 5;
    [SerializeField] private float lagTime = 5f;

    [SerializeField] private GameObject staminaBar;
    private AttackStamina staminaComp;

    private Animator anim;

    [SerializeField] private GameObject attack1Prefab;
    [SerializeField] private GameObject attack2Prefab;
    [SerializeField] private GameObject attack3Prefab;
    [SerializeField] private GameObject attack4Prefab;
    [SerializeField] private GameObject attack5Prefab;

    [SerializeField] private float bp1 = 1;
    [SerializeField] private float bp2 = 2;
    [SerializeField] private float bp3 = 3;
    [SerializeField] private float bp4 = 3;
    [SerializeField] private float bp5 = 7;

    private GameObject[] attack1_stored;
    private int index1 = 0;
    private GameObject[] attack2_stored;
    private int index2 = 0;
    private GameObject[] attack3_stored;
    private int index3 = 0;
    private GameObject[] attack4_stored;
    private int index4 = 0;
    private GameObject[] attack5_stored;
    private int index5 = 0;

    private int maxAttackUnlocked = 1;
    private float timer;

    private void Start()
    {
      timer = lagTime;
      staminaComp = staminaBar.GetComponent<AttackStamina>();
      anim = GetComponent<Animator>();

      attack1_stored = new GameObject[stored_num];
      attack2_stored = new GameObject[stored_num];
      attack3_stored = new GameObject[stored_num];
      attack4_stored = new GameObject[stored_num];
      attack5_stored = new GameObject[stored_num];
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
      if (_player.position.x == transform.position.x && _player.position.y < transform.position.y)
      {
        attack1();
      } else if (Mathf.Abs(_player.position.x - transform.position.x) <= 1 && maxAttackUnlocked >= 3)
      {
        attack3();
      } else if (Mathf.Abs(_player.position.y - transform.position.y) <= 1 && maxAttackUnlocked >= 4)
      {
        attack4();
      } else
      {
        int chosen = (int) Random.Range(0, maxAttackUnlocked);
        if (chosen == 0) attack1();
        if (chosen == 1) attack2();
        if (chosen == 2) attack3();
        if (chosen == 3) attack4();
        if (chosen == 4) attack5();
      }
    }

    private void general_instantiate(int index, GameObject prefab, GameObject[] arr, float bp)
    {
      anim.SetTrigger("aim");
      if (arr[index] == null)
      {
        arr[index] = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
      } else
      {
        arr[index].transform.position = transform.position;
        arr[index].SetActive(true);
      }
      staminaComp.depleteStamina(bp);
    }

    private void attack1()
    {
      if (staminaComp.canAttack(bp1))
      {
        if (index1 >= attack1_stored.Length) index1 = 0;
        general_instantiate(index1, attack1Prefab, attack1_stored, bp1);
        index1++;
      }
    }

    private void attack2()
    {
      if (staminaComp.canAttack(bp2))
      {
        if (index2 >= attack2_stored.Length) index2 = 0;
        general_instantiate(index2, attack1Prefab, attack2_stored, bp2);
        index2++;
      }
    }

    private void attack3()
    {
      if (staminaComp.canAttack(bp3))
      {
        if (index3 >= attack3_stored.Length) index3 = 0;
        general_instantiate(index3, attack3Prefab, attack3_stored, bp3);
        index3++;
      }
    }

    private void attack4()
    {
      if (staminaComp.canAttack(bp4))
      {
        if (index4 >= attack4_stored.Length) index4 = 0;
        general_instantiate(index4, attack4Prefab, attack4_stored, bp4);
        index4++;
      }
    }

    private void attack5()
    {
      if (staminaComp.canAttack(bp5))
      {
        if (index5 >= attack5_stored.Length) index5 = 0;
        general_instantiate(index5, attack5Prefab, attack5_stored, bp5);
        index5++;
      }
    }
}
