using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Contracts
{
    public interface IWatchListService
    {
        List<WatchList> GetWatchLists();

        void AddToWatchList(string Id);
    }
}
