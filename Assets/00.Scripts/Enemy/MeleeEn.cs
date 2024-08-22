
using UnityEngine;

public class MeleeEn : EnemyBase
{
    public Transform shootPos;
    public LayerMask meleeatLayer;
    public int multipleEnemy = 2;
    public float damage = 1f,dashdis=10f;
    Vector3 dir;

    public void SetNav()
    {
        
    }

    public override void ToggleAttack()
    {
        dir = (GameMana.instance.mov.transform.position - transform.position).normalized;
        Vector3 aa = _player.position - transform.position;
        if (new Vector3(aa.x, 0, aa.z) != Vector3.up && new Vector3(aa.x, 0, aa.z) != Vector3.down)
            transform.rotation = Quaternion.LookRotation(new Vector3(aa.x, 0, aa.z), Vector3.up);
        base.ToggleAttack();
    }

    public override void FixedUpdate()
    {
        if(isAttacking)
        {
             agent.velocity = transform.forward * dashdis;
            Fire();
             //agent.velocity = Vector3.zero;
             //agent.SetDestination(transform.forward *dashdis);
        }
        else
        {
        base.FixedUpdate();
        }
    }
    public void Fire()
    {
        Collider[] other = new Collider[multipleEnemy]; 
        if(0 !=Physics.OverlapBoxNonAlloc(shootPos.position, shootPos.localScale / 2, other,shootPos.rotation,meleeatLayer))
        {
            for(int i =0; i <other.Length; i++)
            {
            if (other[i].gameObject.CompareTag("Hitable") || other[i].gameObject.CompareTag("Head"))
            {
                Transform Cum = other[i].gameObject.transform;
                Health hp;

                    //animator.SetTrigger("Ming");

                while (!Cum.TryGetComponent<Health>(out hp))
                {
                    Cum = Cum.parent;
                }
                if (other[i].gameObject.CompareTag("Head"))
                {
                    hp.Damage(damage * 2,0.4f);
                }
                else
                {
                    hp.Damage(damage,0.4f);
                }
            }
            }
        }
    }
}
