using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Contracts
{
    public interface IWatchListService
    {
        ProductListViewModel GetWatchLists(string Id);

        void AddToWatchList(string Id);
    }
}
