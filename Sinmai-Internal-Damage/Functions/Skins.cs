using System;
using System.Globalization;
using System.Reflection;
using Manager;
using Sinmai.Helper;
using UnityEngine;

namespace Sinmai.Functions
{
    public class Skins
    {
        private const BindingFlags pBindFlags = BindingFlags.NonPublic;
        private const BindingFlags iBindFlags = BindingFlags.Instance;
        private const BindingFlags sBindFlags = BindingFlags.Static;

        /*public static void GetTimer()
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
                var countDownSecond = commonTimerType.GetField("_countDownSecond", pBindFlags | iBindFlags);
                Render.DrawString(new Vector2(200, 240), countDownSecond.GetValue(commonTimerType).ToString(),
                    false);


                /#1#/ 获取左屏幕的GenericProcess
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
                    
                    // 操你妈 没几把用
                    
                    
                    _timerController.SetValue(lGenericProcess, timerController);#1#
            }
            else
            {
                Render.DrawString(new Vector2(200, 240), "CommonTimer = null", false);
            }

            /*
                if(Timer)
                    Render.DrawString(new Vector2(200, 210), Timer.ToString(), false);
                else
                    Render.DrawString(new Vector2(200, 210), "null object", false);#1#
        }*/
        private static UserInformationController getUserInformationController()
        {
            UserInformationController UserInformationController = GameObject
                .Find("Sub/UI_UserInformation/UI_UserData/")
                .GetComponent<UserInformationController>();

            return UserInformationController;
        }


        public static void PlayerOneOnly()
        {
        }

        public static void RateChanger()
        {
            if (!Settings.RateCheckBox) return;

            UserInformationController UserInformationController = getUserInformationController();

            var rate = uint.Parse(Settings.RatingValue, NumberStyles.Integer);

            if (UserInformationController != null)
            {
                UserInformationController.SetUserRating(rate);
            }
        }

        public static void UdemaeChanger()
        {
            if (!Settings.UdemaeCheckBox) return;

            UserInformationController UserInformationController = getUserInformationController();

            int udemaeId = int.Parse(Settings.UdemaeValue);

            var udemae = (UdemaeID) udemaeId;

            if (UserInformationController != null)
            {
                UserInformationController.SetUdemae(udemae);
            }
        }

        public static void ModifyVersionNum()
        {

        }
    }
}