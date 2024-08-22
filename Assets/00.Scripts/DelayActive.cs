using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayActive : MonoBehaviour
{
    public GameObject target;
    public float delayTime = 5;
    private void Awake()
    {
        Invoke(nameof(ALD), delayTime);
    }

    void ALD()
    {
        target.SetActive(true);
    }
}
