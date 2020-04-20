using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using AuctionPortal.Controllers;


namespace AuctionPortal.Hubs
{
    [HubName("auctionHub")]
    public class AuctionHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage2(name, message);
        }
        public static double hiegestBidd = 0;
        public static string Name = "";
        
        public void Bid2(string name, double bid, int auctionID, string userID)
        {
            // Call the broadcastMessage method to update clients.
            if(bid> hiegestBidd)
            {
                hiegestBidd = bid;
                Name = name;
                Clients.All.broadcastMessage(name, bid);
                DataController.PlaceBid(auctionID,userID,bid);
            }
            else
            {
                return;
            }
        }
        public void getName()
        {
            Clients.All.broadcastMessage(Name);
        }
        public double getBid()
        {
            return hiegestBidd;
        }
        public void Bid(string name, double bid, double current)
        {
            // Call the broadcastMessage method to update clients.
            current += bid;
            Clients.All.broadcastMessage(name, current);
        }

       

    }
}