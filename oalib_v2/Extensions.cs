using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oalib
{
    public static class Extensions
    {
        /// <summary>
        /// Метод расширения проверка наличия работника в списке членов бригады
        /// </summary>
        /// <typeparam name="T">Экземпляр класса Order</typeparam>
        /// <param name="order">Распоряжение</param>
        /// <param name="employ">Работник</param>
        /// <returns>true - если работник уже есть в списке членов бригады, иначе false</returns>
        public static bool WithAtTeam<T>(this T order, Emp employ)
            where T : Order
        {
            
            if (order.teamOrder != null)
            {
                foreach (var emp in order.teamOrder)
                {
                    if (emp.Equals(employ))
                    {
                        return true;
                        
                    }
                }
            }
            return false;
        }
    }
}
