using System;
using System.Runtime.InteropServices.Automation;
using System.Windows;
using System.Windows.Controls;

namespace SampleCOM
{
    public partial class MainPage : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// メモ帳を起動する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dynamic controller = AutomationFactory.CreateObject("ComLib.ProcessController");
            controller.Start("notepad.exe");
        }
        /// <summary>
        /// COM オブジェクトを生成してイベントを受け取る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Regist(object sender, RoutedEventArgs e)
        {
            // COM オブジェクトを生成
            dynamic eventObj = AutomationFactory.CreateObject("ComLib.SampleEvent");
            // イベントを取得して定義
            AutomationEvent stateChanged = AutomationFactory.GetEvent(eventObj, "StateChanged");
            stateChanged.EventRaised += (o, ev) => {
                // 1 秒ごとに呼ばれる
                this.StateLog.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
            };
            // イベントを取得して定義
            AutomationEvent dateTimeChanged = AutomationFactory.GetEvent(eventObj, "DateTimeChanged");
            dateTimeChanged.EventRaised += (o, ev) => {
                // 100 ミリ秒ごとに呼ばれる
                DateTime date = (DateTime)ev.Arguments[0];
                this.DateLog.Text = date.ToString("yyyy/MM/dd HH:mm:ss.fff");
            };
        }
    }
}
