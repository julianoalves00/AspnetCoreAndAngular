using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Constants
    {
        public const string ROLE_MEMBER = "Member";
        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_MODERATOR = "Moderator";

        public const string ADMIN_USER = "admin";
        public const string DEFAULT_PASSWORD = "Test123#";

        public const string POLICY_REQUIRE_ADMIN = "RequireAdminRole";
        public const string POLICY_MODERATE_PHOTO = "ModeratePhotosRole";
}
}
