using UnityEngine;
using TMPro;

public class SkillCardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text skillNameText;
    [SerializeField] private TMP_Text damageText;

    public BattleState state;
    private BattleSceneManager battlescenemanager;
    private SkillManager skillManager;
    private int cardIndex;
    private bool isSelected = false;

    public void SetCard(SkillData skill, int index, SkillManager manager , BattleSceneManager battlemanager)
    {
        cardIndex = index;
        skillManager = manager;
        battlescenemanager = battlemanager;
        skillNameText.text = skill.skillName;
        damageText.text = skill.damage.ToString();
    }
    public void OnClick()
    {
        if (!isSelected)
        {
            skillManager.SelectSkill(cardIndex);
            isSelected = true;
        }
        else
        {
            skillManager.CancelSkill(cardIndex);
            isSelected = false;
        }
    }

    public void DestoryCard()
    {
        Destroy(gameObject); 
    }

    private void Update()
    {
        if (battlescenemanager.state == BattleState.JudgementTurn)
        {
            Debug.Log("kesu");
            Destroy(gameObject);
        }

    }
}