using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Contracts;
using MyShop.Core.Models;

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

        public List<WatchList> GetWatchLists()
        {
            List<WatchList> watchlists = watchListContext.Collection().ToList();
            return watchlists;
        }
        public List<Product> ShowProduct(string Id)
        {
            List<Product> tempData = productContext.Collection().ToList();
            Product product = productContext.Find(Id);

            List<WatchList> watchlists = watchListContext.Collection().ToList();
            var Available = watchListContext.Collection().Any(x => x.ProductId == Id);
            if (!Available)
            {
               
            }
            else
            {
                               
            }
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
