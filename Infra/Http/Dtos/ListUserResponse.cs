using concord_users.Domain.Entities;
using System;

namespace concord_users.Infra.Http.Dtos
{
    public class ListUserResponse(List<User> users)
    {
        public List<User> Users { get; set; } = users;
    }
}
