using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGColour : MonoBehaviour
{
    public static Color background = new Color(0.6992524f, 0.8516356f, 0.8679245f, 1);
    private Camera cam;


    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    private void Update()
    {
        cam.backgroundColor = background;
    }
}
