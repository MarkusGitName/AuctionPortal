using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using AuctionPortal.Models;

namespace AuctionPortal.Models
{
    public class AuctionViewModel
    {
        public EditAuctionModel Auction { get; set; }
        public newAddProppertyViewModel property { get; set; }
        public string user { get; set; }
        public DataTable Paths
        {
            get;set;

        }


    }
}