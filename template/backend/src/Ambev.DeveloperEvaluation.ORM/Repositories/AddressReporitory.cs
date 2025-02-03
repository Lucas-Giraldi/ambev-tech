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
        public async Task AddOrUpdateAddresses(Guid userId, UserAddress newAddress, CancellationToken cancellationToken)
        {
            try
            {
                var address = await _context.UsersAddress
                    .Where(p => p.User.Id == userId).FirstOrDefaultAsync();

                if (address != null)
                {
                    newAddress.Id = address.Id;
                    newAddress.UserId = userId;
                    _context.Entry(address).CurrentValues.SetValues(newAddress);
                    _context.Entry(address).State = EntityState.Modified;

                }

                else
                {
                    address.UserId = userId;
                    _context.UsersAddress.Add(address);
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
