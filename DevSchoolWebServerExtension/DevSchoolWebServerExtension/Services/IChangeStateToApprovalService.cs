using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSchoolWebServerExtension.Services
{
    public interface IChangeStateToApprovalService
    {
        /// <summary>
        /// Изменение состояния карточки "Проект" -> "На согласование"
        /// </summary>
        /// <param name="context">Контекст ВК</param>
        /// <param name="cardId">Id карточки</param>
        /// <returns></returns>
        bool ChangeStateToApproval(SessionContext context, Guid cardId);
    }
}
