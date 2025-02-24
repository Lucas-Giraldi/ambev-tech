using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleItemRepository
{
    Task<bool> CancelledItems(List<SalesItem> items);

    Task<bool> CreateItems(List<SalesItem> items);
}
