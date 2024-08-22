using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bill : MonoBehaviour
{
    void LateUpdate()
    {
        transform.rotation = GameMana.instance.maincam.transform.rotation;
    }
}
