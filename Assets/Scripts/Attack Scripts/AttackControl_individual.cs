using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl_individual : MonoBehaviour
{

    public GameObject quitPopUp;

    [SerializeField] private GameObject _attackStamina;

    [SerializeField] private string _tagToFind = "Attack";
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
      reusableObjects = GameObject.FindGameObjectsWithTag(_tagToFind);
      for (int i = 0; i < reusableObjects.Length; i++)
      {
        reusableObjects[i].SetActive(false);
      }
    }

    private void Update()
    {
      if (selected == true && Input.GetMouseButtonDown(0) && !quitPopUp.activeSelf)
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

      if (index >= reusableObjects.Length) {
        index = 0;
      }


      if (coords.x >= _lowerX && coords.x <= _upperX && coords.y >= _lowerY && coords.y <= _upperY
      && _attackStamina.GetComponent<AttackStamina>().canAttack(basePower))
      {
        if (!reusableObjects[index].activeSelf) {
          reusableObjects[index].gameObject.SetActive(true);
          reusableObjects[index].gameObject.transform.position = coords;
          _attackStamina.GetComponent<AttackStamina>().depleteStamina(basePower);
        }
        index++;
      }
    }
}
