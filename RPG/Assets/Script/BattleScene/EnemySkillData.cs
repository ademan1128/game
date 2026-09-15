using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Enemy/Skill")]
public class EnemySkillData : ScriptableObject
{
        public skillType type;
        public string skillName;
        public int damage;

        public SkillEffect[] effects;

}
