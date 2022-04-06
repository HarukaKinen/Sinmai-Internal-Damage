using MAI2System;

namespace Sinmai.Functions
{
    public class Version
    {
        public static string CheckClientVersion()
        {
            return ConstParameter.GameIDStr + " " + ConstParameter.NowGameVersion;
        }
    }
}
