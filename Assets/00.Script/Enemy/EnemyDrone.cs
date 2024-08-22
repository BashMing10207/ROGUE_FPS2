using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : Enemy
{
    Vector3 ming;
    float deg;
    [SerializeField]
    private ProjectileType _type;
    public Transform tr;

    public override void OnEnable()
    {
        base.OnEnable();
        GameMana.instance.EnemyMov[1] += this.Attack;
    }

    public override void OnDisable() { base.OnDisable();
        GameMana.instance.EnemyMov[1] -= this.Attack;
    }

    private void Update()
    {
        ming = (GameMana.instance.mov.transform.position - transform.position).normalized;
        transform.forward = ming;
    }

    public void Attack()
    {
        GameMana.instance.pool.Give(_type, tr);
    }
}
