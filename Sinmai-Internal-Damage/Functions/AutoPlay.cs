using Manager;
using Sinmai.Helper;
using Random = System.Random;

namespace Sinmai.Functions
{
    public class AutoPlay
    {
        // 实例化
        private static Random rand = new Random();

        // 把 NextDouble 转成 Float
        public static float ToFloat(double value)
        {
            return (float)value;
        }

        // 幸运大乐透
        private static float CalcCent()
        {
            return rand.Next(0, 100) + ToFloat(rand.NextDouble());
        }

        // 另一个幸运大乐透
        private static int RandChoiceJudge()
        {
            return rand.Next(0, 4);
        }

        // Opposite 按顺序随机概率
        public static void Opposite()
        {
            float cent = CalcCent();

            /*Render.DrawString(new Vector2(200, 260), GameManager.AutoPlay.ToString(), false);
            Render.DrawString(new Vector2(200, 280), Settings.CriticalValue.ToString(), false);
            Render.DrawString(new Vector2(200, 290), Settings.PerfectValue.ToString(), false);
            Render.DrawString(new Vector2(200, 300), Settings.GreatValue.ToString(), false);
            Render.DrawString(new Vector2(200, 310), Settings.GoodValue.ToString(), false);
            Render.DrawString(new Vector2(200, 320), Settings.MissValue.ToString(), false);
            Render.DrawString(new Vector2(200, 340), cent.ToString(), false);*/

            if (!Settings.LegitAutoPlayCheckBox)
                return;
            if (Settings.LegitMethodInt == 0)
            {
                if (Settings.CriticalValue != 0.0f && cent <= Settings.CriticalValue)
                {
                    GameManager.AutoPlay = GameManager.AutoPlayMode.Critical;
                }
                else
                {
                    if (Settings.PerfectValue != 0.0f && cent <= Settings.PerfectValue)
                    {
                        GameManager.AutoPlay = GameManager.AutoPlayMode.Perfect;
                    }
                    else
                    {
                        if (Settings.GreatValue != 0.0f && cent <= Settings.GreatValue)
                        {
                            GameManager.AutoPlay = GameManager.AutoPlayMode.Great;
                        }
                        else
                        {
                            if (Settings.GoodValue != 0.0f && cent <= Settings.GoodValue)
                            {
                                GameManager.AutoPlay = GameManager.AutoPlayMode.Good;
                            }
                            else
                            {
                                if (Settings.MissValue != 0.0f && cent <= Settings.MissValue)
                                {
                                    GameManager.AutoPlay = GameManager.AutoPlayMode.None;
                                }
                                else
                                {
                                    GameManager.AutoPlay = GameManager.AutoPlayMode.Perfect;
                                }
                            }
                        }
                    }
                }

            }
        }

        // Random Cycle 随机迴圈
        public static void RandomCycle()
        {
            float cent = CalcCent();
            int judge = RandChoiceJudge();

            if (!Settings.LegitAutoPlayCheckBox)
                return;
            if (Settings.LegitMethodInt == 1)
            {
                switch (judge)
                {
                    case 0:
                        if (Settings.CriticalValue != 0.0f && cent <= Settings.CriticalValue)
                        {
                            GameManager.AutoPlay = GameManager.AutoPlayMode.Critical;
                        }
                        break;
                    case 1:
                        if (Settings.PerfectValue != 0.0f && cent <= Settings.PerfectValue)
                        {
                            GameManager.AutoPlay = GameManager.AutoPlayMode.Perfect;
                        }
                        break;
                    case 2:
                        if (Settings.GreatValue != 0.0f && cent <= Settings.GreatValue)
                        {
                            GameManager.AutoPlay = GameManager.AutoPlayMode.Great;
                        }
                        break;
                    case 3:
                        if (Settings.GoodValue != 0.0f && cent <= Settings.GoodValue)
                        {
                            GameManager.AutoPlay = GameManager.AutoPlayMode.Good;
                        }
                        break;
                    case 4:
                        if (Settings.MissValue != 0.0f && cent <= Settings.MissValue)
                        {
                            GameManager.AutoPlay = GameManager.AutoPlayMode.None;
                        }
                        break;
                    default:
                        GameManager.AutoPlay = GameManager.AutoPlayMode.Perfect;
                        break;
                }
            }
        }

        // 无概率强制随机
        public static void Force()
        {
            if (!Settings.LegitAutoPlayCheckBox)
                return;
            if (Settings.LegitMethodInt == 2)
            {
                switch (RandChoiceJudge())
                {
                    case 0:
                        if (Settings.CriticalToggle)
                            GameManager.AutoPlay = GameManager.AutoPlayMode.Critical;
                        break;
                    case 1:
                        if (Settings.PerfectToggle)
                            GameManager.AutoPlay = GameManager.AutoPlayMode.Perfect;
                        break;
                    case 2:
                        if (Settings.GreatToggle)
                            GameManager.AutoPlay = GameManager.AutoPlayMode.Great;
                        break;
                    case 3:
                        if (Settings.GoodToggle)
                            GameManager.AutoPlay = GameManager.AutoPlayMode.Good;
                        break;
                    case 4:
                        if (Settings.MissToggle)
                            GameManager.AutoPlay = GameManager.AutoPlayMode.None;
                        break;
                }
            }
        }
    }
}