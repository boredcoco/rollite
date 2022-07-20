using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private AIPath aipath;

    private void Start()
    {
      aipath = GetComponent<AIPath>();
    }
    private void Update()
    {
        if (Quit.quitting)
        {
          aipath.canMove = false;
          aipath.canSearch = false;
        } else
        {
          aipath.canMove = true;
          aipath.canSearch = true;
        }
    }
}
