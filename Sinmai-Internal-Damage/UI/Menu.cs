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
            Window = new Rect(350, 100f, 300, 400);
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
            Render.DrawString(new Vector2(100, 170), "Sinmai-Internal-Damage");
            Render.DrawString(new Vector2(100, 185), "Local Client: " + Functions.Version.CheckClientVersion());
            Render.DrawString(new Vector2(100, 200), "Build: b20220406-C");

            // Call Functions in Functions
            // what the fuck is this named
            Skins.RateChanger();
            Skins.UdemaeChanger();
            Skins.TitleChanger();

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
                    GUILayout.BeginVertical("MainToolbar", GUILayout.Height(20));
                    Settings.MainToolbarInt = GUILayout.Toolbar(Settings.MainToolbarInt, Settings.MainToolbarStrings, GUILayout.Width(300), GUILayout.Height(20));
                    GUILayout.EndVertical();

                    switch (Settings.MainToolbarInt)
                    {
                        case 0:
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
                            GUILayout.EndVertical();
                            break;
                        case 1:
                            GUILayout.BeginVertical("Skins");
                            // Skin Changer
                            GUILayout.Label("Skin Changer");
                            Settings.RateCheckBox = GUILayout.Toggle(Settings.RateCheckBox, "でらっくす Rating");
                            if (Settings.RateCheckBox)
                            {
                                GUILayout.Label("Rating:");
                                Settings.RatingValue = GUILayout.TextField(Settings.RatingValue, 5);
                            }
                            Settings.UdemaeCheckBox = GUILayout.Toggle(Settings.UdemaeCheckBox, "段位認定");
                            if (Settings.UdemaeCheckBox)
                            {
                                GUILayout.Label("Index:");
                                Settings.UdemaeValue = GUILayout.TextField(Settings.UdemaeValue, 2);
                            }
                            Settings.PlateCheckBox = GUILayout.Toggle(Settings.PlateCheckBox, "Plate");
                            Settings.FrameCheckBox = GUILayout.Toggle(Settings.FrameCheckBox, "Frame");
                            Settings.TitleCheckBox = GUILayout.Toggle(Settings.TitleCheckBox, "Title");
                            if (Settings.TitleCheckBox)
                            {
                                Settings.TitleMethodInt =
                                    GUILayout.SelectionGrid(Settings.TitleMethodInt, Settings.TitleMethod, 1);
                                switch (Settings.TitleMethodInt)
                                {
                                    case 0:
                                        GUILayout.Label("Title index:");
                                        Settings.TitleValueOriginal = GUILayout.TextField(Settings.TitleValueOriginal, 255);
                                        GUILayout.Label("Title type:");
                                        Settings.TitleType = GUILayout.TextField(Settings.TitleType, 7);
                                        break;
                                    case 1:
                                        GUILayout.Label("Title name:");
                                        Settings.TitleValueCustom = GUILayout.TextField(Settings.TitleValueCustom, 255);
                                        GUILayout.Label("Title type:");
                                        Settings.TitleType = GUILayout.TextField(Settings.TitleType, 7);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            Settings.DXPassCheckBox = GUILayout.Toggle(Settings.DXPassCheckBox, "DX Pass");
                            GUILayout.EndVertical();
                            break;
                        case 2:
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
                            break;
                        default:
                            break;
                    }

                    // A cute break
                    break;
            }

            GUI.DragWindow();
        }
    }
}