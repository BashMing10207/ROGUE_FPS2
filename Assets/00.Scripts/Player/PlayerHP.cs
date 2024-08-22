using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : Health
{
    public Image HpBar;
    public TextMeshPro txt;
    public AudioClip dieSOund,HealSOund;
    public GameObject DIeWIn;
public bool fuckming = false;

    public override void Awake()
    {
        if(!fuckming)
        {
            _hp = _maxHp;
        }
    }
    private void Start()
    {
        GameMana.instance.playerHP = this;
        HpBar.fillAmount = _hp / _maxHp;
        txt.text = (_hp / _maxHp*100).ToString()+"%";
    }
    public override void Damage(float damage)
    {
        base.Damage(damage);
        HpBar.fillAmount = _hp/_maxHp;
        txt.text = ((int)(_hp / _maxHp * 100)).ToString() + "%";
        if(damage < 0)
        {
            SoundMana.Instance.AudPlay(HealSOund);
        }
    }
    public override void Damage(float damage, Vector3 dir, float power)
    {
        GameMana.instance.mov.rb.AddForce(dir * power,ForceMode.Impulse);
        Damage(damage/3);
    }
    public override void Die()
    {
        print("die");
        SoundMana.Instance.AudPlay(dieSOund);
        Time.timeScale = 0.01f;
        DIeWIn.SetActive(true);
    }
}
