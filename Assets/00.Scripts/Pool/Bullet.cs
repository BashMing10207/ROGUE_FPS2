using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 0.1f,radius=0.2f,damage=1; // 속도,총알 반지름, 피해량
    public LayerMask layerMask;
    [SerializeField]
    internal float _maxTime; //최대 LifeTime (생성 후 이 시간이 지나면 총알 사라짐)
    internal float _time;
    internal RaycastHit _hit;
    public ProjectileType bulletType;
    public TrailRenderer trailRenderer;
    public bool Pls = false;

    public virtual void  OnEnable()
    {
        _time = 0; // 총알 LifeTime 초기화
        Mov();
        trailRenderer.Clear();
        Mov();
    }

    public virtual void OnDisable()
    {
        trailRenderer.Clear();
    }

    public virtual void FixedUpdate()
    {
        Mov();
    }
    public void Mov()
    {
        if (Physics.SphereCast(transform.position, radius, transform.forward, out _hit, speed, layerMask,QueryTriggerInteraction.Collide))
        {
            if (_hit.transform.gameObject.CompareTag("Hitable") || _hit.transform.gameObject.CompareTag("Head"))
            {
                Transform Cum = _hit.transform.gameObject.transform;
                Health hpsdf;

                while (!Cum.TryGetComponent<Health>(out hpsdf))
                {
                    Cum = Cum.parent;
                }
                if (_hit.transform.gameObject.CompareTag("Head"))
                {
                    hpsdf.Damage(damage * 2);
                }
                else
                {
                    hpsdf.Damage(damage);
                }
            }

            GameMana.instance.pool.Get(bulletType, gameObject); // 총알 풀링 해주기 ㅎㅎ
        }
        transform.position += transform.forward * speed; //총알 이동(레이로 쏜 궤적에 없으면 이동)
        _time += Time.fixedDeltaTime;

        if (_time >= _maxTime)
        {
            GameMana.instance.pool.Get(bulletType, gameObject); // 총알 풀링 ㄱ
        }
    }
}
