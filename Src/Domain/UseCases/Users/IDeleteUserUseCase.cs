namespace concord_users.Src.Domain.UseCases.Users
{
    public interface IDeleteUserUseCase
    {
        public bool Execute(string uuid);
    }
}
