using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
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
            
            ProductListViewModel OutPut = WatchListService.GetWatchLists(User.Identity.Name);
            return View(OutPut);
        }

        public ActionResult AddToWatchList(string Id )
        {
            WatchListService.AddToWatchList(Id , User.Identity.Name);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveToWatchList(string Id)
        {
            WatchListService.RemoveToWatchList(Id, User.Identity.Name);
            return RedirectToAction("Index");
        }
    }
}