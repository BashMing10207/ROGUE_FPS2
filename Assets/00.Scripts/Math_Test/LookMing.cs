using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMing : MonoBehaviour
{
    public Transform target;
    public float speed,angleLimit=45,multi =1;
    public Transform firepos;
    public BulletTypeMing btty;
    float times=0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 targetDir = (target.position - transform.position).normalized;
        transform.rotation = SuperRotateMing(Vector3.forward, targetDir);
        //if (angleLimit < Mathf.Acos(Vector3.Dot(transform.forward, targetDir)) * Mathf.Rad2Deg)//นึ?
        //{
        //    transform.rotation = SuperRotateMing(Vector3.forward, targetDir);

        //    if (times < 0)
        //    {
        //        times = speed;

        //        for(int i = 0; i < multi; i++)
        //        {
        //            firepos.forward = transform.forward;
        //            BulletPool.Instance.GiveBullets(firepos, btty);
        //        }
        //    }

        //    times -= Time.fixedDeltaTime;
        //}
    }

    Quaternion SuperRotateMing(Vector3 fromDir,Vector3 targetDir)
    {
        float betweenDegr = Mathf.Acos(Vector3.Dot(fromDir, targetDir)) * Mathf.Rad2Deg;
        Vector3 betweenDir = Vector3.Cross(fromDir, targetDir);
        print(betweenDegr);
        return Quaternion.AngleAxis(betweenDegr,betweenDir);
    }
}
