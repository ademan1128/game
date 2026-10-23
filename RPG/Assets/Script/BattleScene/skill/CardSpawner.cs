using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private SkillManager skillManager; // SkillManagerの参照
    [SerializeField] private SkillCardUI cardPrefab; // カードのプレハブ
    [SerializeField] private Transform cardParent; // カードを配置する親オブジェクト
    [SerializeField] private CardUIManager cardUImanager;
    [SerializeField] private BattleSceneManager battlescenemanager;


    [Header("カードの配置")]
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private float spacing = 100f;


    public void SpawnCards()
    {
        for (int i = 0; i < skillManager.HandSkills.Count; i++)
        {
            SkillData skill = skillManager.HandSkills[i];

            SkillCardUI card = Instantiate(cardPrefab, cardParent);

            cardUImanager.AddCardUI(card);

            RectTransform rectTransform = card.GetComponent<RectTransform>();

            rectTransform.anchoredPosition = startPosition + new Vector2(i * spacing, 0);

            card.SetCard(skill, i, skillManager, battlescenemanager);
        }
    }

}
