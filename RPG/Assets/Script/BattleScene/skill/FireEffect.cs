using UnityEngine;
[CreateAssetMenu(menuName = "Battle/Effects/Fire")]
public class FireEffect : SkillEffect
{
    public int damage;
    public int turns;

    public override void Execute(BattleCharacter target)
    {
        // ‰Šã‚ğ•t—^‚·‚éˆ—
        target.AddFire(damage, turns);
    }
}