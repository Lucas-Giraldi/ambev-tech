using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository
{
    Task<Sales> CreateSale(Sales sale);

    Task<Sales> GetSale(Guid id);  
    
    Task<bool> ModifySale(Sales sale);
}
