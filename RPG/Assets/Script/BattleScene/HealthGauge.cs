using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthGauge : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private Image burnImage;
    [SerializeField] private BattleCharacter character;


    public float duration = 0.5f;// アニメーションの時間
    public float strength = 20f;//  振動の強さ
    public int vibrate = 100;// 振動の回数
    private float currentRate = 1f;// 現在のゲージの割合

    private void Start()
    {
        SetGauge(1f);
    }

    public void SetGauge(float value)
    {
        // DoTweenを連結して動かす
        healthImage.DOFillAmount(value, duration).OnComplete
            (() =>
            {
                burnImage.DOFillAmount(value, duration / 2f).SetDelay(0.5f);
            });

        transform.DOShakePosition( duration / 2f,strength, vibrate);
        currentRate = value;
    }

    public void GaugeTakeDamage()
    {
        // 現在HP / 最大HP = ゲージの割合
        float rate = (float)character.CurrentHP / character.MaxHP;

        SetGauge(rate);
    }
}