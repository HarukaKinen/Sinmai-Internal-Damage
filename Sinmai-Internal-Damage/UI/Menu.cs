using Sinmai.Helper;
using UnityEngine;

namespace Sinmai.UI
{
    public class Menu : MonoBehaviour
    {
        private Rect Window;

        private bool MenuToggle = true;


        private void Start()
        {
            Window = new Rect(20f, 60f, 250f, 350f);
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Insert)) //check Unity.Input when menu open unlock ur cursor
                MenuToggle = !MenuToggle;

        }
       
        private void OnGUI()
        {
            //Draw ur epic hek here
            if (MenuToggle)
            Window = GUILayout.Window(0, Window, new GUI.WindowFunction(RenderMenu), "unity internal gui", new GUILayoutOption[0]);
            Render.DrawCross(new Vector2(Screen.width /2, Screen.height /2), new Vector2(20, 20), 1f, new Color(0,255,0));
            Render.DrawString(new Vector2(200, 200), "Sinmai-Internal-Damage-Csharp", false);
        }

        private void RenderMenu(int id)
        {
            switch (id)
            {
                case 0:
                    Settings.CheckBox = GUILayout.Toggle(Settings.CheckBox, "hi checkbox", new GUILayoutOption[0]);
                    GUILayout.Label("hi label", new GUILayoutOption[0]);
                    GUILayout.Button("hi button", new GUILayoutOption[0]);

                    if (GUILayout.Button("Unload", new GUILayoutOption[0]))
                        Loader.Unload();
                    
                    break;
                default:
                    break;
            }
            GUI.DragWindow();
        }
    }
}
