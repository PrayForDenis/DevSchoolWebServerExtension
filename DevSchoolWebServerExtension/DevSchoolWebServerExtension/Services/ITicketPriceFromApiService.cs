using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSchoolWebServerExtension.Services
{
    public interface ITicketPriceFromApiService
    {
        /// <summary>
        /// Получение стоимости билетов туда-обратно для командировки
        /// </summary>
        /// <param name="context">Контекст ВК</param>
        /// <param name="airportCode">Код аэропорта</param>
        /// <param name="dateFrom">Дата от</param>
        /// <param name="dateTo">Дата по</param>
        /// <returns></returns>
        decimal GetTicketPriceFromAPI(SessionContext context, string airportCode, string dateFrom, string dateTo);
    }
}
