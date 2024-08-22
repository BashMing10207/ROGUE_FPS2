
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : Health
{
    public static int EnemyCount = 0;
    public NavMeshAgent agent;
    public LayerMask playerLayer;
    public float longDistance = 5f, shortDistance = 2f, speed = 5f,acel = 60,
        minDistance = 1f, SensDistance = 15f, attackingSpeed = 0.01f,angleSpeed=45f ,attackingAngleSpeed = 45,attackingMDis=0.1f;
    public bool isTracking = false;
    public Animator animator;
    internal float currentDis = 0;
    internal Vector3 targetTr;

    float _mindistance;
    public GameObject dieEffect;
    public AudioClip hitSound;
    public float AtSpeed;
    internal Transform _player;
    public bool isAttacking = false;

    public bool isSkinned = false;
    public SkinnedMeshRenderer boddy;
    public MeshRenderer bodyM;
    public EnemyTypes enemyTypes;
    public AudioClip SpawnSOund;
    private void OnEnable()
    {
        agent.Warp(transform.position);
        GameMana.instance.EnemyCount++;
    }
    private void Start()
    {
        agent.speed = speed;
        agent.angularSpeed = angleSpeed;
        _player = GameMana.instance.mov.transform;


        if(SpawnSOund != null )
        {
            SoundMana.Instance.AudPlay(SpawnSOund);
        }


    }

    public virtual void Attack()
    {
        Vector3 aa =_player.position - transform.position;
        //if(new Vector3(aa.x, 0, aa.z) != Vector3.up && new Vector3(aa.x, 0, aa.z) != Vector3.down)
        //transform.rotation =Quaternion.LookRotation(new Vector3(aa.x,0,aa.z),Vector3.up);
        animator.SetFloat("AtSpeed", AtSpeed);
        animator.SetBool("Attack",true);
    }
    public virtual void Moving()
    {
        agent.speed = speed;
        animator.SetBool("Attack", false);
    }

    public void BattleModeEnter()
    {
        animator.SetTrigger("BattleMode");
        isTracking = true;
    }

    public virtual void ToggleAttack()
    {
        isAttacking = !isAttacking;
        agent.speed = isAttacking == true ? attackingSpeed:speed;
        agent.angularSpeed = isAttacking == true ? attackingAngleSpeed : angleSpeed;
        _mindistance = isAttacking == true ? attackingMDis : minDistance;
    }

    public override void Damage(float damage, Vector3 dir, float power)
    {
        agent.acceleration = 0;
        agent.velocity += dir* power;
        Invoke(nameof(ReAcel),0.8f);
        Damage(damage);
    }

    void ReAcel()
    {
        agent.acceleration = acel;
    }
    public virtual void FixedUpdate()
    {
        currentDis = Vector3.Distance(transform.position, _player.position);

        if(isTracking)
        {
            targetTr = _player.position + ((transform.position -_player.position).normalized*_mindistance);

            agent.SetDestination(targetTr);

            if(transform.InverseTransformDirection(targetTr).z>0)
            if (Scat()&&(longDistance > currentDis))
            {
               Attack();
            }
            else
            {   
               Moving();
            }
        }
        else
        {
            if (currentDis < SensDistance)
            {
                if (Scat())
                {
                    BattleModeEnter();
                }
            }
        }
    }

    public bool Scat()
    {
        return !Physics.Raycast(transform.position, _player.position - transform.position, currentDis + 0.1f, ~playerLayer);
    }

    public override void Die()
    {
        Instantiate(dieEffect, transform.position, transform.rotation);
        ParticleSystem.ShapeModule ming = GameMana.instance.par.shape;

        if (isSkinned)
        {
            ming.shapeType = ParticleSystemShapeType.SkinnedMeshRenderer;
            ming.meshShapeType = ParticleSystemMeshShapeType.Triangle;
            ming.skinnedMeshRenderer = boddy;
        }
        else
        {
            ming.shapeType = ParticleSystemShapeType.MeshRenderer;
            ming.meshShapeType = ParticleSystemMeshShapeType.Triangle;
            ming.meshRenderer = bodyM;
        }
        GameMana.instance.par.Play();
        --GameMana.instance.EnemyCount;
        if (GameMana.instance.EnemyCount < 1)
        {
            GameMana.instance.EnemyCount = 0;
            GameMana.instance.stg.Change();
        }

        GameMana.instance.enPool.Get(enemyTypes, gameObject);
    }

   
    //public override void Hit()
    //{
    //    audioSource.PlayOneShot(hitSound, Random.Range(0.6f, 0.8f));   
    //}
}
