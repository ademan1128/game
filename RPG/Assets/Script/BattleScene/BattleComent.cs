using System.Collections;
using TMPro;
using UnityEngine;

public class BattleComent : MonoBehaviour
{
    // 対象のテキスト
    [SerializeField] private TMP_Text _text;

    // 次の文字を表示するまでの時間[s]
    [SerializeField] private float _delayDuration = 0.1f;

    private Coroutine _showCoroutine;

    /// <summary>
    /// 文字送り演出を表示する
    /// </summary>
    public void Show(string text)
    {
        _text.text = text;

        // 前回の演出処理が走っていたら、停止
        if (_showCoroutine != null)
            StopCoroutine(_showCoroutine);

        // １文字ずつ表示する演出のコルーチンを実行する
        _showCoroutine = StartCoroutine(ShowCoroutine());
    }

    // １文字ずつ表示する演出のコルーチン
    private IEnumerator ShowCoroutine()
    {
        // 待機用コルーチン
        // GC Allocを最小化するためキャッシュしておく
        var delay = new WaitForSeconds(_delayDuration);

        // テキスト全体の長さ
        var length = _text.text.Length;

        // １文字ずつ表示する演出
        for (var i = 0; i < length; i++)
        {
            // 徐々に表示文字数を増やしていく
            _text.maxVisibleCharacters = i + 1;

            // 一定時間待機
            yield return delay;
        }

        // 演出が終わったら全ての文字を表示する
        _text.maxVisibleCharacters = length;

        _showCoroutine = null;
    }

}