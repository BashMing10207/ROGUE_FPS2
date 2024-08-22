using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : Health
{
    public float radius = 1;
    public LayerMask la;
    public Gun leftHand;
    public GunSO parryedAttack;
    public AudioClip parrysound;

    private void Start()
    {
        _maxHp = 0;
        _hp = 0;
    }

    public override void Damage(float damage)
    {
        leftHand.SetWP(gunsos);
        GameMana.instance.playerHP.Damage(-8, 0.5f);
        GameMana.instance.playerHP._hp += 25;
        SoundMana.Instance.AudPlay(parrysound);
    }
    public override void Damage(float damage, Vector3 dir, float power)
    {

    }
    public override void Damage(float damage, float cooldown)
    {

    }
    public override void Die()
    {
        
    }

    public void Update()
    {
        Collider[] other = new Collider[1];
        if (0 != Physics.OverlapBoxNonAlloc(transform.position, transform.lossyScale, other, transform.rotation, la))
        {
            for (int i = 0; i < other.Length; i++)
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
                    if(hp.gunsos != null)
                    {

                    leftHand.SetWP(hp.gunsos);
                    }

                    hp.Damage(99999);
                }
            }
        }
    }
}
