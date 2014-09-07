using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using GoTrans.Bll;
using GoTrans.Model;
using Microsoft.AspNet.SignalR;

namespace GoTrans.Server.Hubs
{
    public class LocationsHub : Hub
    {
        LocationHistoryBll bll = new LocationHistoryBll();
        List<string> x = new List<string>();
        public void Hello(string id, string message)
        {
            Clients.All.pushIds(id);
            if (!x.Contains(id))
            {
                x.Add(id);
            }
            foreach (var item in x)
            {
                Clients.Client(item).hello(message);
            }
        }

        public void UpdateCoordinates(string lat, string lon)
        {
            try
            {
                bll.Save(new LocationHistoryModel()
        {
            Lat = lat,
            Lon = lon
        });
            }
            catch (Exception ex)
            {



            }

            Clients.All.updateCoordinates(lat, lon);
        }
    }
}