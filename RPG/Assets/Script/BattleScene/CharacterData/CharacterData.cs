using UnityEngine;

public abstract  class CharacterData : ScriptableObject//全部のキャラの基底クラス(ステータス)
{
    public string characterName;
    public int maxHp;
    public int attackPower;
    public int defensePower;
}
