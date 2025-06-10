namespace BRS.Basecode.Resources.Constants
{
    public static class Common
    {
        public static class Route
        {
            public const string BASE = "api/[controller]";
            public const string ID = "{id}";
            public const string CREATE = "create";
            public const string UPDATE = "update";
            public const string UPDATE_PIN = "updatepin";
        }

        public static class Messages
        {
            public const string USER_NOT_FOUND = "User not found";
            public const string USER_CREATED = "User successfully created.";
            public const string USER_UPDATED = "User successfully updated.";
            public static string USER_ID_EXISTS(int userId) => $"User with UserID `{userId}` already exists";
            public static string USER_ID_NOT_EXISTS(int userId) => $"User with UserID `{userId}` does not exists.";
        }

    }
}
