using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower02 : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed = 45;
    void LateUpdate()
    {
        transform.SetPositionAndRotation(target.position, Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * speed));
    }
}
