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
    [SerializeField] private SkillManager skillManager;
    [SerializeField] private Enemy enemy;
    [SerializeField] private SkillCompatibility skillCompatibility;


    public BattleState state;

    void Start()
    {
        state = BattleState.Start;
    }

    private void Update()
    {
        if (state == BattleState.Start)
        {
            skillManager.DrawSkill();
            skillManager.DrawSkill();
            skillManager.DrawSkill();
            skillManager.DrawSkill();
            skillManager.DrawSkill();
            state = BattleState.SelectTurn;
            Debug.Log("SelectTurnTurn");
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
                    Debug.Log("JudgementTurn");
                }
                else
                {
                    Debug.Log("技を選択してください");
                }
            }
        }
        else if (state == BattleState.JudgementTurn)
        {
            // 勝敗判定
            SkillData playerSkill = skillManager.SelectedSkill[0];
            EnemySkillData enemySkill =enemy.Data.enemySkillDatas[Random.Range(0, enemy.Data.enemySkillDatas.Length)];
            BattleResult result = skillCompatibility.CheckSkillType(playerSkill, enemySkill);

            if (result == BattleResult.Win)
            {
                Debug.Log("プレイヤーの勝ち");
                state = BattleState.PlayerTurn;
                Debug.Log("Player's Turn");
            }
            else if (result == BattleResult.Lose)
            {
                Debug.Log("敵の勝ち");
                state = BattleState.EnemyTurn;
                Debug.Log("Enemy's Turn");
            }
            else
            {
                Debug.Log("引き分け");
                state = BattleState.DrawTurn;

            }
        }
        else if (state == BattleState.PlayerTurn)
        {
            // プレイヤーのターン
            UsePlayerCards().Forget();
            state = BattleState.Start;
        }
        else if (state == BattleState.EnemyTurn)
        {
            // 敵のターン
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                state = BattleState.Start;
                Debug.Log("Reset");
            }
        }
        else if (state == BattleState.DrawTurn)
        {
            // 引き分け
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                state = BattleState.Start;
                Debug.Log("Reset");
            }
        }

        else if (state == BattleState.BattleEnd)
        {
            // バトル終了

        }
    }

    private async UniTask UsePlayerCards()
    {
        await skillManager.UseCard(enemy);

        Debug.Log("カード使用終了");
    }
}
