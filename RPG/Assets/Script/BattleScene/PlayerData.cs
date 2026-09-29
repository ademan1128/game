using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/PlayerData/PlayerSetting")]
public class PlayerData : CharacterData//プレイヤーの基底
{
    [Header("初期所持スキル")]
    [SerializeField]public List<SkillData> startSkills = new List<SkillData>();

}
