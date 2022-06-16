using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl_individual : MonoBehaviour
{
    [SerializeField] private GameObject _attackStamina;
    [SerializeField] private GameObject _attack1;

    [SerializeField] private float basePower = 1f;

    [SerializeField] private float _lowerX = -5f;
    [SerializeField] private float _upperX = 10f;
    [SerializeField] private float _lowerY = -5f;
    [SerializeField] private float _upperY = 5f;

    private GameObject reusableObject;
    private bool selected = false;

    private void Update()
    {
      if (selected == true && Input.GetMouseButtonDown(0))
      {
        fireBullet();
      }
    }

    public void setSelect(bool select)
    {
      selected = select;
    }

    public void fireBullet()
    {
      float x = Input.mousePosition.x;
      float y = Input.mousePosition.y;

      Vector3 coords = Camera.main.ScreenToWorldPoint(new Vector3(x, y, transform.position.z));
      coords.z = 0;

      if (coords.x > _lowerX && coords.x < _upperX && coords.y > _lowerY && coords.y < _upperY
      && _attackStamina.GetComponent<AttackStamina>().canAttack(basePower))
      {
        if (reusableObject == null)
        {
          reusableObject = Instantiate(_attack1, coords, Quaternion.identity) as GameObject;
        } else
        {
          reusableObject.gameObject.SetActive(true);
          reusableObject.gameObject.transform.position = coords;
        }
        _attackStamina.GetComponent<AttackStamina>().depleteStamina(basePower);
      }
    }
}
