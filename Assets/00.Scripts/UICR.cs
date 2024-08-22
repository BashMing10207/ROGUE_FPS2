using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICR : MonoBehaviour
{
    [SerializeField]
    Transform[] points;

    private void Awake()
    {
        GameMana.instance.uicr = this;
    }

    public void Create(int tp)
    {
        GameMana.instance.pool.Give(ProjectileType.Right + tp, points[tp]).GetComponent<UIMVC>().Pos = points[tp].position;
    }
}
