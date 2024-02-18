namespace concord_users.Src.Infra.Http.Dtos
{
    public class ListUsersRequestDTO
    {
        public long? Id {  get; set; }
        public string? Uuid { get; set; }
        public string OrderBy { get; set; } = "id";
        public string Sort { get; set; } = "DESC";
        public int PageSize { get; set; } = 25;
        public int PageCount { get; set; } = 0;
    }
}
