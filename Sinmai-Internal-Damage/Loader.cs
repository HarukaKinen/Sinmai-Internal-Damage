using Sinmai.Functions;
using UnityEngine;

/*
 * SharpMonoInjectInfo:
 * Assembly To Inject: Sinmai.dll
 * Namespace: Sinmai
 * Class name: Loader
 * Method name: Init
 */

namespace Sinmai
{
    public class Loader
    {
        public static GameObject Load;

        public static void Init()
        {
            Load = new GameObject();

            Load.AddComponent<UI.Menu>();

            Object.DontDestroyOnLoad(Load);
            
            Sounds.InjectSound();
        }

        public static void Unload()
        {
            Object.Destroy(Load);
        }
    }
}
