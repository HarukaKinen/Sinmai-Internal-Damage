using Sinmai.Functions;
using Sinmai.Helper;
using UnityEngine;

namespace Sinmai.UI
{
    public class Menu : MonoBehaviour
    {
        private bool MenuToggle = true;
        private Rect Window;


        private void Start()
        {
            Window = new Rect(20f, 60f, 250f, 350f);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Delete)) // check Unity.Input when menu open unlock ur cursor
                MenuToggle = !MenuToggle;
        }

        private void OnGUI()
        {
            // Draw ur epic hek here
            if (MenuToggle)
                Window = GUILayout.Window(0, Window, RenderMenu, "Internal Damage for Sinmai");
            Render.DrawCross(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(20, 20), 1f,
                new Color(0, 255, 0));
            Render.DrawString(new Vector2(200, 200), "Sinmai-Internal-Damage");

            // Call Functions in Functions
            // what the fuck is this named
            Skins.ModifyVersionNum();
            Timer.InfinityFreedomTime();
            Timer.InfinityPrepareTime();
            Skins.RateChanger();
        }

        private void RenderMenu(int id)
        {
            switch (id)
            {
                // Menu
                case 0:
                    // Legit Autoplay

                    // Rage Autoplay

                    // Some cool part idk

                    // Skin Changer
                    GUILayout.Label("Skin Changer");
                    Settings.RateCheckBox = GUILayout.Toggle(Settings.RateCheckBox, "でらっくす Rating");
                    if (Settings.RateCheckBox)
                        Settings.RatingValue = GUILayout.TextArea(Settings.RatingValue, 5);
                    // Misc
                    GUILayout.Label("Misc");
                    Settings.InfinityFreedomTimeCheckBox = GUILayout.Toggle(Settings.InfinityFreedomTimeCheckBox, "Infinity FreedomTime");
                    Settings.InfinityPrepareTimeCheckBox = GUILayout.Toggle(Settings.InfinityPrepareTimeCheckBox, "Infinity PrepareTime");
                    if (GUILayout.Button("Unload"))
                        Loader.Unload();
                    // Test things
                    GUILayout.Label("Test Area");
                    Settings.FrameCheckBox = GUILayout.Toggle(Settings.FrameCheckBox, "Get Frame");
                    // cute break
                    break;
            }

            GUI.DragWindow();
        }
    }
}