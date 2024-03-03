using concord_users.Src.Domain.Enums;

namespace concord_users.Src.Domain.UseCases.Users.Input
{
    public class Pagination
    {
        public OrderByEnum OrderBy { get; set; } = OrderByEnum.Desc;
        public string? Sort { get; set; }
        public int PageSize { get; set; } = 25;
        public int PageCount { get; set; } = 0;
    }
}
