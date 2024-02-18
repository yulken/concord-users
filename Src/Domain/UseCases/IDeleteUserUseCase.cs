namespace concord_users.Src.Domain.UseCases
{
    public interface IDeleteUserUseCase
    {
        public bool Execute(string uuid);
    }
}
