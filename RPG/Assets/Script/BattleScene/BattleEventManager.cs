using UnityEngine;
using R3;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public class BattleEventManager : MonoBehaviour
{
    //基本ここではR3受け取り、キューに入れる、取り出す、待つ

    public Subject<string> CombatLog = new();//戦闘ログのSubjectを作成

    private Queue<string> commentQueue = new Queue<string>();//戦闘ログのコメントを格納する

    [SerializeField] private BattleComent battleComent;

    private void Start()
    {
        CombatLog.Subscribe(message =>{commentQueue.Enqueue(message);}).AddTo(this);//ここでBattleEventManagerのSubscribe

        ProcessComments().Forget();//コメントの処理を開始
    }

    private async UniTask ProcessComments()
    {
        while (true)　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　//いつかここを常に監視じゃなくQueueにコメントが追加されたときだけ処理を開始するようにする
        {
            if (commentQueue.Count > 0)
            {
                string comment = commentQueue.Dequeue();//キューの上からコメントを取り出す

                await battleComent.Show(comment);//処理が終わるまで待機
            }

            await UniTask.Yield();//次のフレームまで待機
            await UniTask.Delay(1000);//1秒待機してから次のコメントを処理する
        }
    }
}
