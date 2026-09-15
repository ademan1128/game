using System.Collections.Generic;
using UnityEngine;

public class EnemyManeger : MonoBehaviour
{
    [Header("‚·‚×‚Ä‚Ì“G‚ÌƒXƒLƒ‹")]
    [SerializeField]
    private List<EnemySkillData> allSkills = new List<EnemySkillData>();

    public List<EnemySkillData> ALLSkill => allSkills;
}
