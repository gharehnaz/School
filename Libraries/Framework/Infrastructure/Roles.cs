namespace Framework.Infrastructure
{
    public static class SystemRoles
    {
        public const string Administrator = "1";
        public const string Manager = "2";
        public const string Teacher = "3";
        public const string ColleagueUser = "10002";

        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیرسیستم";
                case 2:
                    return "مدیر مدرسه";
                case 3:
                    return "معلم";
                default:
                    return "";
            }
        }
    }
}
