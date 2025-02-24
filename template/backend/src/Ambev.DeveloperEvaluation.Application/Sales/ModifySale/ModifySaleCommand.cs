using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.ModifySale
{
    public class ModifySaleCommand : IRequest<ModifySaleResult>
    {
        public Guid Id { get; set; }
        public string CartId { get; set; }
        public string CustomerName { get; set; }
        public string Branch { get; set; }
        public bool IsCanceled { get; set; }
    }
}
