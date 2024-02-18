using Microsoft.OpenApi.Extensions;
using Mysqlx.Crud;
using System;
using System.Linq;

namespace concord_users.Src.Domain.Enums
{
    public class UserStatusStruct(string name, string shortName)
    {
        public string Name { get; } = name;
        public string ShortName { get; } = shortName;
    }

    public enum UserStatus
    {
        Active,
        Deleted,
        PendingEmail
    }

    public class UserStatusConverter
    {
        public static readonly Dictionary<UserStatus, UserStatusStruct> Dict = new()
        {
            { UserStatus.Active, new UserStatusStruct("Active", "A") },
            { UserStatus.Deleted,new UserStatusStruct("Deleted", "D") }
        };

        public static UserStatus ShortStringToEnum(string str)
        {
            return Dict.Where(entry => entry.Value.ShortName == str).First().Key;
        }

        public static string GetShortValue(UserStatus en)
        {
            return Dict[en].ShortName;
        }

        public static string GetName(UserStatus en)
        {
            return Dict[en].Name;
        }
    }

}
