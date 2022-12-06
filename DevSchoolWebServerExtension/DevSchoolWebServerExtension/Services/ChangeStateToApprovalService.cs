using DocsVision.BackOffice.ObjectModel;
using DocsVision.BackOffice.ObjectModel.Services;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevSchoolWebServerExtension.Services
{
    public class ChangeStateToApprovalService : IChangeStateToApprovalService
    {
        public bool ChangeStateToApproval(SessionContext context, Guid cardId)
        {
            var card = context.ObjectContext.GetObject<BaseCard>(cardId);
            IStateService stateService = context.ObjectContext.GetService<IStateService>();
            IList<StatesStateMachineBranch> statesStateMachineBranch = stateService.GetStateMachineBranches(card.SystemInfo.CardKind);

            StatesStateMachineBranch statesStateMachineBranchLines = statesStateMachineBranch.Where(t => t.StartState == card.SystemInfo.State
                 && t.BranchType == StatesStateMachineBranchBranchType.Line
                 && t.EndState.DefaultName.Equals("onApproval")).FirstOrDefault();

            if (statesStateMachineBranchLines != null)
            {
                stateService.ChangeState(card, statesStateMachineBranchLines);
                context.ObjectContext.AcceptChanges();
                return true;
            }
            return false;
        }
    }
}