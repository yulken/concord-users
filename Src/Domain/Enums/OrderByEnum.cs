namespace concord_users.Src.Domain.Enums
{
    public enum OrderByEnum
    {
        Asc,
        Desc
    }

    public class OrderByEnumUtil
    {
        public static readonly Dictionary<string, OrderByEnum> Dict = new()
        {
            { "Desc", OrderByEnum.Desc},
            { "Asc", OrderByEnum.Asc}
        };

        public static OrderByEnum Get(string str)
        {
            return Dict.GetValueOrDefault(str);
        }
    }
}
