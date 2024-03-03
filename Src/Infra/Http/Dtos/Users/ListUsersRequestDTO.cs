using System.ComponentModel.DataAnnotations;

namespace concord_users.Src.Infra.Http.Dtos.Users
{
    public class ListUsersRequestDTO
    {
        [MinLength(36)]
        public string? Uuid { get; set; }
        [MinLength(2)]
        public string? Login { get; set; }
        [MinLength(2)]
        public string? Email { get; set; }
        public string OrderBy { get; set; } = "id";
        public string Sort { get; set; } = "Desc";
        public int PageSize { get; set; } = 25;
        public int PageCount { get; set; } = 0;

        public override string ToString()
        {
            return $"{{{nameof(Uuid)}={Uuid}, {nameof(Login)}={Login}, {nameof(Email)}={Email}, {nameof(OrderBy)}={OrderBy}, {nameof(Sort)}={Sort}, {nameof(PageSize)}={PageSize}, {nameof(PageCount)}={PageCount}}}";
        }
    }
}
