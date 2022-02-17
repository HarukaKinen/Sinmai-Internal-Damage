using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using UnityEngine;
using Microsoft.Win32;

namespace Sinmai_Internal_Damage
{
    public class Main
    {
        public static GameObject _objects;

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public void Init()
        {
            AllocConsole();
            _objects = new GameObject();
            _objects.AddComponent<Sinmai_GUI>();
            UnityEngine.Object.DontDestroyOnLoad(_objects);
            Console.Log("INJECT=-----------------------------------------");
        }
    }
}
