using UnityEngine;

public class Enemy : BattleCharacter
{
    [SerializeField] private EnemyData enemyData;

    public EnemyData Data => enemyData;
}