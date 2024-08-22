using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASkillActive : SkillBase
{
    //
    public override void SkillMing(SkillData skillData)
    {
        if (skType == SkillType.Weapon)
        {
            GameMana.instance.rightHand.isWpChangeAble = false;
            int a = Random.Range(0, 4);
            //while (GameMana.instance.rightHand.GUnActived[a])
            {
                GameMana.instance.rightHand.wpnum = a;
                GameMana.instance.rightHand.Initming();
            }
            
        }
    }
    
}
