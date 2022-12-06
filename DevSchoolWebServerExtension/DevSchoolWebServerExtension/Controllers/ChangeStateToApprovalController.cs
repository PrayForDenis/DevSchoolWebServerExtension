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
    public class ChangeStateToApprovalController : Controller
    {
        private readonly ICurrentObjectContextProvider _objectContextProvider;
        private readonly IChangeStateToApprovalService _changeStateToApprovalService;

        public ChangeStateToApprovalController(ICurrentObjectContextProvider objectContextProvider, IChangeStateToApprovalService changeStateToApprovalService)
        {
            _objectContextProvider = objectContextProvider;
            _changeStateToApprovalService = changeStateToApprovalService;
        }

        public ActionResult ChangeStateToApproval(Guid cardId)
        {
            SessionContext sessionContext = _objectContextProvider.GetOrCreateCurrentSessionContext();
            bool isStateChanged = _changeStateToApprovalService.ChangeStateToApproval(sessionContext, cardId);
            return Content(JsonHelper.SerializeToJson(CommonResponse.CreateSuccess(isStateChanged)));
        }
    }
}