
using UnityEngine;

public class AStatusSkill : SkillBase
{
    //회복 속도 방어 공격력
    public enum STSKILL
    {
        Heal = 0x00000001,
        Speed = 0x00000002,
        Shield = 0x00000003,
        AttackSp = 0x00000004,
        MaxHeal = 0x00000005,
    }

    public STSKILL STSkillTYPE;
    public float Value;


    public override void SkillMing(SkillData skillData)
    {
        if (GameMana.instance.songMana.power[2] > 0.1f)
        {

             if ((STSkillTYPE & STSKILL.Heal) == STSKILL.Heal)
             {
                 GameMana.instance.playerHP.Damage(-skillData.value);
             }
             if ((STSkillTYPE & STSKILL.Speed) == STSKILL.Speed)
             {
                 GameMana.instance.mov.speedMulti = Mathf.Lerp(GameMana.instance.mov.speedMulti, 3f, 0.4f);
                 GameMana.instance.mov.speedTime = skillData.value;
             }
             if ((STSkillTYPE & STSKILL.Shield) == STSKILL.Shield)
             {
                 GameMana.instance.playerHP.Damage(-1, 0.2f);
             }
             if ((STSkillTYPE & STSKILL.AttackSp) == STSKILL.AttackSp)
             {
                 GameMana.instance.AttackSpeed = Mathf.Lerp(GameMana.instance.AttackSpeed, 1.8f, 0.3f);
                 GameMana.instance.AttackTime = skillData.value;
             }
             if ((STSkillTYPE & STSKILL.MaxHeal) == STSKILL.MaxHeal)
             {

             }
             if (skType == SkillType.Stop)
             {
                 Time.timeScale = 0.01f;
                 Time.fixedDeltaTime = 0.002f;
                 Invoke(nameof(TimeSet), 0.009f);
             }
        }

    }

    void TimeSet()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }

    
}
