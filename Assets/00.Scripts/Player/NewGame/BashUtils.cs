using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BashUtils : MonoBehaviour
{
    public static Vector3 V2toV3(Vector2 v)
    {
        return new Vector3(v.x, 0, v.y);
    }
    public static Vector3 V3X0Z(Vector3 v)
    {
        return new Vector3(v.x, 0, v.z);
    }
}
