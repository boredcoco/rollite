using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl_individual : MonoBehaviour
{
    [SerializeField] private GameObject _attackStamina;
    [SerializeField] private GameObject _attack;

    [SerializeField] private int _numOfObjects = 5;
    [SerializeField] private float basePower = 1f;

    [SerializeField] private float _lowerX = -7f;
    [SerializeField] private float _upperX = 10f;
    [SerializeField] private float _lowerY = -5f;
    [SerializeField] private float _upperY = 5f;


    private GameObject[] reusableObjects;
    private int index = 0;
    private bool selected = false;

    private void Start()
    {
      reusableObjects = new GameObject[_numOfObjects];
      for (int i = 0; i < _numOfObjects; i++) {
        reusableObjects[i] = null;
      }
    }

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

      if (index >= _numOfObjects) {
        index = 0;
      }


      if (coords.x >= _lowerX && coords.x <= _upperX && coords.y >= _lowerY && coords.y <= _upperY
      && _attackStamina.GetComponent<AttackStamina>().canAttack(basePower))
      {
        if (reusableObjects[index] == null) {
          reusableObjects[index] = Instantiate(_attack, coords, Quaternion.identity) as GameObject;
          _attackStamina.GetComponent<AttackStamina>().depleteStamina(basePower);
        } else if (!reusableObjects[index].activeSelf) {
          reusableObjects[index].gameObject.SetActive(true);
          reusableObjects[index].gameObject.transform.position = coords;
          _attackStamina.GetComponent<AttackStamina>().depleteStamina(basePower);
        }
        index++;
      }
    }
}
