
using System.Collections.Generic;
using UnityEngine;

public enum BulletTypeMing
{
    Ball,
    Bullet,
    Rocket,
    Granade,
    Beam
}

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    public GameObject[] bullet;               //총알프리팹
    private GameObject[] _currentbullet = new GameObject[5];
    //private Stack<GameObject> _stack = new Stack<GameObject>();
    private Stack<GameObject>[] _stack  = {new Stack<GameObject>(), new Stack<GameObject>(), new Stack<GameObject>(), new Stack<GameObject>(), new Stack<GameObject>(), new Stack<GameObject>(), new Stack<GameObject>(), new Stack<GameObject>() }; // 여러종류의 총알 풀링할 때 사용밍
    private void Awake()
    {
        Instance = this;
    }

    public void CollectBullets(GameObject bullet,BulletTypeMing bulletType)
    {
        _stack[(int)bulletType].Push(bullet);                //총알 회수
        _stack[(int)bulletType].Peek().SetActive(false);
    }
    public void GiveBullets(Transform targetpos,BulletTypeMing bulletType)
    {
        
        if (!_stack[(int)bulletType].TryPop(out _currentbullet[(int)bulletType]))
        {
            _currentbullet[(int)bulletType] = Instantiate(bullet[(int)bulletType]);       //총알이 없으면 생성
        }

        _currentbullet[(int)bulletType].transform.SetPositionAndRotation(targetpos.position, targetpos.rotation);    //총알 보내주기
        _currentbullet[(int)bulletType].SetActive(true);
    }
}
