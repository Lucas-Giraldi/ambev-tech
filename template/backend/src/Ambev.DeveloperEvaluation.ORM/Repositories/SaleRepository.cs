using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using DnsClient.Internal;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Sales> CreateSale(Sales sale)
    {
        try
        {

            sale.Items.ForEach(p => _context.Entry(p.Product).State = EntityState.Unchanged);
            _context.Sales.Add(sale);

            await _context.SaveChangesAsync();

            return sale;
        }
        catch (Exception ex)
        {
            throw;
        }
    }


    public async Task<Sales> GetSale(Guid id)
    {
        return await _context.Sales
            .Include(p => p.Items)
            .ThenInclude(p=>p.Product)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<bool> ModifySale(Sales sale)
    {
        try
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

}
