using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionLerp : MonoBehaviour
{
    [SerializeField]
    Transform target, source;
    [SerializeField]
    float speed;
    void Update()
    {
        target.rotation = Quaternion.Slerp(target.rotation, source.rotation,Time.deltaTime*speed);
    }
}
