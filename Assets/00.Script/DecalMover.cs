using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DecalMover : MonoBehaviour
{
    public DecalProjector decal;
    public float maxsize = 100, speed = 10,stsize=1.6f,mul =1;
    [SerializeField]
    float _cursize=0;
    public int num=0;
    // Update is called once per frame
    void FixedUpdate()
    {
        //_cursize += Time.fixedDeltaTime*speed; //Mathf.Lerp(_cursize, maxsize, 0.1f);

        //if (_cursize > maxsize-1f || _cursize <0)
        //    speed *=-1;
        _cursize = GameMana.instance.songMana.power[num] * 10*mul;

        decal.size = Vector3.one * _cursize + Vector3.forward * 500;
    }
}
