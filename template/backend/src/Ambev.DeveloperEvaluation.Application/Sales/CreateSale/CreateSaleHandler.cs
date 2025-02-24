using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;
    private readonly ISaleRepository _saleRepository;
    private readonly IProductsRepository _productsRepository;

    public CreateSaleHandler(ICartRepository cartRepository, IMapper mapper, ISaleRepository saleRepository, IProductsRepository productsRepository)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
        _saleRepository = saleRepository;
        _productsRepository = productsRepository;
    }


    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetCartById(request.CartId);

        var products = await _productsRepository.GetValuesByIds(cart.Items.Select(p => p.ProductId).ToList());

        var sale = _mapper.Map<Domain.Entities.Sales>(request);

        MapSaleItems(cart, products, sale);

        sale.TotalSaleValue = Math.Round(sale.Items.Sum(p => p.TotalItemValue), 2);

        var saleCreated = await _saleRepository.CreateSale(sale);

        if (saleCreated != null)
            return _mapper.Map<CreateSaleResult>(saleCreated);

        else
            throw new InvalidOperationException("Sale not created");
    }

    private void MapSaleItems(Cart cart, List<Product> products, Domain.Entities.Sales sale)
    {
        sale.Items = cart.Items.Select(cartItem =>
        {
           var salesItem = _mapper.Map<SalesItem>(cartItem);
           var product = products.FirstOrDefault(p => p.Id == cartItem.ProductId);
            if (product  != null)
            {
                var identicalItems = cart.Items.Where(i => i.ProductId == cartItem.ProductId).Sum(i => i.Quantity);
                if (identicalItems >= 10)
                {
                    salesItem.Discount = (product.Price * salesItem.Quantity) * 0.20m;
                }
                else if (identicalItems >= 4)
                {
                    salesItem.Discount = (product.Price * salesItem.Quantity) * 0.10m;
                }
                else
                {
                    salesItem.Discount = 0m;
                }
            }
            salesItem.Product = product;
            salesItem.SaleId = sale.Id;
            salesItem.Id = Guid.NewGuid();
            return salesItem;
        }).ToList();
    }

}
