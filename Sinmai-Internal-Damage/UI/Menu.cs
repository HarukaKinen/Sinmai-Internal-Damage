using PartyLink;
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
            Window = new Rect(20f, 60f, 600f, 400f);
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
            Render.DrawString(new Vector2(200, 185), "Sinmai-Internal-Damage");
            Render.DrawString(new Vector2(200, 200), "Build: b20220405-A");

            // Call Functions in Functions
            // what the fuck is this named
            Skins.RateChanger();
            Skins.UdemaeChanger();

            Timer.InfinityFreedomTime();
            Timer.InfinityPrepareTime();
            
            AutoPlay.Opposite();
            AutoPlay.RandomCycle();
            AutoPlay.Force();
        }

        private void RenderMenu(int id)
        {
            switch (id)
            {
                // Menu
                case 0:
                    GUILayout.BeginHorizontal("Main");
                    
                    GUILayout.BeginVertical("Legit");
                    // Legit
                    GUILayout.Label("Legit");
                    Settings.LegitAutoPlayCheckBox = GUILayout.Toggle(Settings.LegitAutoPlayCheckBox, "Legit AutoPlay");
                    if (Settings.LegitAutoPlayCheckBox)
                    {
                        Settings.LegitMethodInt =
                            GUILayout.SelectionGrid(Settings.LegitMethodInt, Settings.LegitMethod, 1);
                        switch (Settings.LegitMethodInt)
                        {
                            case 0:
                            case 1:
                                GUILayout.Label("Critical Value");
                                Settings.CriticalValue = GUILayout.HorizontalScrollbar(Settings.CriticalValue, 1.0f, 0.0f, 100.0f);
                                GUILayout.Label("Perfect Value");
                                Settings.PerfectValue = GUILayout.HorizontalScrollbar(Settings.PerfectValue, 1.0f, 0.0f, 100.0f);
                                GUILayout.Label("Great Value");
                                Settings.GreatValue = GUILayout.HorizontalScrollbar(Settings.GreatValue, 1.0f, 0.0f, 100.0f);
                                GUILayout.Label("Good Value");
                                Settings.GoodValue = GUILayout.HorizontalScrollbar(Settings.GoodValue, 1.0f, 0.0f, 100.0f);
                                GUILayout.Label("Miss Value");
                                Settings.MissValue = GUILayout.HorizontalScrollbar(Settings.MissValue, 1.0f, 0.0f, 100.0f);
                                break;
                            case 2:
                                Settings.CriticalToggle = GUILayout.Toggle(Settings.CriticalToggle, "Critical");
                                Settings.PerfectToggle = GUILayout.Toggle(Settings.PerfectToggle, "Perfect");
                                Settings.GreatToggle = GUILayout.Toggle(Settings.GreatToggle, "Great");
                                Settings.GoodToggle = GUILayout.Toggle(Settings.GoodToggle, "Good");
                                Settings.MissToggle = GUILayout.Toggle(Settings.MissToggle, "Miss");
                                break;
                            default:
                                break;
                        }
                    }

                {
                        
                    }
                    GUILayout.EndVertical();

                    // Rage

                    // Some cool part idk

                    GUILayout.BeginVertical("Skins");
                    // Skin Changer
                    GUILayout.Label("Skin Changer");
                    Settings.RateCheckBox = GUILayout.Toggle(Settings.RateCheckBox, "でらっくす Rating");
                    if (Settings.RateCheckBox)
                        Settings.RatingValue = GUILayout.TextArea(Settings.RatingValue, 5);
                    Settings.UdemaeCheckBox = GUILayout.Toggle(Settings.UdemaeCheckBox, "段位認定");
                    if (Settings.UdemaeCheckBox)
                        Settings.UdemaeValue = GUILayout.TextArea(Settings.UdemaeValue, 2);
                    Settings.PlateCheckBox = GUILayout.Toggle(Settings.PlateCheckBox, "Plate");
                    Settings.FrameCheckBox = GUILayout.Toggle(Settings.FrameCheckBox, "Frame");
                    Settings.TitleCheckBox = GUILayout.Toggle(Settings.TitleCheckBox, "Title");
                    Settings.DXPassCheckBox= GUILayout.Toggle(Settings.DXPassCheckBox, "DX Pass");
                    GUILayout.EndVertical();

                    GUILayout.BeginVertical("Misc");
                    // Misc
                    GUILayout.Label("Misc");
                    Settings.InfinityFreedomTimeCheckBox = GUILayout.Toggle(Settings.InfinityFreedomTimeCheckBox, "Infinity FreedomTime");
                    Settings.InfinityPrepareTimeCheckBox = GUILayout.Toggle(Settings.InfinityPrepareTimeCheckBox, "Infinity PrepareTime");
                    if (GUILayout.Button("Force Track Skip"))
                        ;
                    if (GUILayout.Button("Unload"))
                        Loader.Unload();
                    GUILayout.EndVertical();

                    GUILayout.EndHorizontal();
                    
                    // A cute break
                    break;
            }

            GUI.DragWindow();
        }
    }
}