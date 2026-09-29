using Cysharp.Threading.Tasks;
using UnityEngine;


public class EnemySkillManager : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private HealthGauge healthGauge;

    // 敵が今回のターンで選んだスキル
    private EnemySkillData selectedSkill;

    public EnemySkillData SelectedSkill => selectedSkill;


    public void SelectSkill()
    {
        EnemySkillData[] skills = enemy.Data.enemySkillDatas;

        if (skills == null || skills.Length == 0)
            return;
        selectedSkill = skills[Random.Range(0, skills.Length)];
    }

    public void ResetSkill()
    {
        selectedSkill = null;
    }

    public async UniTask EnemyUseCard(BattleCharacter target,EnemySkillData skill)
    {
        Debug.Log($"使用する技: {skill.skillName} ダメージ: {skill.damage}");
        target.TakeDamage(skill.damage);
        healthGauge.GaugeTakeDamage();
        foreach (SkillEffect effect in skill.effects)
        {
            effect.Execute(target);
        }


        await UniTask.Delay(500);
    }
}