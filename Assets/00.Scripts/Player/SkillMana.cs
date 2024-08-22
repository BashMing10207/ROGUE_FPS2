using System;
using UnityEngine;
using UnityEngine.Events;

public enum Skillid
{

}

public enum PassiveSkillid
{

}

public enum AddWpEn
{

}

public enum ActionType
{   
    Jump,
    Dash,
    Hit,
    Attack,
    Perfact,
    Destroy,
    Reload,
    Swap,
    Catch,
    Die,
    Last
}

public class SkillMana : MonoBehaviour
{

    public UnityEvent <SkillData>[] originAction = new UnityEvent<SkillData>[(int)ActionType.Last];
    public UnityAction <SkillData>[] skillAction = new UnityAction<SkillData>[(int)SkillType.Last];
    public int[,] skillLevel = new int[(int)ActionType.Last,(int)SkillType.Last];



    private void Awake()
    {
        GameMana.instance.skill = this;
        #region ¾ÏÈæ
        //skillAction[0] += Heal;
        //skillAction[1] += Weapon;
        //skillAction[2] += Shield;
        //skillAction[3] += Bomb;
        //skillAction[4] += Jump;
        //skillAction[5] += SpeedUp;
        //skillAction[6] += Projectile;
        //skillAction[7] += Thunder;
        //skillAction[8] += Fire;
        //skillAction[9] += KnuckBack;
        //skillAction[10] += Stop;
        //skillAction[11] += Respawn;

        #endregion
       
    }

    public void AddSkill(SkillSO skillso)
    {
        if (skillso.isActiveSkill)
        {
            if (skillLevel[(int)skillso.actionType, (int)skillso.skillType] < 1)
            {
                originAction[(int)skillso.actionType].AddListener(skillAction[(int)skillso.skillType]);
            }
            if (skillso.iscanLvUp)
                skillLevel[(int)skillso.actionType, (int)skillso.skillType]++;
        }
        if(skillso.isPassiveSKill)
        {
            switch (skillso.passiveSkillType)
            {
                case PSkillType.Hp:
                    GameMana.instance.playerHP._maxHp += skillso.value[0];
                    
                    break;
                case PSkillType.Ammo:
                    GameMana.instance.playerHP.Damage(-1, skillso.value[0]);
                    break;
                case PSkillType.Atsp:
                    GameMana.instance.AttackSpeedMulti += skillso.value[0];
                    GameMana.instance.songMana.BPM += skillso.value[1];
                    break;
                case PSkillType.Speed:
                    GameMana.instance.mov.maxspeed += skillso.value[0];
                    GameMana.instance.songMana.BPM += skillso.value[1];
                    break;
                case PSkillType.NotePlus:
                    if (GameMana.instance.songMana.indexY < 5)
                    {
                    GameMana.instance.songMana.indexY += 1;
                    GameMana.instance.noteCount += 8;
                    GameMana.instance.songMana.BPM += 5;
                    }
                    else
                    {
                        GameMana.instance.noteCount += 12;
                        GameMana.instance.songMana.BPM += 35;
                    }
                    break;
                case PSkillType.BPM:
                    GameMana.instance.songMana.BPM += skillso.value[0];
                    GameMana.instance.noteCount += (int)skillso.value[1];
                    GameMana.instance.songMana.indexX += (int)skillso.value[2];
                    break;
                case PSkillType.SLIDE:
                    GameMana.instance.mov.SLBPMMULTI += 1f;
                    break;
                case PSkillType.WPPlus:
                    GameMana.instance.rightHand.GUnActived[(int)skillso.value[0]] = true;
                    GameMana.instance.noteCount += 3;
                    GameMana.instance.songMana.BPM += 8;
                    break;
            }
        }
    }
}