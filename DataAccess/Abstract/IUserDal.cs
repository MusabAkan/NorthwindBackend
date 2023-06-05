using Core.Entities;
using Entities.Concrete;
using Core.DataAccess;
namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);

    }
}
