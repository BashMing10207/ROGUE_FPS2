using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    VerySmallBullet,
    SmallBullet,
    MiddleBullet,
    BigBullet,
    Blade1,
    Blade2,
    SmallRocket,
    BigRocket,
    Beam,
    BeamGunBeam,
    last
}

public class Pool : MonoSingleton<Pool>
{
    public Dictionary<ProjectileType,Stack<GameObject>> poolMing = new Dictionary<ProjectileType, Stack<GameObject>> ();

    public GameObject[] poolPrefs = new GameObject[(int)ProjectileType.last];

    private void Init()
    {
        //GameMana.instance.pool = this;
    }

    public void Get(ProjectileType prjtype,GameObject target)
    {
        Create(prjtype);
        poolMing[prjtype].Push(target);
        target.SetActive(false);
    }
    public GameObject Give(ProjectileType prjtype, Transform targetTr)
    {
        Create(prjtype);

        GameObject gameObject;

        if (!poolMing[prjtype].TryPeek(out gameObject))
        { 
            gameObject = Instantiate(poolPrefs[(int)prjtype], transform.position, transform.rotation, transform); 
        }
        else
        {
            poolMing[prjtype].Pop();
        }
        gameObject.transform.SetPositionAndRotation(targetTr.position, targetTr.rotation);
        gameObject.SetActive(true);
        return gameObject;
    }

    public GameObject Give(ProjectileType prjtype, Transform targetTr,float randomDeg)
    {
        Create(prjtype);

        GameObject gameObject;

        if (!poolMing[prjtype].TryPeek(out gameObject))
        {
            gameObject = Instantiate(poolPrefs[(int)prjtype], transform);
        }
        else
        {
            poolMing[prjtype].Pop();
        }
        gameObject.transform.SetPositionAndRotation(targetTr.position, targetTr.rotation);
        gameObject.transform.Rotate(Random.Range(-randomDeg, randomDeg),
            Random.Range(-randomDeg, randomDeg), Random.Range(-randomDeg, randomDeg));
        gameObject.SetActive(true);
        return gameObject;
    }

    public void Create(ProjectileType prjtype)
    {
        if (!poolMing.ContainsKey(prjtype))
        {
            poolMing[prjtype] = new Stack<GameObject>();
        }
    }

}
