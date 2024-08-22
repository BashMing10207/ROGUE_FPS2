using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJBreak : Health
{
    public AudioClip ming;
    public GameObject mingObject;
    public override void Die()
    {
       Instantiate(mingObject,transform.position,transform.rotation);
        SoundMana.Instance.AudPlay(ming);
        Destroy(gameObject);
    }
}
