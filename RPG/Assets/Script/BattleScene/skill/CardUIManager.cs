using UnityEngine;
using System.Collections.Generic;

public class CardUIManager : MonoBehaviour
{
    private List<GameObject> CardUI = new List<GameObject>();
    private List<GameObject> SelectSkillCardUI = new List<GameObject>();
    [SerializeField] private SkillCardUI skillcardUI;
    [SerializeField] private CardSpawner cardspawner;

    public void AddCardUI(SkillCardUI card)
    {
        CardUI.Add(card.gameObject);
    }
}
