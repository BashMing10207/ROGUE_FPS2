using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLerp : MonoBehaviour
{
    [SerializeField]
    Transform target, source;
    [SerializeField]
    float speed;
    void Update()
    {
        target.position = source.position+ source.forward * 6;
    }
}
