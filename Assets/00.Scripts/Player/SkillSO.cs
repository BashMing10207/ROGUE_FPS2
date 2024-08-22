using System;
using UnityEngine;

public enum SkillType
{
 Heal,
 Weapon,
 Shield,
 Bomb,
 Jump,
 SpeedUp,
 Projectile,
 Thunder,
 Fire,
 KnockBack,
 Stop,
 Respawn,
 Power,
 Boom,
 Attack,
 Last
}
public enum PSkillType
{
    Hp,
    Ammo,
    Atsp,
    Speed,
    NotePlus,
    BPM,
    SLIDE,
    WPPlus
}

[CreateAssetMenu(fileName ="SKILLSOSO",menuName ="CUm")]
public class SkillSO : ScriptableObject
{
    public ActionType actionType;
    public SkillType skillType;
    public bool isPassiveSKill = false,isActiveSkill;
    public PSkillType passiveSkillType;
    public float[] value;

    [Multiline(7)]
    public String des, tit;
    public Texture2D icon;
    [ColorUsage(true, true)]
    public Color color;
    public Action ming;

    public bool iscanLvUp = false;

    public void ActionAdd(ref Action action)
    {
        action += ming;
    }

    
}
