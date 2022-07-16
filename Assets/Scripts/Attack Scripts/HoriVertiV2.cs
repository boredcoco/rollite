using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoriVertiV2 : MonoBehaviour
{
    [SerializeField] private float activeTime = 5f;
    private Bullet bulletscript;
    private Animator anim;

    private float timer;

    private void Start()
    {
        bulletscript = GetComponent<Bullet>();
        anim = GetComponent<Animator>();
        bulletscript.enabled = false;
        timer = activeTime;
    }

    private void Update()
    {
        if (timer <= 0)
        {
          timer = activeTime;
          bulletscript.enabled = true;
          anim.SetBool("activeBullet", true);
        } else
        {
          timer -= Time.deltaTime;
        }
    }

    private void OnDisable()
    {
      bulletscript.enabled = false;
    }
}
