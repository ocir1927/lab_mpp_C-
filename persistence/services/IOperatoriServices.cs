namespace persistence.services
{
    public interface IOperatoriServices<E>
    {
        E FindByUsername(string username);
        E Login(string username, string password);
    }
}
