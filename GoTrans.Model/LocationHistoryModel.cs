using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace GoTrans.Model
{
    public class LocationHistoryModel
    {
        //public ObjectId  { get; set; }
        public ObjectId _id { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
    }
}
