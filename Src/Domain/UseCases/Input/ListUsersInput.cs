namespace concord_users.Src.Domain.UseCases.Input
{
    public class ListUsersInput(
        long? id,
        string? uuid,
        string orderBy,
        string sort,
        int pageSize,
        int pageCount
        )
    {
        public long? Id { get; } = id;
        public string? Uuid { get; } = uuid;
        public string OrderBy { get; } = orderBy;
        public string Sort { get; } = sort;
        public int PageSize { get; } = pageSize;
        public int PageCount { get; } = pageCount;
    }
}
