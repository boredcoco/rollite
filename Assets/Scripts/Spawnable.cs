using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable : MonoBehaviour
{
    [SerializeField] private float _lowerX = -20f;
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

    private Vector3[] allCoords;
    private int allCoords_counter = 0;

    // Start is called before the first frame update
    private void Start()
    {
      allCoords = new Vector3[_noOfHealthPotions + _noOfDebuffs + _noOfPortals + _noOfShield];

      for (int i = 0; i < _noOfHealthPotions; i++)
      {
        float x = UnityEngine.Random.Range(_lowerX, _upperX);
        float y = UnityEngine.Random.Range(_lowerY, _upperY);
        Vector3 coord = new Vector3(x, y, transform.position.z);

        while(Array.Exists(allCoords, x => x == coord))
        {
          x = UnityEngine.Random.Range(_lowerX, _upperX);
          y = UnityEngine.Random.Range(_lowerY, _upperY);
          coord = new Vector3(x, y, transform.position.z);
        }

        allCoords[allCoords_counter] = coord;
        allCoords_counter++;
        Instantiate(_healthPotion, coord, Quaternion.identity);
      }

      for (int i = 0; i < _noOfDebuffs; i++)
      {
        float x = UnityEngine.Random.Range(_lowerX, _upperX);
        float y = UnityEngine.Random.Range(_lowerY, _upperY);
        Vector3 coord = new Vector3(x, y, transform.position.z);

        while(Array.Exists(allCoords, x => x == coord))
        {
          x = UnityEngine.Random.Range(_lowerX, _upperX);
          y = UnityEngine.Random.Range(_lowerY, _upperY);
          coord = new Vector3(x, y, transform.position.z);
        }

        allCoords[allCoords_counter] = coord;
        allCoords_counter++;
        Instantiate(_debuff, coord, Quaternion.identity);
      }

      for (int i = 0; i < _noOfShield; i++)
      {
        float x = UnityEngine.Random.Range(_lowerX, _upperX);
        float y = UnityEngine.Random.Range(_lowerY, _upperY);
        Vector3 coord = new Vector3(x, y, transform.position.z);

        while(Array.Exists(allCoords, x => x == coord))
        {
          x = UnityEngine.Random.Range(_lowerX, _upperX);
          y = UnityEngine.Random.Range(_lowerY, _upperY);
          coord = new Vector3(x, y, transform.position.z);
        }

        allCoords[allCoords_counter] = coord;
        allCoords_counter++;
        Instantiate(_shield, coord, Quaternion.identity);
      }

      for (int i = 0; i < _noOfPortals; i++)
      {
        float x = UnityEngine.Random.Range(_lowerX, _upperX);
        float y = UnityEngine.Random.Range(_lowerY, _upperY);
        Vector3 coord = new Vector3(x, y, transform.position.z);

        while(Array.Exists(allCoords, x => x == coord))
        {
          x = UnityEngine.Random.Range(_lowerX, _upperX);
          y = UnityEngine.Random.Range(_lowerY, _upperY);
          coord = new Vector3(x, y, transform.position.z);
        }

        allCoords[allCoords_counter] = coord;
        allCoords_counter++;
        GameObject portalControl = Instantiate(_portalBuff, coord, Quaternion.identity) as GameObject;
      }

    }
}
