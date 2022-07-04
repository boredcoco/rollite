using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomExplosionSpawn : MonoBehaviour
{
    [SerializeField] private GameObject ExplosionController;
    [SerializeField] private int numOfExplosions = 5;

    [SerializeField] private float _lowerX = -7f;
    [SerializeField] private float _upperX = 10f;
    [SerializeField] private float _lowerY = -5f;
    [SerializeField] private float _upperY = 5f;

    private GameObject[] reusableExplosions;
    private int index = 0;

    private void Start()
    {
      reusableExplosions = new GameObject[numOfExplosions];
    }

    private void Update()
    {
      spawnExplosionController();
    }

    private void spawnExplosionController()
    {
      if (index >= numOfExplosions)
      {
        index = 0;
        gameObject.SetActive(false);
      }

      float x = Random.Range(_lowerX, _upperX);
      float y = Random.Range(_lowerY, _upperY);
      Vector3 coords = new Vector3(x, y, transform.position.z);

      if (reusableExplosions[index] == null)
      {
        reusableExplosions[index] = Instantiate(ExplosionController, coords, Quaternion.identity) as GameObject;
      } else
      {
        reusableExplosions[index].transform.position = coords;
        reusableExplosions[index].SetActive(true);
      }
      index++;
    }
}
