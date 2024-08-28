using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Transform camera;
    private void Awake()
    {
        camera = Camera.main.transform;
    }
    void LateUpdate()
    {
        transform.rotation = camera.rotation;
    }
}
