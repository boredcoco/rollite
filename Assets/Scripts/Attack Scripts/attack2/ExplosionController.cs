using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] private GameObject _attack2;
    [SerializeField] private int _numOfBullets = 10;

    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lagTime = 0.1f;

    [SerializeField] private AudioSource canonSound;
    private bool playSound = true;

    private GameObject[] storedAttack2;
    private int pointer = 0;
    private float timer;

    private void Start()
    {
        timer = _lagTime;
        storedAttack2 = new GameObject[_numOfBullets];
    }

    private void Update()
    {
      if (gameObject.activeSelf)
      {
        if (timer <= 0)
        {
          if (playSound)
          {
            canonSound.Play();
            playSound = false;
          }
          if (pointer >= _numOfBullets)
          {
            gameObject.SetActive(false);
            pointer = 0;
            timer = _lagTime;
          } else
          {
            float fract = 2 * Mathf.PI * pointer / _numOfBullets;
            Vector2 vel = new Vector2(Mathf.Cos(fract) * _speed, Mathf.Sin(fract) * _speed);
            if (storedAttack2[pointer] != null)
            {
              storedAttack2[pointer].transform.position = transform.position;
              storedAttack2[pointer].SetActive(true);
              storedAttack2[pointer].GetComponent<Rigidbody2D>().velocity = vel;
            }
            else
            {
              storedAttack2[pointer] = Instantiate(_attack2, transform.position, Quaternion.identity) as GameObject;
              storedAttack2[pointer].GetComponent<Rigidbody2D>().velocity = vel;
            }
            pointer++;
          }
        } else
        {
          timer -= Time.deltaTime;
        }
      }
    }


}
