namespace Sinmai.Helper
{
    class Settings
    {
        public static int MainToolbarInt = 0;
        public static string[] MainToolbarStrings = { "Legit", "Skins", "Misc" };


        // Legit Autoplay
        public static bool LegitAutoPlayCheckBox = false;
        public static int LegitMethodInt = 0;
        public static string[] LegitMethod = {"Opposite", "Random Cycle", "Force Random"};
        public static float CriticalValue = 100.0f;
        public static float PerfectValue = 0.0f;
        public static float GreatValue = 0.0f;
        public static float GoodValue = 0.0f;
        public static float MissValue = 0.0f;

        public static bool CriticalToggle = true;
        public static bool PerfectToggle = false;
        public static bool GreatToggle = false;
        public static bool GoodToggle = false;
        public static bool MissToggle = false;
        

        // Rage Autoplay

        // Some cool part idk

        // Skin Changer
        public static bool RateCheckBox = false;
        public static string RatingValue = "13370";
        public static bool UdemaeCheckBox = false;
        public static string UdemaeValue = "24";
        public static bool PlateCheckBox = false;
        public static bool FrameCheckBox = false;
        public static bool TitleCheckBox = false;
        public static int TitleMethodInt = 0;
        public static string[] TitleMethod = { "Original", "Custom" };
        public static string TitleValueOriginal = "1";
        public static string TitleValueCustom = "skeet.cc";
        public static string TitleType = "Rainbow";
        public static bool DXPassCheckBox = false;
        
        // Misc
        public static bool InfinityFreedomTimeCheckBox = false;
        public static bool InfinityPrepareTimeCheckBox = false;

    }
}
