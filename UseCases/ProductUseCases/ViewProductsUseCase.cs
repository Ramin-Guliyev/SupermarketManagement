using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePlaginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductUseCases
{
    public class ViewProductsUseCase : IViewProductsUseCase
    {
        private readonly IProductRepository productsRepository;

        public ViewProductsUseCase(IProductRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IEnumerable<Product> Execute()
        {
            return productsRepository.GetProducts();
        }
    }
}
