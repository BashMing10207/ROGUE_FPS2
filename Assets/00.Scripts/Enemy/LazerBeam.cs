using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class LazerBeam : MonoBehaviour
{
    public float damage=4,radius;
    public LayerMask la;
    [SerializeField]
    // public ProjectileType bulletType;
    public LineRenderer attacker,postAttack;
    public bool isFire,isAiming;
    Transform ming;
    Transform Cum;
    Health hpsdf;
    public float tick = 0.05f;
    void LateUpdate()
    {

    RaycastHit hit;
        ming = transform;
        Vector3[] points = new Vector3[2];
        Vector3 point = ming.position + ming.forward * 1024;

        if(isFire)
        {
        if (Physics.SphereCast(ming.position, radius, ming.forward, out hit, 1024, la))
        {
            if (hit.transform.gameObject.CompareTag("Hitable") || hit.transform.gameObject.CompareTag("Head"))
            {
                Cum = hit.transform.gameObject.transform;

                while (!Cum.TryGetComponent<Health>(out hpsdf))
                {
                    Cum = Cum.parent;
                }
                if (hit.transform.gameObject.CompareTag("Head"))
                {
                    hpsdf.Damage(damage * 2,tick);
                }
                else
                {
                    hpsdf.Damage(damage,tick);
                }
            }
            point = hit.point;
        }
        points[0] = transform.position;
        points[1] = point;

        attacker.SetPositions(points);
        }
        if (isAiming)
        {
            if (Physics.SphereCast(ming.position, radius, ming.forward, out hit, 1024, la))
            {
                point = hit.point;
            }
            points[0] = transform.position;
            points[1] = point;

            postAttack.SetPositions(points);
        }
    }

}
