using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Fsm
{
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    /// 型定義
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

    /// <summary>FSMイベントハンドラ(デリゲート)</summary>
    public delegate void FsmHandler();

    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    /// <summary>
    /// 汎用FSM(有限状態機械)モジュール
    /// </summary>
    /// <remarks>
    /// 使用に当たっては状態遷移表の定義が必要
    /// </remarks>
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    public class FsmCore
    {
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public プロパティ
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// <summary>内部状態</summary>
        public Enum State { get; set; }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// private メンバ
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 状態遷移表 ( (現在状態・イベント) vs (遷移先状態・付随処理) )
        private readonly Dictionary<(Enum fsmState, Enum fsmEvent),
                                    (Enum? newState, FsmHandler? fsmHandler)> m_FsmMatrix;

        // イベントキュー
        private readonly ConcurrentQueue<Enum> m_Que_FsmEvents = new ConcurrentQueue<Enum>();

        // シンクロナイザ
        private readonly ManualResetEventSlim m_Mres = new ManualResetEventSlim(false);

        // FSMスレッド
        private readonly Task m_FsmThread;

        // FSMスレッド停止要求
        private bool m_AbortReq = false;

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// コンストラクタ・デストラクタ
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="initialState">内部状態の初期値</param>
        /// <param name="dic_Fsm">状態遷移表</param>
        public FsmCore(Enum initialState, 
                       Dictionary<(Enum fsmState, Enum fsmEvent),
                                  (Enum? newState, FsmHandler? fsmHandler)> dic_Fsm)
        {
            // 内部状態、状態遷移表初期化
            State = initialState;
            m_FsmMatrix = new Dictionary<(Enum fsmState, Enum fsmEvent),
                                         (Enum? newState, FsmHandler? fsmHandler)>(dic_Fsm);

            // FSMスレッド起動
            m_FsmThread = Task.Run(() => SolveEvent());
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~FsmCore()
        {
            // シンクロナイザの破棄
            m_Mres.Dispose();
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public メソッド
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// <summary>
        /// FSMイベント発行
        /// </summary>
        /// <param name="fsmEvent">発行するイベント</param>
        public void RaiseFsmEvent(Enum fsmEvent)
        {
            // イベントをエンキュー、シグナルセット
            m_Que_FsmEvents.Enqueue(fsmEvent);
            m_Mres.Set();
        }

        /// <summary>
        /// FSM停止
        /// </summary>
        public void StopFsm()
        {
            // スレッド停止要求オン、シグナルセット
            m_AbortReq = true;
            m_Mres.Set();
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// private メソッド
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// <summary>
        /// FSMスレッド(イベントの処理)
        /// </summary>
        private void SolveEvent()
        {
            // 停止要求がオフの間無限ループ
            while (!m_AbortReq)
            {
                // イベントのデキュー成功時は
                // 状態遷移表から現在の状態とイベントに対応する
                // 遷移先状態・付随処理を取得
                // ⇒ 取得成功(値の定義あり)時のみ状態遷移、付随処理実行
                if (m_Que_FsmEvents.TryDequeue(out var fsmEvent) &&
                    m_FsmMatrix.TryGetValue((State, fsmEvent), out var item))
                {
                    var newState = item.newState;
                    var fsmHandler = item.fsmHandler;

                    // 状態遷移(内部状態更新)
                    if (newState != null)
                    {
                        State = newState;
                    }

                    // 付随処理実行
                    if (fsmHandler != null)
                    {
                        fsmHandler();
                    }
                }

                // キューが空の場合
                if (m_Que_FsmEvents.IsEmpty)
                {
                    // シグナルをリセット、シグナル待ちに移行(タスク休眠)
                    m_Mres.Reset();
                    m_Mres.Wait(Timeout.Infinite);
                }
            }
        }

    }       // public class FsmCore

}       // namespace Fsm
