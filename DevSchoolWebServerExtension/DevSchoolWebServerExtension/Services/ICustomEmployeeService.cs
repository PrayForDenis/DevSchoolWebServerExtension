using DevSchoolWebServerExtension.Models;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSchoolWebServerExtension.Services
{
    public interface ICustomEmployeeService
    {
        /// <summary>
        /// Получение расширенной информации о сотруднике
        /// </summary>
        /// <param name="context">Контекст ВК</param>
        /// <param name="employeeId">Id сотрудника</param>
        /// <returns></returns>
        CustomEmployeeData GetEmployeeData(SessionContext context, Guid employeeId);
    }
}
