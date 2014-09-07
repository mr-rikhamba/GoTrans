using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GoTrans.Bll;
using GoTrans.Model;

namespace GoTrans.Server.Controllers.Api
{
    public class LocationHistoryController : ApiController
    {
        LocationHistoryBll bll = new LocationHistoryBll();
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, bll.Get(c=>c.Lat  != null));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public HttpResponseMessage Post(LocationHistoryModel locationHistoryModel)
        {
            try
            {
                var saved = bll.Save(locationHistoryModel);
                return Request.CreateResponse(HttpStatusCode.OK, saved);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
