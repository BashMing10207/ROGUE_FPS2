using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEV : MonoBehaviour
{
    public UnityEvent EVEV;

    private void OnTriggerEnter(Collider other)
    {
        EVEV.Invoke();
    }
}
