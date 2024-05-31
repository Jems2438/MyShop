using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class WatchListController : Controller
    {
        IWatchListService WatchListService;

        public WatchListController(IWatchListService watchListService)
        {
            this.WatchListService = watchListService;  
        }
        
        public ActionResult Index()
        {
            
            List<WatchList> watchlists = WatchListService.GetWatchLists();
            return View(watchlists);
        }

        public ActionResult AddToWatchList(string Id )
        {
            WatchListService.AddToWatchList(Id);
            return RedirectToAction("Index");
        }

    }
}