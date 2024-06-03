using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;

namespace MyShop.Services
{
    public class WatchListService : IWatchListService
    {
        IRepository<Product> productContext;
        IRepository<WatchList> watchListContext;
        IRepository<Customer> customerContext;
     

        public WatchListService(IRepository<Product> ProductContext, IRepository<WatchList> WatchList, IRepository<Customer> Customers)
        {
            this.productContext = ProductContext;
            this.watchListContext = WatchList;
            this.customerContext = Customers;
        }

        public ProductListViewModel GetWatchLists(string Id)
        {
            List<Product> products;
            products = productContext.Collection().ToList();

            ProductListViewModel model = new ProductListViewModel();

            List<WatchList> watchlists = watchListContext.Collection().ToList();

            var whistlist = watchListContext.Collection().Where(x => x.UserId == Id);

            var ListOfProduct = whistlist.Select(x => x.ProductId );

            var result =   (from p in products
                           join q in whistlist on p.Id equals q.ProductId
                           select new Product
                           {
                                Id = p.Id,
                                Name = p.Name,
                                Image = p.Image,
                                Price = p.Price

                           }
                           ).ToList();

            model.Products = result;

            return model;
          
        }
      
        public void AddToWatchList(string Id)
        {
            List<WatchList> watchlists = watchListContext.Collection().ToList();
            Product product = productContext.Find(Id);

            var Available = watchListContext.Collection().Any(x => x.ProductId == Id );
            if ( !Available )
            {
               var  watchlist = 
                    new  WatchList
                        {
                            ProductId = Id,
                            UserId = Id
                        };
                watchListContext.Insert(watchlist);
                watchListContext.Commit();
            }

        }
    }
}
