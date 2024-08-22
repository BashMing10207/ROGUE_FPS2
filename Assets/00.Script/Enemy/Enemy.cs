using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health
{
    public static int EnemyCount = 0;

    public Rigidbody ri;
    [SerializeField] internal float speed,damage,distance=0;
    [SerializeField] private GameObject _enemyDieEffect;
    public virtual void Start()
    {
        GameMana.instance.EnemyMov[0] += this.EnemyMove;
    }

    public virtual void OnEnable()
    {
        EnemyCount ++;

    }

    public virtual void OnDisable()
    {
        EnemyCount --;
        GameMana.instance.EnemyMov[0] -= this.EnemyMove;
    }
    
    public virtual void EnemyMove()
    {
        Vector3 direction = (GameMana.instance.mov.transform.position - transform.position);
        if(Vector3.Distance(GameMana.instance.mov.transform.position,transform.position) < distance)
        direction *= -2;

       // GameMana.instance.movement.Dash(direction, 1.5f,ref ri);
    }

    void FixedUpdate()
    {
        
    }
    public override void Damage(float damage, Vector3 dir, float power)
    {
        //GameMana.Instance.movement.Dash(dir, 1.5f, ref ri);
        base.Damage(damage, dir, power);
    }
    public override void Die()
    {
        Instantiate(_enemyDieEffect,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
