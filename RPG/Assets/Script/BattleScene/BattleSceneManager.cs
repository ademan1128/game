using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public enum BattleState
{
    Start,
    SelectTurn,
    JudgementTurn,
    PlayerTurn,
    EnemyTurn,
    PlayerAttackTurn,
    EnemyAttackTurn,
    DrawTurn,
    BattleEnd
}

public class BattleSceneManager : MonoBehaviour
{
    [SerializeField] private BattleComent battleComent;
    [SerializeField] private BattleEventManager battleEventManager;
    [SerializeField] private SkillManager skillManager;
    [SerializeField] private Enemy enemy;
    [SerializeField] private Player player;
    [SerializeField] private EnemySkillManager enemySkillManager;
    [SerializeField] private SkillCompatibility skillCompatibility;
    [SerializeField] private CardSpawner cardSpawner;

    private bool isUsingCards;

    public BattleState state;

    void Start()
    {
        state = BattleState.Start;
    }

    private void Update()
    {
        if (state == BattleState.Start)
        {
            skillManager.ResetSkill();
            skillManager.DrawSkill();
            skillManager.DrawSkill();
            skillManager.DrawSkill();
            skillManager.DrawSkill();
            skillManager.DrawSkill();
            cardSpawner.SpawnCards();

            enemySkillManager.SelectSkill();
            state = BattleState.SelectTurn;
            battleEventManager.CombatLog.OnNext("SelectTurnTurn");
        }
        else if (state == BattleState.SelectTurn)
        {
            if (Keyboard.current.zKey.wasPressedThisFrame)
            {
                skillManager.SelectSkill(0);

            }
            if (Keyboard.current.xKey.wasPressedThisFrame)
            {
                skillManager.SelectSkill(1);
            }
            if (Keyboard.current.cKey.wasPressedThisFrame)
            {
                skillManager.SelectSkill(2);
            }
            if (Keyboard.current.vKey.wasPressedThisFrame)
            {
                skillManager.CancelSkill(0);

            }
            if (Keyboard.current.bKey.wasPressedThisFrame)
            {
                skillManager.CancelSkill(1);

            }
            if (Keyboard.current.nKey.wasPressedThisFrame)
            {
                skillManager.CancelSkill(2);

            }
            // プレイヤーのターン
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                if (skillManager.SelectedSkill.Count > 0)
                {
                    state = BattleState.JudgementTurn;
                    battleEventManager.CombatLog.OnNext("JudgementTurn");
                }
                else
                {
                    battleEventManager.CombatLog.OnNext("技を選択してください");
                }
            }
        }
        else if (state == BattleState.JudgementTurn)
        {
            // 勝敗判定
            SkillData playerSkill = skillManager.SelectedSkill[0];
            EnemySkillData enemySkill = enemySkillManager.SelectedSkill;
            BattleResult result = skillCompatibility.CheckSkillType(playerSkill, enemySkill);

            if (result == BattleResult.Win)
            {
                battleEventManager.CombatLog.OnNext("プレイヤーの勝ち");
                battleEventManager.CombatLog.OnNext("Player's Turn");
                state = BattleState.PlayerTurn;
            }
            else if (result == BattleResult.Lose)
            {
                battleEventManager.CombatLog.OnNext("敵の勝ち");
                state = BattleState.EnemyTurn;
                battleEventManager.CombatLog.OnNext("Enemy's Turn");
            }
            else
            {
                battleEventManager.CombatLog.OnNext("引き分け");
                state = BattleState.DrawTurn;

            }
        }
        else if (state == BattleState.PlayerTurn)
        {
            // プレイヤーのターン
            if (!isUsingCards)
            {
                UsePlayerCards().Forget();
            }
        }
        else if (state == BattleState.EnemyTurn)
        {
            // 敵のターン
            if (!isUsingCards)
            {
                UseEnemyCard().Forget();
            }
        }
        else if (state == BattleState.DrawTurn)
        {
            // 引き分け
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                state = BattleState.Start;
                battleEventManager.CombatLog.OnNext("Reset");
            }
        }

        else if (state == BattleState.BattleEnd)
        {
            // バトル終了
        }
    }


    private async UniTask UsePlayerCards()
    {
        isUsingCards = true;
        await skillManager.UseCard(enemy);
        battleEventManager.CombatLog.OnNext("カード使用終了");
        isUsingCards = false;
        state = BattleState.Start;
    }

    private async UniTask UseEnemyCard()
    {
        isUsingCards = true;
        await enemySkillManager.EnemyUseCard(player, enemySkillManager.SelectedSkill);
        battleEventManager.CombatLog.OnNext("敵のカード使用終了");
        isUsingCards = false;
        state = BattleState.Start;
    }
}
