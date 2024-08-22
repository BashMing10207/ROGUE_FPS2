using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PStausUpSK : SkillBase
{
    public enum STSKILL
    {
        Heal = 0x00000001,
        Speed = 0x00000002,
        Shield = 0x00000003,
        AttackSp = 0x00000004,
        MaxHeal = 0x00000005,
        NoteCount,
        BPM
    }

    public STSKILL STSkillTYPE;
    public float Value;


    public override void SkillMing(SkillData skillData)
    {


        if ((STSkillTYPE & STSKILL.Heal) == STSKILL.Heal)
        {
            GameMana.instance.playerHP.Damage(-skillData.value);
        }
        if ((STSkillTYPE & STSKILL.Speed) == STSKILL.Speed)
        {
            GameMana.instance.mov.maxspeed += 4;
            GameMana.instance.songMana.BPM += 8;
        }
        if ((STSkillTYPE & STSKILL.Shield) == STSKILL.Shield)
        {
            //BPM

        }
        if ((STSkillTYPE & STSKILL.AttackSp) == STSKILL.AttackSp)
        {
            GameMana.instance.AttackSpeedMulti += 0.1f;
            GameMana.instance.songMana.BPM += 8;
        }
        if ((STSkillTYPE & STSKILL.MaxHeal) == STSKILL.MaxHeal)
        {
            GameMana.instance.playerHP._maxHp += 4f;
        }
        
    }


}
