﻿using System;
using DotNetBackendTemplate.Core.DataAccess.EntityFramework;
using DotNetBackendTemplate.Core.Entities.Concrete;
using DotNetBackendTemplate.Core.Entities.DTOs;
using DotNetBackendTemplate.DataAccess.Abstract;

namespace DotNetBackendTemplate.DataAccess.Concrete.EntityFramework
{
    public class EfAccountDal : EfEntityRepositoryBase<Account, BaseDbContext>, IAccountDal
    {
        public List<AccountOperationClaimDetailDto> GetClaims(Account account)
        {
            using (var context = new BaseDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join accountOperationClaim in context.AccountOperationClaims
                             on operationClaim.Id equals accountOperationClaim.OperationClaimId
                             where accountOperationClaim.AccountId == account.Id
                             select new AccountOperationClaimDetailDto { OperationClaimId = operationClaim.Id, OperationClaimName = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}

