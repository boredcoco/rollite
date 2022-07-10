using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable_oneByOne : MonoBehaviour
{

  [SerializeField] private float _entryLagTime = 10f;
  [SerializeField] private float _lowerBoundTimer = 5f;
  [SerializeField] private float _upperBoundTimer = 10f;
  [SerializeField] private int _maxObjectsOnField = 3; // max objects on playing field at any given time

  [SerializeField] private float _lowerX = -10f;
  [SerializeField] private float _upperX = 20f;
  [SerializeField] private float _lowerY = -10f;
  [SerializeField] private float _upperY = 10f;

  [SerializeField] private GameObject _healthPotion;
  [SerializeField] private GameObject _debuff;
  [SerializeField] private GameObject _portalBuff;
  [SerializeField] private GameObject _shield;

  private GameObject[] storedHealthPotions;
  private int hp_index = 0;
  private GameObject[] storedDebuffs;
  private int db_index = 0;
  private GameObject[] storedPortals;
  private int por_index = 0;
  private GameObject[] storedShields;
  private int shield_index = 0;

  private int objectsOnField = 0;

  private float timer = 5f;

  private void Start()
  {
    timer = _entryLagTime;

    storedHealthPotions = new GameObject[_maxObjectsOnField];
    storedDebuffs = new GameObject[_maxObjectsOnField];
    storedPortals = new GameObject[_maxObjectsOnField];
    storedShields = new GameObject[_maxObjectsOnField];

  }

  private void Update()
  {
    if (objectsOnField <= 0)
    {
      if (timer <= 0 && !Quit.quitting)
      {
        spawn();
        timer = Random.Range(_lowerBoundTimer, _upperBoundTimer);
      } else
      {
        timer = timer - Time.deltaTime;
      }
    }
  }

  private void spawn()
  {
    int numToSpawn = Random.Range(1, _maxObjectsOnField + 1);

    for (int i = 0; i < numToSpawn; i++)
    {
      int type = (int) Random.Range(1, 5);
      if (type == 1) healthPotion();
      if (type == 2) debuff();
      if (type == 3) portals();
      if (type == 4) shields();
    }
    objectsOnField = numToSpawn;
  }

  private void general_instantiate(int index, GameObject prefab, GameObject[] arr)
  {
    float randX = Random.Range(_lowerX, _upperX);
    float randY = Random.Range(_lowerY, _upperY);
    Vector3 coord = new Vector3(randX, randY, transform.position.z);

    if (arr[index] != null) {
      arr[index].gameObject.transform.position = coord;
      arr[index].gameObject.SetActive(true);
    } else
    {
      arr[index] = Instantiate(prefab, coord, Quaternion.identity) as GameObject;
    }
  }

  private void healthPotion()
  {
    if (hp_index >= storedHealthPotions.Length) hp_index = 0;
    general_instantiate(hp_index, _healthPotion, storedHealthPotions);
    hp_index++;
  }

  private void debuff()
  {
    if (db_index >= storedDebuffs.Length) db_index = 0;
    general_instantiate(db_index, _debuff, storedDebuffs);
    db_index++;
  }

  private void portals()
  {
    if (por_index >= storedPortals.Length) por_index = 0;
    general_instantiate(por_index, _portalBuff, storedPortals);
    por_index++;
  }

  private void shields()
  {
    if (shield_index >= storedShields.Length) shield_index = 0;
    general_instantiate(shield_index, _shield, storedShields);
    shield_index++;
  }

  public void decreaseObjCount()
  {
    this.objectsOnField--;
  }

}
