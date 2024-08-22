using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BRBOX : Health
{
    public UnityEvent UEV;


    public override void Die()
    {
       UEV.Invoke();
        Destroy(gameObject);
    }
}
