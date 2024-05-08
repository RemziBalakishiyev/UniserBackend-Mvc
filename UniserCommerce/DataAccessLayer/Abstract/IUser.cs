using Entity.Concrete;

namespace DataAccessLayer.Abstract;

public interface IUser
{
    
    Task CreateUser(User user);
    Task<User> GetByUser(string userName);
    //Task SavaeChangesAsync();
}
