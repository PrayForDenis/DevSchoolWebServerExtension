using DevSchoolWebServerExtension.Models;
using DevSchoolWebServerExtension.Services;
using DocsVision.Platform.WebClient.Helpers;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocsVision.Platform.WebClient.Models;

namespace DevSchoolWebServerExtension.Controllers
{
    public class TicketPriceFromApiController : Controller
    {
        private readonly ICurrentObjectContextProvider _objectContextProvider;
        private readonly ITicketPriceFromApiService _ticketPriceFromApiService;

        public TicketPriceFromApiController(ICurrentObjectContextProvider objectContextProvider, ITicketPriceFromApiService ticketPriceFromApiService)
        {
            _objectContextProvider = objectContextProvider;
            _ticketPriceFromApiService = ticketPriceFromApiService;
        }

        public ActionResult GetTicketPriceFromAPI(string airportCode, string dateFrom, string dateTo)
        {
            SessionContext sessionContext = _objectContextProvider.GetOrCreateCurrentSessionContext();
            decimal price = _ticketPriceFromApiService.GetTicketPriceFromAPI(sessionContext, airportCode, dateFrom, dateTo);
            return Content(JsonHelper.SerializeToJson(CommonResponse.CreateSuccess(price)));
        }
    }
}