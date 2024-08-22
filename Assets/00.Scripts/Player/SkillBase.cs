using UnityEngine;

public struct SkillData
{
    public SkillData(ActionType actionTp,Transform tr, float val)
    {
        actionType = actionTp;
        trm = tr;
        value = val;

    }
    public ActionType actionType;
    public Transform trm;
    public float value;
}
public abstract class SkillBase : MonoBehaviour//, ISkillMing
{
    public SkillType skType;
    //public SkillSO skillSO;
    public void Start()
    {
        print("anal jelly smo");
        GameMana.instance.skill.skillAction[(int)skType]+=SkillMing;
    }
    public abstract void SkillMing(SkillData skillData);
}
