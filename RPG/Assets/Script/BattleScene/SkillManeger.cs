using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillManager : MonoBehaviour
{
    [Header("すべてのスキル")]
    [SerializeField]
    private List<SkillData> allSkills = new List<SkillData>();

    [Header("初期所持スキル")]
    [SerializeField]
    private List<SkillData> startSkills = new List<SkillData>();

    [Header("プレイヤーが所持しているスキル")]
    [SerializeField]
    private List<SkillData> ownedSkills = new List<SkillData>();

    [Header("現在使用可能なスキル")]
    [SerializeField]
    private List<SkillData> handSkills = new List<SkillData>();

    [Header("使う技")]
    [SerializeField]
    private List<SkillData> selectedSkill = new List<SkillData>();
    //ここで選択した技を外部から参照できるようにするためのプロパティを追加
    public List<SkillData> SelectedSkill => selectedSkill;

    [Header("選択した技のインデックスリスト")]
    [SerializeField]
    private List<int> selectedSkillIndex = new List<int>();


    private void Start()
    {
        // 初期スキルを所持スキルに追加
        foreach (SkillData skill in startSkills)
        {
            AddOwnedSkill(skill);
        }
    }


    // 所持スキルに追加
    public void AddOwnedSkill(SkillData skill)
    {
        ownedSkills.Add(skill);
    }


    // 所持スキルから削除
    public void RemoveOwnedSkill(SkillData skill)
    {
        ownedSkills.Remove(skill);
    }


    // 手札に追加
    public void AddHandSkill(SkillData skill)
    {
        handSkills.Add(skill);
    }


    // 手札から削除
    public void RemoveHandSkill(SkillData skill)
    {
        handSkills.Remove(skill);
    }


    // 所持スキルからランダムに1枚手札へ
    public void DrawSkill()
    {
        int index = Random.Range(0, ownedSkills.Count);

        AddHandSkill(ownedSkills[index]);
    }

    public void SelectSkill(int index)
    {
        if (selectedSkillIndex.Count >= 3)
            return;

        if (selectedSkillIndex.Contains(index))
            return;

        selectedSkillIndex.Add(index);
        selectedSkill.Add(handSkills[index]);
    }

    public void CancelSkill(int index)
    {
        if (!selectedSkillIndex.Contains(index))
            return;

        int selectedIndex = selectedSkillIndex.IndexOf(index);

        selectedSkillIndex.RemoveAt(selectedIndex);
        selectedSkill.RemoveAt(selectedIndex);
    }
    //非同期処理
    public async UniTask UseCard(BattleCharacter target)
    {
        foreach (SkillData skill in selectedSkill)
        {
            target.TakeDamage(skill.damage);

            foreach (SkillEffect effect in skill.effects)
            {
                effect.Execute(target);
            }

            await UniTask.Delay(500);
        }
    }
}
