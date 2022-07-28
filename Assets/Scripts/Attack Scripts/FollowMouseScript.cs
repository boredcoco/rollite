using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseScript : MonoBehaviour
{
    private void Start()
    {
      float x = Input.mousePosition.x;
      float y = Input.mousePosition.y;

      Vector3 coords = Camera.main.ScreenToWorldPoint(new Vector3(x, y, transform.position.z));
      coords.z = 0;

      transform.position = coords;
    }

    private void Update()
    {
      float x = Input.mousePosition.x;
      float y = Input.mousePosition.y;

      Vector3 coords = Camera.main.ScreenToWorldPoint(new Vector3(x, y, transform.position.z));
      coords.z = 0;

      transform.position = coords;
    }
}
