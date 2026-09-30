using UnityEngine;
public enum BattleResult
{
    Win,
    Lose,
    Draw
}

public class SkillCompatibility : MonoBehaviour
{
    [SerializeField] public SkillManager skillManager;
    public BattleResult CheckSkillType(SkillData playerSkill, EnemySkillData enemySkill)
    {
        skillType playerType = playerSkill.type;
        skillType enemyType = enemySkill.type;

        // Power ‚Í Technique ‚ÉŸ‚Â
        if (playerType == skillType.Power &&
            enemyType == skillType.Technique)
        {
            return BattleResult.Win;
        }

        // Technique ‚Í Speed ‚ÉŸ‚Â
        if (playerType == skillType.Technique &&
            enemyType == skillType.Speed)
        {
            return BattleResult.Win;
        }

        // Speed ‚Í Power ‚ÉŸ‚Â
        if (playerType == skillType.Speed &&
            enemyType == skillType.Power)
        {
            return BattleResult.Win;
        }

        // ‹t‚Ìê‡‚Í•‰‚¯
        if (playerType == skillType.Power &&
            enemyType == skillType.Speed)
        {
            return BattleResult.Lose;
        }

        if (playerType == skillType.Technique &&
            enemyType == skillType.Power)
        {
            return BattleResult.Lose;
        }

        if (playerType == skillType.Speed &&
            enemyType == skillType.Technique)
        {
            return BattleResult.Lose;
        }

        // “¯‚¶ƒ^ƒCƒv
        return BattleResult.Draw;
    }


}
