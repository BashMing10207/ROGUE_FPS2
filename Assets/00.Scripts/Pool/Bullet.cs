using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    ProjectileType _bulletType;
    [SerializeField]
    protected float _speed = 0.1f,_radius=0.2f,_damage=1; // 속도,총알 반지름, 피해량
    [SerializeField]
    protected float _maxTime; //최대 LifeTime (생성 후 이 시간이 지나면 총알 사라짐)
    protected float _time;
    [SerializeField]
    LayerMask _layerMask;
    [SerializeField]
    TrailRenderer _trailRenderer; //풀링할 때 총알의 트레일이 기괴하게 되는 것을 방지하고자 넣어놓았음.
    protected RaycastHit _hit;

    public virtual void  Init()
    {
        _time = 0; // 총알 LifeTime 초기화
        Move();
        _trailRenderer.Clear();
        Move();
    }

    public virtual void OnDisable()
    {
        _trailRenderer.Clear();
    }

    public virtual void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        Scan();
        transform.position += transform.forward * _speed; //총알 이동(레이로 쏜 궤적에 없으면 이동)
        _time += Time.fixedDeltaTime;

        if (_time >= _maxTime)
        {
            //GameMana.instance.pool.Get(bulletType, gameObject); // 총알 풀링하기
        }
    }
    protected void Scan()
    {
        if (Physics.SphereCast(transform.position, _radius, transform.forward, out _hit, _speed, _layerMask, QueryTriggerInteraction.Collide))
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
                    hpsdf.Damage(_damage * 2);
                }
                else
                {
                    hpsdf.Damage(_damage);
                }
            }

            //GameMana.instance.pool.Get(bulletType, gameObject); // 총알 풀링 해주기 ㅎㅎ
        }
    }
}
