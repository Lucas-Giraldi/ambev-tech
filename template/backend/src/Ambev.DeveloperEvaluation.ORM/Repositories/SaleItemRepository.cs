using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;


public class SaleItemRepository : ISaleItemRepository
{

    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleItemRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleItemRepository(DefaultContext context)
    {
        _context = context;
    }
    public async Task<bool> CancelledItems(List<SalesItem> items)
    {
        try
        {
            foreach (var item in items)
            {
                var existingItem = _context.SalesItem
                    .FirstOrDefault(i => i.Id == item.Id);

                if (existingItem != null)
                {
                    _context.Entry(existingItem).State = EntityState.Detached;
                }

                _context.SalesItem.Update(item);
            }

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }


    public async Task<bool> CreateItems(List<SalesItem> items)
    {
        try
        {
            _context.SalesItem.AddRange(items);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
