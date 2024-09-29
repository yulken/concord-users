namespace concord_users.Src.Domain.Enums
{
    public class FriendshipStatusStruct(string name, string shortName)
    {
        public string Name { get; } = name;
        public string ShortName { get; } = shortName;
    }

    public enum FriendshipStatus
    {
        Active,
        Deleted,
        Pending
    }

    public class FriendshipStatusUtil
    {
        public static readonly Dictionary<FriendshipStatus, FriendshipStatusStruct> Dict = new()
        {
            { FriendshipStatus.Active, new FriendshipStatusStruct("Active", "A") },
            { FriendshipStatus.Pending, new FriendshipStatusStruct("Pending", "") },
            { FriendshipStatus.Deleted,new FriendshipStatusStruct("Deleted", "D") }
        };

        public static FriendshipStatus ShortStringToEnum(string str)
        {
            return Dict.Where(entry => entry.Value.ShortName == str).First().Key;
        }

        public static string GetShortValue(FriendshipStatus en)
        {
            return Dict[en].ShortName;
        }

        public static string GetName(FriendshipStatus en)
        {
            return Dict[en].Name;
        }
    }

}
