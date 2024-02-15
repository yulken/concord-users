using concord_users.Src.Domain.Entities;
using System;

namespace concord_users.Src.Infra.Http.Dtos
{
    public class ListUserResponse(List<User> users)
    {
        public List<User> Users { get; set; } = users;
    }
}
