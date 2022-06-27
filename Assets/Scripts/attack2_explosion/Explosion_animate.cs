using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_animate : MonoBehaviour
{
    [SerializeField] private float _animSpeed = 1f;

    private Animator anim;

    private void Start()
    {
      anim = gameObject.GetComponent<Animator>();
      anim.SetFloat("speed", _animSpeed);
    }

}
