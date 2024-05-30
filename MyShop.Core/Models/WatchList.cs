using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class WatchList : BaseEntity
    {
        public string UserId { get; set; }

        public string ProductId { get; set; }

    }
}
