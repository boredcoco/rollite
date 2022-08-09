using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTimer : MonoBehaviour
{

    [SerializeField] private float _timelag = 5f;
    private float timer;

    private void Start()
    {
        timer = _timelag;
    }

    private void Update()
    {
        if (timer > 0)
        {
          timer -= Time.deltaTime;
        }
    }

    public bool canfire()
    {
      return timer <= 0;
    }

    public void resetTimer()
    {
      timer = _timelag;
    }
}
