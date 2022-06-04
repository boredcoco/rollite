using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable_oneByOne : MonoBehaviour
{

  [SerializeField] private float _lowerX = -10f;
  [SerializeField] private float _upperX = 20f;
  [SerializeField] private float _lowerY = -10f;
  [SerializeField] private float _upperY = 10f;

  [SerializeField] private GameObject _healthPotion;
  [SerializeField] private GameObject _debuff;
  [SerializeField] private GameObject _portalBuff;
  [SerializeField] private GameObject _shield;

  [SerializeField] private int _noOfHealthPotions = 1;
  [SerializeField] private int _noOfDebuffs = 1;
  [SerializeField] private int _noOfPortals = 1;
  [SerializeField] private int _noOfShield = 1;

  private int totalObjects;
  private GameObject[] storedObjects =  new GameObject[4]; //store here after deactivation
  private GameObject currentObject = null;

  private float timer = 5f;

  private void Start()
  {
    totalObjects = _noOfHealthPotions + _noOfDebuffs + _noOfPortals + _noOfShield;

    for (int i = 0; i < 4; i++)
    {
      storedObjects[i] = null;
    }

    if (currentObject == null)
    {
      currentObject = instantiateObj();
    }
  }

  private void Update()
  {
    if (currentObject == null || !currentObject.gameObject.activeSelf)
    {
      if (timer <= 0)
      {
        currentObject = instantiateObj();
        timer = Random.Range(0f, 5f);
      } else
      {
        timer = timer - Time.deltaTime;
      }
    }
  }

  private GameObject instantiateObj()
  {
    float randX = Random.Range(_lowerX, _upperX);
    float randY = Random.Range(_lowerY, _upperY);
    Vector3 coord = new Vector3(randX, randY, transform.position.z);

    int randObject = (int) Random.Range(0, totalObjects);

    if (randObject < _noOfHealthPotions)
    {
      if (storedObjects[0] != null)
      {
        storedObjects[0].gameObject.transform.position = coord;
        storedObjects[0].gameObject.SetActive(true);
      } else
      {
        storedObjects[0] = Instantiate(_healthPotion, coord, Quaternion.identity) as GameObject;
      }
      return storedObjects[0];
    } else if (randObject < _noOfHealthPotions + _noOfDebuffs)
    {
      if (storedObjects[1] != null)
      {
        storedObjects[1].gameObject.transform.position = coord;
        storedObjects[1].gameObject.SetActive(true);
      } else
      {
        storedObjects[1] = Instantiate(_debuff, coord, Quaternion.identity) as GameObject;
      }
      return storedObjects[1];
    } else if (randObject < _noOfHealthPotions + _noOfDebuffs + _noOfPortals)
    {
      if (storedObjects[2] != null)
      {
        storedObjects[2].gameObject.transform.position = coord;
        storedObjects[2].gameObject.SetActive(true);
      } else
      {
        storedObjects[2] = Instantiate(_portalBuff, coord, Quaternion.identity) as GameObject;
      }
      return storedObjects[2];
    } else
    {
      if (storedObjects[3] != null)
      {
        storedObjects[3].gameObject.transform.position = coord;
        storedObjects[3].gameObject.SetActive(true);
      } else
      {
        storedObjects[3] = Instantiate(_shield, coord, Quaternion.identity) as GameObject;
      }
      return storedObjects[3];
    }
  }

}
