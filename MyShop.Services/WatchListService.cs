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
        IRepository<WatchList> watchList;

        public WatchListService(IRepository<Product> ProductContext, IRepository<WatchList> WatchList)
        {
            this.productContext = ProductContext;
            this.watchList = WatchList;
        }

        public List<WatchList> GetWatchLists()
        {
            List<WatchList> watchlists = watchList.Collection().ToList();
            return watchlists;
        }

        public void AddToWatchList(string Id)
        {
            List<WatchList> watchlists = watchList.Collection().ToList();
            Product product = productContext.Find(Id);

            if (watchList != product)
            {
                watchlists.Add(
                        new WatchList()
                        {
                            ProductId = Id,
                            UserId = Id
                        }       
                    );
            }
        }
    }
}
