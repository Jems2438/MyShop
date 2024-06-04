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

        public ProductListViewModel GetWatchLists(string emailId)
        {

            var customers = customerContext.Collection().FirstOrDefault(x => x.Email == emailId);

            var watchlists = watchListContext.Collection().ToList();
            var productList = productContext.Collection().ToList();

            var products = productList.Where(x => watchlists.Where(y => y.UserId == customers.UserId)
                                      .Select(z => z.ProductId).ToList()
                                      .Contains(x.Id)).ToList();

            ProductListViewModel model = new ProductListViewModel();

            model.Products = products;

            return model;
          
        }
      
        public void AddToWatchList(string Id, string email)
        {
            List<WatchList> watchlists = watchListContext.Collection().ToList();
            Product product = productContext.Find(Id);

            var customers = customerContext.Collection().FirstOrDefault(x => x.Email == email);


            var Available = watchListContext.Collection().Any(x => x.ProductId == Id && x.UserId == customers.UserId);
            if ( !Available )
            {
               var  watchlist = 
                    new  WatchList
                        {
                            ProductId = Id,
                            UserId = customers.UserId
                    };
                watchListContext.Insert(watchlist);
                watchListContext.Commit();
            }

        }

        public void RemoveToWatchList(string Id, string email)
        {
            var  watchlists = watchListContext.Collection().ToList();
            
            var customers = customerContext.Collection().FirstOrDefault(x => x.Email == email);

            var RemoveId = watchlists.FirstOrDefault(x => x.ProductId == Id && x.UserId == customers.UserId);

            if (RemoveId != null)
            {
                var watchlist = RemoveId.Id;
                     
                watchListContext.Delete(watchlist);
                watchListContext.Commit();
            }

        }
    }
}
