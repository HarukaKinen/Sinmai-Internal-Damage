using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Sinmai_Internal_Damage
{
    public class Sinmai_GUI : MonoBehaviour
    {
        private Rect window;
        bool menu_toggle;

        public void Start()
        {
            // Rect(X, Y, W, H);
            window = new Rect(10f,10f, 300f, 200f);
        }

        public void Update()
        {
           if(Input.GetKeyDown(KeyCode.Delete))
            {
                menu_toggle = !menu_toggle;
            }
        }

        public static Color Color
        {
            get { return GUI.color; }
            set { GUI.color = value; }
        }

        public static void DrawBox(Vector2 position, Vector2 size, bool centered = true)
        {
            var upperLeft = centered ? position - size / 2f : position;
            GUI.DrawTexture(new Rect(position, size), Texture2D.whiteTexture, ScaleMode.StretchToFill);
        }

        public static void DrawBox(Vector2 position, Vector2 size, Color color, bool centered = true)
        {
            Color = color;
            DrawBox(position, size, centered);
        }

        public void OnGUI()
        {
            DrawBox(new Vector2(Screen.width / 2f, Screen.height/ 2f), new Vector2(40, 40), Color.green);
            Console.Log("OnGui Called");
        }

        public void Page1(int id)
        {
            // This button named by mlc.yaw
            GUILayout.Button("nigger", new GUILayoutOption[0]);

            GUILayout.Space(10f);
            GUI.DragWindow();
        }
    }
}
