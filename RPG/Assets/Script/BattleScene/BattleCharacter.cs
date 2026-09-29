using UnityEngine;
public class BattleCharacter : MonoBehaviour//全部のキャラの基底クラス(動きとか)
{
    [SerializeField] protected CharacterData  characterData;
    [SerializeField] private BattleEventManager battleEventManager;
    [SerializeField] private HealthGauge healthGauge;

    [SerializeField] protected int maxHP = 100;
    private int currentHP;
    public int CurrentHP => currentHP;
    public int MaxHP => maxHP;

    private void Start()
    {
        currentHP = maxHP;
    }

    //Damageを与えるではなく、TakeDamageでダメージを受ける処理
    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP < 0)
            currentHP = 0;

        healthGauge.SetGauge((float)currentHP / maxHP);

        battleEventManager.CombatLog.OnNext("ダメージ：" + damage);
        battleEventManager.CombatLog.OnNext("残りHP：" + currentHP);

    }

    //炎上状態異常を付与したときの処理
    public void AddFire(int damage, int turns)
    {
        battleEventManager.CombatLog.OnNext($"炎上を付与！ ダメージ:{damage} ターン:{turns}");
    }
}
