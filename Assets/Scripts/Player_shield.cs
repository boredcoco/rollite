using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shield : MonoBehaviour
{
    [SerializeField] private GameObject _shield;
    private bool shieldOn = false;
    private GameObject activeShield;

    private void Update()
    {
      if (shieldOn == true)
      {
        activeShield.transform.position = transform.position;
      }

      if (Input.GetKeyDown(KeyCode.C) && !shieldOn)
      {
        activeShield = Instantiate(_shield, transform.position, Quaternion.identity) as GameObject;
        shieldOn = true;
      }
    }
}
