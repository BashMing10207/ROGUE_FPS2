using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamDino : EnemyBase
{
    [SerializeField]
    private int rand=5;
    public void Fire()
    {
        
    }
    public void RandomTrigger()
    {
        if (Random.Range(0, rand) < 2)
        {
            animator.SetTrigger("Rand");
        }
    }
}
