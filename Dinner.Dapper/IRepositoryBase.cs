using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Dapper
{
    public interface IRepositoryBase<T>
    {
        Task Insert(T entity, string insertSql);

        Task Update(T entity, string updateSql);

        Task Delete(Guid id, string deleteSql);

        Task<List<T>> Select(string selectSql);

        Task<T> Detail(Guid id, string detailSql);

        /// <summary>
        /// 无参存储过程
        /// </summary>
        /// <param name="SPName"></param>
        /// <returns></returns>
        Task<List<T>> ExecQuerySP(string SPName);
    }
}
