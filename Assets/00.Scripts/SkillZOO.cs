using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SkillZOO : Health
{
    public SkillSO skillso;
    public SkillSO[] skillsos;

    public TextMeshProUGUI d, t;
    public RawImage rimg;
    public AudioClip breakSound;
    public GameObject breakEffect;


    private void OnEnable()
    {
        
        _hp = _maxHp;
        
        skillso = skillsos[Random.Range(0,skillsos.Length)];

        d.text = skillso.des;
        t.text = skillso.tit;
        Material mingMat = new Material(rimg.material);
        mingMat.SetTexture("_BaseMap", skillso.icon);
        mingMat.SetTexture("_EmissionMap", skillso.icon);
        mingMat.SetColor("_EmissionColor", skillso.color);
        rimg.material = mingMat;
    }
    public override void Die()
    {
        GameMana.instance.skill.AddSkill(skillso);
        SoundMana.Instance.AudPlay(breakSound);
        Instantiate(breakEffect,transform.position,transform.rotation);
        GameMana.instance.ToggleMusicMaker();
        transform.parent.gameObject.SetActive(false);
    }
}
