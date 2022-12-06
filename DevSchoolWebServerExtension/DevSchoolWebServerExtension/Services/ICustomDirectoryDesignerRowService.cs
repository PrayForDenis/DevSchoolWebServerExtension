using DevSchoolWebServerExtension.Models;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSchoolWebServerExtension.Services
{
    public interface ICustomDirectoryDesignerRowService
    {
        /// <summary>
        /// Получение расширенной информации о строке конструктора справочника (узел Города)
        /// </summary>
        /// <param name="context">Контекст ВК</param>
        /// <param name="cityId">Id строки</param>
        /// <returns></returns>
        CustomDirectoryDesignerRowData GetDirectoryDesignerRowData(SessionContext context, Guid cityId);
    }
}
