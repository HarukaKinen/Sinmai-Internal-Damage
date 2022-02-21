using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Manager;
using Sinmai.Helper;
using UnityEngine;

namespace Sinmai.Functions
{
    public class Timer
    {
        private static readonly BindingFlags pBindFlags = BindingFlags.NonPublic;
        private static readonly BindingFlags iBindFlags = BindingFlags.Instance;
        private static readonly BindingFlags sBindFlags = BindingFlags.Static;
        public static void InfinityFreedomTime()
        {
            if (!Settings.InfinityFreedomTimeCheckBox)
                return;

            var gameManagerType = typeof(GameManager);
            var freedomTime = gameManagerType.GetField("_freedomTime", sBindFlags | pBindFlags);

            freedomTime.SetValue(null, 6000000);

            // if (freedomTime != null)
            //     Render.DrawString(new Vector2(200, 270), freedomTime.GetValue(null).ToString(), false);
        }

        public static void InfinityPrepareTime()
        {
            if (!Settings.InfinityFreedomTimeCheckBox)
                return;
        }

    }
}
