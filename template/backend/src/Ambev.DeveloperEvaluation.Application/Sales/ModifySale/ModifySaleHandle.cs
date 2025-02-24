using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Application.Sales.ModifySale
{
    public class ModifySaleHandle : IRequestHandler<ModifySaleCommand, ModifySaleResult>
    {

        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly ISaleItemRepository _saleItemRepository;

        public ModifySaleHandle(ICartRepository cartRepository, IMapper mapper, ISaleRepository saleRepository, IProductsRepository productsRepository, ISaleItemRepository saleItemRepository)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _saleRepository = saleRepository;
            _productsRepository = productsRepository;
            _saleItemRepository = saleItemRepository;
        }

        public async Task<ModifySaleResult> Handle(ModifySaleCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartById(request.CartId);

            var products = await _productsRepository.GetValuesByIds(cart.Items.Select(p => p.ProductId).ToList());

            var sale = await _saleRepository.GetSale(request.Id);

            if (sale == null)
                throw new InvalidOperationException("Sale not found");


            var productIds = new HashSet<int>(products.Select(p => p.Id));


            var cancelledItems = sale.Items.Where(s => !productIds.Contains(s.ProductId) && !s.IsCanceled).ToList();


            if (cancelledItems.Any())
            {
                cancelledItems.ForEach(p => p.IsCanceled = true);
                //var resultCancelledItems = await _saleItemRepository.CancelledItems(cancelledItems);



                //if (!resultCancelledItems)
                //{
                //    throw new InvalidOperationException("Sale item not cancelled");
                //}
            }

            ModifySale(cart, sale, products, request);
            
            var result = await _saleRepository.ModifySale(sale);

            if (result )
                return _mapper.Map<ModifySaleResult>(sale);

            else
                throw new InvalidOperationException("Sale or Items not created");
        }

        private void ModifySale(Cart cart, Domain.Entities.Sales sale, List<Product> products, ModifySaleCommand request)
        {
            var existingItems = sale.Items.ToDictionary(i => i.ProductId);
            foreach (var cartItem in cart.Items)
            {
                var product = products.FirstOrDefault(p => p.Id == cartItem.ProductId);
                if (product == null)
                    continue;

                if (existingItems.TryGetValue(cartItem.ProductId, out var salesItem))
                {
                    salesItem.Quantity = cartItem.Quantity;
                }
                else
                {
                    salesItem = _mapper.Map<SalesItem>(cartItem);
                    salesItem.SaleId = sale.Id;
                    sale.Items.Add(salesItem);
                }

                salesItem.Product = product;

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

            sale.CustomerName = request.CustomerName;
            sale.Branch = request.Branch;
            sale.IsCanceled = request.IsCanceled;
            sale.TotalSaleValue = Math.Round(sale.Items.Sum(p => p.TotalItemValue), 2);

            
        }


    }
}
