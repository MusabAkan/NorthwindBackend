﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
 

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = context.OperationClaims
                    .Join(
                        context.UserOperationClaims,
                        operationClaim => operationClaim.Id,
                        userOperationClaim => userOperationClaim.OperationClaimId,
                        (operationClaim, userOperationClaim) => new OperationClaim
                        {
                            Id = operationClaim.Id,
                            Name = operationClaim.Name
                        })
                    .Where(userOperationClaim => userOperationClaim.Id == user.Id)
                    .ToList();

                return result;
            }
        }
    }
}
