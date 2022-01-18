using System.Collections.Concurrent;

namespace Fsm
{
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    /// <summary>
    /// 汎用FSMモジュール
    /// </summary>
    /// <remarks>
    /// 状態一覧(Enum)、遷移契機(イベント)一覧(Enum)、<br/>
    /// イベントハンドラ一覧(Dictionary)の定義が必要<br/>
    /// イベントハンドラ一覧<br/>
    /// キー : タプル(状態(Enum), イベント(Enum))<br/>
    /// 値 : デリゲート(FsmHandler)<br/>
    /// </remarks>
    /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
    public class FsmCore
    {
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public デリゲート型定義
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // FSMイベントハンドラ
        public delegate void FsmHandler();

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// private メンバ
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 内部状態
        private Enum m_State;

        // 状態・イベント vs FSMイベントハンドラ
        private readonly Dictionary<(Enum fsmState, Enum fsmEvent), FsmHandler> m_Dic_Fsm;

        // イベントキュー
        private ConcurrentQueue<Enum> m_Que_FsmEvents = new ConcurrentQueue<Enum>();

        // シンクロナイザ
        private ManualResetEventSlim m_Mres = new ManualResetEventSlim(false);

        private Task m_FsmThread;

        // FSMスレッド停止要求
        private bool m_AbortReq = false;

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// public メソッド
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="initialState">内部状態の初期値</param>
        /// <param name="dic_Fsm">状態・イベントに対するハンドラの一覧</param>
        public FsmCore(Enum initialState,
                       Dictionary<(Enum, Enum), FsmHandler> dic_Fsm)
        {
            // 内部状態、ハンドラ一覧初期化
            m_State = initialState;
            m_Dic_Fsm = new Dictionary<(Enum, Enum), FsmHandler>(dic_Fsm);

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

        /// <summary>
        /// FSMイベント発行
        /// </summary>
        /// <param name="fsmEvent">発行するイベント</param>
        public void PostFsmEvent(Enum fsmEvent)
        {
            // イベントをエンキュー、シグナルセット
            m_Que_FsmEvents.Enqueue(fsmEvent);
            m_Mres.Set();
        }

        /// <summary>
        /// FSM停止
        /// </summary>
        public async void StopFsm()
        {
            // 停止要求オン、シグナルセット
            m_AbortReq = true;
            m_Mres.Set();

            await m_FsmThread;
        }

        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        /// private メソッド
        /// - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        /// <summary>
        /// FSMスレッド
        /// </summary>
        private void SolveEvent()
        {
            // 停止要求がオフの間無限ループ
            while (!m_AbortReq)
            {
                // イベントのデキュー成功時
                if (m_Que_FsmEvents.TryDequeue(out var fsmEvent))
                {
                    // 対応するイベントハンドラが有効(非null)ならば実行
                    var fsmHandler = m_Dic_Fsm[(m_State, fsmEvent)];
                    if (fsmHandler != null)
                    {
                        fsmHandler();
                    }
                }
                // デキュー失敗、かつキューが空の場合
                else if (m_Que_FsmEvents.IsEmpty)
                {
                    // シグナルをリセット、シグナル待ちに移行(タスク休眠)
                    m_Mres.Reset();
                    m_Mres.Wait(Timeout.Infinite);
                }
            }
        }

    }       // public class FsmCore<E_FsmStates, E_FsmEvents>

}       // namespace Fsm
