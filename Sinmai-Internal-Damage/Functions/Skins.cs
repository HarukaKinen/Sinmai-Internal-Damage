using System.Globalization;
using System.Reflection;
using Manager;
using Sinmai.Helper;
using UnityEngine;

namespace Sinmai.Functions
{
    public class Skins
    {
        private static readonly BindingFlags BindFlags = BindingFlags.NonPublic | BindingFlags.Instance;
        private static readonly BindingFlags pBindFlags = BindingFlags.NonPublic;
        private static readonly BindingFlags iBindFlags = BindingFlags.Instance;
        private static readonly BindingFlags sBindFlags = BindingFlags.Static;

        private static UserInformationController lUserInformationController = GameObject
            .Find("LeftMonitor/CommonProcess(Clone)/RearCanvas/Sub/UI_UserInformation/UI_UserData/")
            .GetComponent<UserInformationController>();

        private static UserInformationController rUserInformationController = GameObject
            .Find("RightMonitor/CommonProcess(Clone)/RearCanvas/Sub/UI_UserInformation/UI_UserData/")
            .GetComponent<UserInformationController>();

        public static void GetTimer()
        {
            if (!Settings.CheckBox) return;
            Render.DrawString(new Vector2(200, 210), "CheckBox Checked", false);

            // CommonTimer (Unity.GameObject)   
            var lCommonTimer = GameObject
                .Find("LeftMonitor/GenericProcess(Clone)/Canvas/Main/UI_Timer/CommonTimer(Clone)")
                .GetComponent<CommonTimer>();

            if (lCommonTimer != null)
            {
                var commonTimerType = typeof(TimerController);
                var countDownSecond = commonTimerType.GetField("_countDownSecond", BindFlags);
                Render.DrawString(new Vector2(200, 240), countDownSecond.GetValue(commonTimerType).ToString(),
                    false);


                /*// 获取左屏幕的GenericProcess
                    var lGenericProcess = GameObject.Find("LeftMonitor/GenericProcess(Clone)").GetComponent<GenericProcess>();
                    // 定义GenericProcess的type
                    Type genericProcessType = typeof(GenericProcess);
                    // 从GenericProcess里获取private field timerController
                    FieldInfo _timerController = genericProcessType.GetField("_timerController", BindFlags);
                    // 获取timerController的值 （array）
                    TimerController timerController = _timerController?.GetValue(lGenericProcess) as TimerController;
                    // 定义TimerController的Type
                    Type leftMonitorTimerControllerType = typeof(TimerController);
                    // 从TimerController类里拿private field countDownSecond
                    FieldInfo leftMonitorTimerControllerFi = leftMonitorTimerControllerType.GetField("_countDownSecond", BindFlags);
                    // 修改 TimerController array 的值
                    leftMonitorTimerControllerFi.SetValue(timerController, 99U);

                    _timerController.SetValue(lGenericProcess, timerController);*/
            }
            else
            {
                Render.DrawString(new Vector2(200, 240), "CommonTimer = null", false);
            }

            /*
                if(Timer)
                    Render.DrawString(new Vector2(200, 210), Timer.ToString(), false);
                else
                    Render.DrawString(new Vector2(200, 210), "null object", false);*/
        }

        public static void PlayerOneOnly()
        {
        }

        public static void RateChanger()
        {
            if (!Settings.RateCheckBox) return;

            var rate = uint.Parse(Settings.RatingValue, NumberStyles.Integer);

            if (lUserInformationController != null)
            {
                lUserInformationController.SetUserRating(rate);
            }
        }

        public static void UdemaeChanger()
        {

        }

        public static void ModifyVersionNum()
        {
            if (!Settings.FrameCheckBox)
                return;
            // CommonTimer (Unity.GameObject)   
            var UiFrame =
                GameObject.Find(
                    "LeftMonitor/CommonProcess(Clone)/RearCanvas/Sub/UI_UserInformation/UI_UserData/UI_User/IMG_Frame/");
            Render.DrawString(new Vector2(200, 220), UiFrame.ToString(), false);
        }
    }
}