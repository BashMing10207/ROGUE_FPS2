using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : Bullet
{

    //public float speed = 0.1f, radius = 0.2f, damage = 1; // 속도,총알 반지름, 피해량
    //public LayerMask layerMask;
    [SerializeField]
   // public ProjectileType bulletType;
    public LineRenderer lineRenderer;
    Vector3[] points = new Vector3[2];


    public override void OnEnable()
    {
        _time = 0; // 총알 LifeTime 초기화
        HitScan();
    }

    void HitScan()
    {
            Transform ming = (Pls == true) ? GameMana.instance.maincam.transform : transform;

            Vector3 point = ming.position + ming.forward * 1024;
            if (Physics.SphereCast(ming.position, radius, ming.forward, out _hit, 1024, layerMask))
            {
                if (_hit.transform.gameObject.CompareTag("Hitable") || _hit.transform.gameObject.CompareTag("Head"))
                {
                    Transform Cum = _hit.transform.gameObject.transform;
                    Health hpsdf;

                    while (!Cum.TryGetComponent<Health>(out hpsdf))
                    {
                        Cum = Cum.parent;
                    }
                    if (_hit.transform.gameObject.CompareTag("Head"))
                    {
                        hpsdf.Damage(damage * 2);
                    }
                    else
                    {
                        hpsdf.Damage(damage);
                    }
                }
                point = _hit.point;
            }
            points[0] = transform.position;
            points[1] = point;

            lineRenderer.SetPositions(points);
    }

    public override void OnDisable()
    {
        
    }

    public override void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;

        if (_time >= _maxTime)
        {
            GameMana.instance.pool.Get(bulletType, gameObject); // 총알 풀링 ㄱ
        }
    }
}
