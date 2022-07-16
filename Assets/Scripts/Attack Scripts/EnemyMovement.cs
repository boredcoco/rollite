using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private AIPath aipath;
    private Rigidbody2D rb;

    private void Start()
    {
      aipath = GetComponent<AIPath>();
      rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Quit.quitting)
        {
          aipath.canMove = false;
          aipath.canSearch = false;
          rb.velocity = new Vector2(0, 0);
        } else
        {
          aipath.canMove = true;
          aipath.canSearch = true;
        }
    }
}
