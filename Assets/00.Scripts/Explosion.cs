using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioClip sound;
    public float size = 2,damage=2,power =2,vol=0.5f;
    public LayerMask la;
    Stack<Health> tmpH = new Stack<Health>();
    void Start()
    {
        SoundMana.Instance.AudPlay(sound,vol);        
    }

    Collider[] colliders = new Collider[10];

    void FixedUpdate()
    {
        int n = Physics.OverlapSphereNonAlloc(transform.position, size, colliders, la);
        if (n > 0)
        {
            for(int i=0; i < n; i++)
            {
                if (colliders[i].CompareTag("Hitable"))
                {
                    Transform Cum = colliders[i].transform;
                    Health hpsdf;

                    while (!Cum.TryGetComponent<Health>(out hpsdf))
                    {
                        Cum = Cum.parent;
                    }
                    if (!tmpH.Contains(hpsdf))
                    {
                        tmpH.Push(hpsdf);
                        hpsdf.Damage(damage,(Cum.position - transform.position).normalized+Vector3.up/2,power);
                    }
                    
                }
            }
        }
    }
}
