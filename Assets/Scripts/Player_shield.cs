using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shield : MonoBehaviour
{
    [SerializeField] private GameObject _shield;
    [SerializeField] private float _shieldTime = 200f;

    private GameObject activeShield;
    private bool shieldOn = false;
    private float timer;

    private void Start()
    {
      timer = _shieldTime;
    }

    private void Update()
    {
      if (shieldOn == true)
      {
        if (timer <= 0)
        {
          shieldOn = false;
          Destroy(activeShield);
          activeShield = null;
          timer = _shieldTime;
        } else
        {
          activeShield.transform.position = transform.position;
          timer--;
        }
      }

      if (Input.GetKeyDown(KeyCode.C) && !shieldOn)
      {
        activeShield = Instantiate(_shield, transform.position, Quaternion.identity) as GameObject;
        shieldOn = true;
      }
    }
}
