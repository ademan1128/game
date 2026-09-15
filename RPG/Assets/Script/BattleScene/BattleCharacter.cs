using UnityEngine;
public class BattleCharacter : MonoBehaviour
{
    [SerializeField] private int maxHP = 100;

    private int currentHP;

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

        Debug.Log("ダメージ：" + damage);
        Debug.Log("残りHP：" + currentHP);
    }

    //炎上状態異常を付与したときの処理
    public void AddFire(int damage, int turns)
    {
        Debug.Log($"炎上を付与！ ダメージ:{damage} ターン:{turns}");
    }
}
