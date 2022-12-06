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
using System.Web.Http;
using DocsVision.Platform.WebClient.Models.Generic;

namespace DevSchoolWebServerExtension.Controllers
{
    public class CustomDirectoryDesignerRowController : Controller
    {
        private readonly ICurrentObjectContextProvider _objectContextProvider;
        private readonly ICustomDirectoryDesignerRowService _directoryDesignerRowService;

        public CustomDirectoryDesignerRowController(ICurrentObjectContextProvider objectContextProvider, ICustomDirectoryDesignerRowService directoryDesignerRowService)
        {
            _objectContextProvider = objectContextProvider;
            _directoryDesignerRowService = directoryDesignerRowService;
        }

        public ActionResult GetDirectoryDesignerRowData(Guid cityId)
        {
            SessionContext sessionContext = _objectContextProvider.GetOrCreateCurrentSessionContext();
            CustomDirectoryDesignerRowData model = _directoryDesignerRowService.GetDirectoryDesignerRowData(sessionContext, cityId);
            return Content(JsonHelper.SerializeToJson(CommonResponse.CreateSuccess(model)));
        }
    }
}