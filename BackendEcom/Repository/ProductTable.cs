using BackendEcom.IRepository;
using BackendEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendEcom.Repository
{
    public class ProductTable : ProductInterface
    {
        string str = string.Empty;
        private readonly Demo_ProjectContext context;
        public ProductTable(Demo_ProjectContext _context)
        {
            context = _context;
        }
        public IEnumerable<Models.ProductList> GetProducts()
        {
            var response = (from prod in context.Product
                            join pv in context.ProductVariation on prod.ProductId equals pv.ProductId
                            join pr in context.ProductReview on prod.ProductId equals pr.ProductId
                            select new Models.ProductList
                            {
                                ProductId = prod.ProductId,
                                PName = prod.PName,
                                PDescription = prod.PDescription,
                                IsCancelable = prod.IsCancelable,
                                IsReturnable = prod.IsReturnable,
                                Brand = prod.Brand,
                                ProductVariationId = pv.ProductVariationId,
                                QunatityAvailable = pv.QunatityAvailable,
                                Price = pv.Price,
                                VariationMetadata = pv.VariationMetadata,
                                PrimaryImageName = pv.PrimaryImageName,
                                Review = pr.Review,
                                Rating = pr.Rating
                            }).ToList();


            return response;
        }
    }
}
