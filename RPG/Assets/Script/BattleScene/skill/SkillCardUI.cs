using TMPro;
using UnityEngine;

public class SkillCardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text skillNameText;
    [SerializeField] private TMP_Text damageText;

    public void SetCard(SkillData skill)
    {
        skillNameText.text = skill.skillName;
        damageText.text = skill.damage.ToString();
    }

   
}
