using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    ProjectileType _bulletType;
    [SerializeField]
    protected float _speed = 0.1f,_radius=0.2f,_damage=1; // �ӵ�,�Ѿ� ������, ���ط�
    [SerializeField]
    protected float _maxTime; //�ִ� LifeTime (���� �� �� �ð��� ������ �Ѿ� �����)
    protected float _time;
    [SerializeField]
    LayerMask _layerMask;
    [SerializeField]
    TrailRenderer _trailRenderer; //Ǯ���� �� �Ѿ��� Ʈ������ �Ⱬ�ϰ� �Ǵ� ���� �����ϰ��� �־������.
    protected RaycastHit _hit;

    public virtual void  Init()
    {
        _time = 0; // �Ѿ� LifeTime �ʱ�ȭ
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
        transform.position += transform.forward * _speed; //�Ѿ� �̵�(���̷� �� ������ ������ �̵�)
        _time += Time.fixedDeltaTime;

        if (_time >= _maxTime)
        {
            //GameMana.instance.pool.Get(bulletType, gameObject); // �Ѿ� Ǯ���ϱ�
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

            //GameMana.instance.pool.Get(bulletType, gameObject); // �Ѿ� Ǯ�� ���ֱ� ����
        }
    }
}
