using Microsoft.AspNetCore.Identity;
using NimeniAltii.Models.Account;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NimeniAltiiLab.Repository
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> CreateAsync(ApplicationUserIdentity user,
            CancellationToken cancellationToken);

        public Task<ApplicationUserIdentity> GetByUsernameAsync(string normalizedUsername,
            CancellationToken cancellationToken);
    }
}
