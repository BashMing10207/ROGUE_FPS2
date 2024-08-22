using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBomb : SkillBase
{
    public GameObject Boom;
    public override void SkillMing(SkillData skillData)
    {
        Instantiate(Boom, skillData.trm.position, skillData.trm.rotation);
    }
}