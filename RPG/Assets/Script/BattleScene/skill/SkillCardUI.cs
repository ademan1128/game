using UnityEngine;
using TMPro;

public class SkillCardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text skillNameText;
    [SerializeField] private TMP_Text damageText;

    private SkillManager skillManager;
    private int cardIndex;
    private bool isSelected = false;

    public void SetCard(SkillData skill, int index, SkillManager manager)
    {
        cardIndex = index;
        skillManager = manager;

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

}