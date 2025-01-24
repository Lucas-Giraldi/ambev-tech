﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;
public class GetProductCommand : IRequest<GetProductResult>
{
    public int Id { get; set; }

    public GetProductCommand(int id)
    {
        Id = id;
    }
}
