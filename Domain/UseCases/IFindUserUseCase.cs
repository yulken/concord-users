﻿using concord_users.Domain.Entities;

namespace concord_users.Domain.UseCases
{
    public interface IFindUserUseCase
    {
        public User? Execute(long id);
    }
}
