using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private float _lowerX = -7f;
    [SerializeField] private float _upperX = 9f;
    [SerializeField] private float _lowerY = -4f;
    [SerializeField] private float _upperY = 4f;

    private Hashtable obs_positions = new Hashtable();
    private int obs_number;

    private string orientation = "random";

    private void Start()
    {
        obs_number = MapSettings.obsNum;
        orientation = MapSettings.obs_orientation;

        if (orientation == "random") generateRandom(obs_number);
        if (orientation == "horizontal") generateHori(obs_number);
        if (orientation == "vertical") generateVerti(obs_number);
    }

    private void generateRandom(int n)
    {
      for (int i = 0; i < n; i++)
      {
        int x = (int) Random.Range(_lowerX, _upperX);
        int y = (int) Random.Range(_lowerY, _upperY);

        Vector2 coords = new Vector2(x, y);
        if (!obs_positions.Contains(coords)) obs_positions.Add(coords, true);

        Instantiate(prefab, (Vector3) coords, Quaternion.identity);
      }
    }

    private void generateHori(int n)
    {
      int y = (int) Random.Range(_lowerY, _upperY);
      for (int i = -2; i < n - 2; i++)
      {
        int x = i;

        Vector2 coords = new Vector2(x, y);
        if (!obs_positions.Contains(coords)) obs_positions.Add(coords, true);

        Instantiate(prefab, (Vector3) coords, Quaternion.identity);
      }
    }

    private void generateVerti(int n)
    {
      int x = (int) Random.Range(_lowerY, _upperY);
      for (int i = -2; i < n - 2; i++)
      {
        int y = i;

        Vector2 coords = new Vector2(x, y);
        if (!obs_positions.Contains(coords)) obs_positions.Add(coords, true);

        Instantiate(prefab, (Vector3) coords, Quaternion.identity);
      }
    }

    public bool isObstacle(int x, int y)
    {
      return obs_positions.Contains(new Vector2(x, y));
    }


}