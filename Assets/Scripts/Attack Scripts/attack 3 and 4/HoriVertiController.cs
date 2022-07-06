using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoriVertiController : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    [SerializeField] private float _lagTime = 1f;

    private GameObject reusableObject;

    private float timer;

    private void Start()
    {
        timer = _lagTime;
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
          if (timer <= 0)
          {
            fireAttack();
            gameObject.SetActive(false);
            timer = _lagTime;
          } else
          {
            timer -= Time.deltaTime;
          }
        }
    }

    private void fireAttack()
    {
      if (reusableObject == null)
      {
        reusableObject = Instantiate(_prefab, transform.position, Quaternion.identity) as GameObject;
      } else
      {
        reusableObject.transform.position = transform.position;
        reusableObject.SetActive(true);
      }
    }
}
