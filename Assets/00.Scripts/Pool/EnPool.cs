using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public enum EnemyTypes
{
    Drone1, Drone2, Drone3,
    Dino1, Dino2, Dino3,
    Man1, Man2, Man3,
    Gol1, Gol2, Gol3,
    last
}

public class EnPool : MonoBehaviour
{
    public Dictionary<EnemyTypes, Stack<GameObject>> poolMing = new Dictionary<EnemyTypes, Stack<GameObject>>();
    [Tooltip(" Drone1, Drone2, Drone3,\r\n    Dino1, Dino2, Dino3,\r\n    Man1, Man2, Man3,\r\n    Gol1, Gol2, Gol3,\r\n    last")]
    public GameObject[] poolPrefs = new GameObject[(int)EnemyTypes.last];

    private void OnEnable()
    {
        GameMana.instance.enPool = this;
    }

    public void Get(EnemyTypes prjtype, GameObject target)
    {
        Create(prjtype);
        poolMing[prjtype].Push(target);
        target.SetActive(false);
    }
    public GameObject Give(EnemyTypes prjtype, Transform targetTr)
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

    public GameObject Give(EnemyTypes prjtype,Vector3 pos) 
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
        gameObject.transform.position = pos;
        gameObject.GetComponent<NavMeshAgent>().Warp(pos);
        gameObject.SetActive(true);
        return gameObject;
    }

    

        public GameObject Give(EnemyTypes prjtype, Transform targetTr, float randomDeg)
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

    public void Create(EnemyTypes prjtype)
    {
        if (!poolMing.ContainsKey(prjtype))
        {
            poolMing[prjtype] = new Stack<GameObject>();
        }
    }

}
