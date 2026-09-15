using UnityEngine;

public enum skillType
{
    Power,
    Technique,
    Speed,
}

[CreateAssetMenu(menuName = "Battle/Skill")]
public class SkillData : ScriptableObject
{
    public skillType type;
    public string skillName;
    public int damage;

    public SkillEffect[] effects;

}

public abstract class SkillEffect : ScriptableObject
{
    public abstract void Execute(BattleCharacter target);
}