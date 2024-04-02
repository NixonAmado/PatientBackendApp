using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Interfaces;
public interface IUser : IGenericRepository<User>
    {    
        Task<User> GetByUserNameAsync(string name);
        Task<User> GetByRefreshTokenAsync(string refreshToken);
    
    }
