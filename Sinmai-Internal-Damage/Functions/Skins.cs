using MAI2.Util;
using Manager;
using Manager.MaiStudio;
using Sinmai.Helper;
using System.Globalization;
using System.Reflection;
using UnityEngine;


namespace Sinmai.Functions
{
    public class Skins
    {
        private const BindingFlags pBindFlags = BindingFlags.NonPublic;
        private const BindingFlags iBindFlags = BindingFlags.Instance;
        private const BindingFlags sBindFlags = BindingFlags.Static;

        public static TitleData title = GetTitle(int.Parse(Settings.TitleIndexOriginal));

        public static Sprite titleBg = Resources.Load<Sprite>("Process/Common/Sprites/UpperMonitor/UI_CMN_Shougou_" + Settings.TitleType);
        public static Sprite pass = Resources.Load<Sprite>("Process/Common/Sprites/UpperMonitor/UI_CMN_DXPass_" + Settings.DXPassType);
        public static string userName = Settings.NameValue;
        
        private static UserInformationController getUserInformationController()
        {
            UserInformationController UserInformationController = GameObject
                .Find("Sub/UI_UserInformation/UI_UserData/")
                .GetComponent<UserInformationController>();

            return UserInformationController;
        }

        // public static void NameChanger()
        // {
        //     if (!Settings.NameCheckBox) return;
        //
        //     UserInformationController UserInformationController = getUserInformationController();
        //
        //     if (UserInformationController != null)
        //     {
        //         UserInformationController.userNameText.text = userName;
        //     }
        // }

        public static void RateChanger()
        {
            if (!Settings.RateCheckBox) return;

            UserInformationController UserInformationController = getUserInformationController();

            var rate = uint.Parse(Settings.RatingValue, NumberStyles.Integer);

            if (UserInformationController != null)
            {
                UserInformationController.SetUserRating(rate);
            }
        }

        public static void UdemaeChanger()
        {
            if (!Settings.UdemaeCheckBox) return;

            UserInformationController UserInformationController = getUserInformationController();

            int udemaeId = int.Parse(Settings.UdemaeIndex);

            var udemae = (UdemaeID)udemaeId;

            if (UserInformationController != null)
            {
                UserInformationController.SetUdemae(udemae);
            }
        }

        public static void IconChanger()
        {
            if (!Settings.IconCheckBox) return;

            UserInformationController UserInformationController = getUserInformationController();

            Texture2D iconTexture2D = AssetManager.Instance().GetIconTexture2D(0, int.Parse(Settings.IconIndex));

            if (UserInformationController != null)
            {
                UserInformationController.SetUserIcon(iconTexture2D);
            }
        }

        public static void PlateChanger()
        {
            if (!Settings.PlateCheckBox) return;

            UserInformationController UserInformationController = getUserInformationController();

            Texture2D plateTexture2D = AssetManager.Instance().GetPlateTexture2D(int.Parse(Settings.PlateIndex));

            if (UserInformationController != null)
            {
                UserInformationController.SetNamePlate(plateTexture2D);
            }
        }

        public static void TitleChanger()
        {
            if (!Settings.TitleCheckBox) return;

            UserInformationController UserInformationController = getUserInformationController();

            if (UserInformationController != null)
            {
                //TitleData title = GetTitle(int.Parse(Settings.TitleValueOriginal));
                if (Settings.TitleMethodInt == 0)
                {
                    UserInformationController.SetTitle(title.name.str, titleBg);
                }
                else if (Settings.TitleMethodInt == 1)
                {
                    UserInformationController.SetTitle(Settings.TitleIndexCustom, titleBg);
                }

            }
        }

        public static void DXPassChanger()
        {
            if (!Settings.DXPassCheckBox) return;

            UserInformationController UserInformationController = getUserInformationController();

            if (UserInformationController != null)
            {
                UserInformationController.SetPass(pass);
            }
        }

        public static TitleData GetTitle(int id)
        {
            return Singleton<DataManager>.Instance.GetTitle(id);
        }
    }
}