using UnityEngine;
[CreateAssetMenu(menuName = "Battle/EnemyData/EnemySetting")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int maxHp;
    public int attackPower;
    public int defensePower;
    public EnemySkillData[] enemySkillDatas;
}
