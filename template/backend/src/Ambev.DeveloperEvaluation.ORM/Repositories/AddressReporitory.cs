using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class AddressReporitory : IAddressReporitory
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of UserRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public AddressReporitory(DefaultContext context)
        {
            _context = context;
        }
        public async Task AddOrUpdateAddresses(Guid userId, UserAddress addresses, CancellationToken cancellationToken)
        {
            try
            {
                var addressess = await _context.UsersAddress
                    .Where(p => p.User.Id == userId).FirstOrDefaultAsync();

                if (addressess != null)
                    _context.UsersAddress.Entry(addresses).State = EntityState.Modified;

                else
                {
                    addresses.UserId = userId;
                    _context.UsersAddress.Add(addresses);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
