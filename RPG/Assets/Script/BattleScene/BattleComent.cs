using TMPro;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class BattleComent : MonoBehaviour
{
    //Šî–{‚±‚±‚Å‚Í•¶Žš‚ð•\Ž¦‚·‚é‚¾‚¯
    [SerializeField] private BattleEventManager battleEventManager;

    [SerializeField] private TMP_Text _text;

    [SerializeField] private float _delayDuration = 0.5f;
    public async UniTask Show(string text)
    {
        _text.text = text;

        _text.maxVisibleCharacters = 0;

        int length = _text.text.Length;

        for (int i = 0; i < length; i++)
        {
            _text.maxVisibleCharacters = i + 1;

            await UniTask.Delay((int)(_delayDuration * 1000),cancellationToken: this.GetCancellationTokenOnDestroy());
        }

        _text.maxVisibleCharacters = length;
    }
}