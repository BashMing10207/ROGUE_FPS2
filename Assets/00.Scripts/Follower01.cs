using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower01 : MonoBehaviour
{
    public Transform target;
    public Transform []targets;
    private void Awake()
    {
        
    }
    void Update()
    {
        if(target is not null)
            target.SetPositionAndRotation(transform.position, transform.rotation);
        //else
        //    for(int i = 0; i < targets.Length; i++)
        //    {
        //        targets[i].SetPositionAndRotation(transform.position, transform.rotation);
        //    }
    }
}
