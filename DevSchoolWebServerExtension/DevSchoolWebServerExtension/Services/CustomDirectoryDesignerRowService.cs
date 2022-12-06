using DevSchoolWebServerExtension.Models;
using DocsVision.BackOffice.ObjectModel;
using DocsVision.BackOffice.WebClient.Department;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevSchoolWebServerExtension.Services
{
    public class CustomDirectoryDesignerRowService : ICustomDirectoryDesignerRowService
    {
        public CustomDirectoryDesignerRowData GetDirectoryDesignerRowData(SessionContext context, Guid rowId)
        {
            BaseUniversalItem cityItem = context.ObjectContext.GetObject<BaseUniversalItem>(rowId);
            if (cityItem == null) { return null; }
            CustomDirectoryDesignerRowData model = new CustomDirectoryDesignerRowData()
            {
                Name = cityItem.Name,
                Description = cityItem.Description,
                AirportCode = cityItem.ItemCard.MainInfo["airportCode"] + ""
            };
            decimal dailyAmount;
            if (decimal.TryParse(cityItem.ItemCard.MainInfo["dailyAmount"] + "", out dailyAmount))
                model.DailyAmount = dailyAmount;
            else
                model.DailyAmount = 0;
            return model;
        }
    }
}