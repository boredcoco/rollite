using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    [SerializeField] private float popUpTime = 0.1f;

    private float timer;

    private void Start()
    {
      timer = popUpTime;
    }

    private void Update()
    {
      if (timer <= 0f)
      {
        gameObject.SetActive(false);
      } else
      {
        timer -= Time.deltaTime;
      }
    }

    private void OnEnable()
    {
      timer = popUpTime;
    }
}
