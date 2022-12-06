using DocsVision.Platform.ObjectManager;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DevSchoolWebServerExtension.Services
{
    public class TicketPriceFromApiService : ITicketPriceFromApiService
    {
        public decimal GetTicketPriceFromAPI(SessionContext context, string airportCode, string dateFrom, string dateTo)
        {
            DateTime from = DateTime.Parse(dateFrom);
            DateTime to = DateTime.Parse(dateTo);

            ExtensionMethod method = context.Session.ExtensionManager.GetExtensionMethod("DevSchoolServerExtension", "GetTicketsPrice");
            method.Parameters.AddNew("airportCode", ParameterValueType.String, airportCode);
            method.Parameters.AddNew("dateFrom", ParameterValueType.DateTime, from);
            method.Parameters.AddNew("dateTo", ParameterValueType.DateTime, to);

            string priceString = method.Execute().ToString();
            decimal price = decimal.Parse(priceString, CultureInfo.InvariantCulture);
            return price;
        }
    }
}