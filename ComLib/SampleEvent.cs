using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace ComLib
{
    /// <summary>状態変更イベント</summary>
    public delegate void StateChanged();
    /// <summary>時間変更イベント</summary>
    public delegate void DateTimeChanged(DateTime date);
    /// <summary>
    /// 
    /// </summary>
    [ComSourceInterfaces(typeof(ISampleEvent))]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ComLib.SampleEvent")]
    public class SampleEvent
    {
        /// ISampleEvent にあるイベントと同じものが呼び出し可能になる (っぽい)
        /// <summary></summary>
        public event StateChanged    StateChanged;
        /// <summary></summary>
        public event DateTimeChanged DateTimeChanged;
        /// <summary>
        /// 
        /// </summary>
        public SampleEvent()
        {
            // 実際は COM 側で通知を受けた場合にイベントを発動するのだけど
            // 受けた前提で通知を送る
            new TaskFactory().StartNew(() => 
            {
                while(true)
                {
                    Thread.Sleep(1000);
                    if (StateChanged != null)
                    {
                        StateChanged();
                    }
                }
            });
            new TaskFactory().StartNew(() => 
            {
                while(true)
                {
                    Thread.Sleep(100);
                    if (DateTimeChanged != null)
                    {
                        DateTimeChanged(DateTime.Now);
                    }
                }
            });
        }
    }
}
