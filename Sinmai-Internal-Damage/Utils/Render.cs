using System.Collections.Generic;
using UnityEngine;

namespace Sinmai
{
    public static class Render
    {

        public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);
        private class RingArray
        {
            public Vector2[] Positions { get; private set; }

            public RingArray(int numSegments)
            {
                Positions = new Vector2[numSegments];
                var stepSize = 360f / numSegments;
                for (int i = 0; i < numSegments; i++)
                {
                    var rad = Mathf.Deg2Rad * stepSize * i;
                    Positions[i] = new Vector2(Mathf.Sin(rad), Mathf.Cos(rad));
                }
            }
        }

        private static Dictionary<int, RingArray> ringDict = new Dictionary<int, RingArray>();

        public static Color Color {
            get { return GUI.color; }
            set { GUI.color = value; }
        }

        public static void DrawLine(Vector2 from, Vector2 to, float thickness, Color color)
        {
            Color = color;
            DrawLine(from, to, thickness);
        }
        public static void DrawLine(Vector2 from, Vector2 to, float thickness)
        {
            var delta = (to - from).normalized;
            var angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
            GUIUtility.RotateAroundPivot(angle, from);
            DrawBox(from, Vector2.right * (from - to).magnitude, thickness, false);
            GUIUtility.RotateAroundPivot(-angle, from);
        }

        public static void DrawBox(Vector2 position, Vector2 size, float thickness, Color color, bool centered = true)
        {
            Color = color;
            DrawBox(position, size, thickness, centered);
        }
        public static void DrawBox(Vector2 position, Vector2 size, float thickness, bool centered = true)
        {
            var upperLeft = centered ? position - size / 2f : position;
            GUI.DrawTexture(new Rect(position.x, position.y, size.x, thickness), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y, thickness, size.y), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x + size.x, position.y, thickness, size.y), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y + size.y, size.x + thickness, thickness), Texture2D.whiteTexture);
        }

        public static void DrawCross(Vector2 position, Vector2 size, float thickness, Color color)
        {
            Color = color;
            DrawCross(position, size, thickness);
        }
        public static void DrawCross(Vector2 position, Vector2 size, float thickness)
        {
            GUI.DrawTexture(new Rect(position.x - size.x / 2f, position.y, size.x, thickness), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y - size.y / 2f, thickness, size.y), Texture2D.whiteTexture);
        }

        public static void DrawDot(Vector2 position, Color color)
        {
            Color = color;
            DrawDot(position);
        }
        public static void DrawDot(Vector2 position)
        {
            DrawBox(position - Vector2.one, Vector2.one * 2f, 1f);
        }

        public static void DrawString(Vector2 position, string label, Color color, bool centered = true)
        {
            Color = color;
            DrawString(position, label, centered);
        }
        public static void DrawString(Vector2 position, string label, bool centered = true)
        {
            var content = new GUIContent(label);
            var size = StringStyle.CalcSize(content);
            var upperLeft = centered ? position - size / 2f : position;
            GUI.Label(new Rect(upperLeft, size), content);
        }

        public static void DrawCircle(Vector2 position, float radius, int numSides, bool centered = true, float thickness = 1f)
        {
            DrawCircle(position, radius, numSides, Color.white, centered, thickness);
        }
        public static void DrawCircle(Vector2 position, float radius, int numSides, Color color, bool centered = true, float thickness = 1f)
        {
            RingArray arr;
            if (ringDict.ContainsKey(numSides))
                arr = ringDict[numSides];
            else
                arr = ringDict[numSides] = new RingArray(numSides);


            var center = centered ? position : position + Vector2.one * radius;

            for (int i = 0; i < numSides - 1; i++)
                DrawLine(center + arr.Positions[i] * radius, center + arr.Positions[i + 1] * radius, thickness, color);

            DrawLine(center + arr.Positions[0] * radius, center + arr.Positions[arr.Positions.Length - 1] * radius, thickness, color);
        }

    }
}
