using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IAddressReporitory
    {
        Task AddOrUpdateAddresses(Guid userId, UserAddress addresses, CancellationToken cancellationToken);
    }
}
