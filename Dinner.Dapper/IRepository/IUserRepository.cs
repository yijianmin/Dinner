using Dinner.Dapper.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Dapper.IRepository
{
    public interface IUserRepository : IRepositoryBase<Users>
    {
        #region 扩展的dapper操作

        //加一个带参数的存储过程
        string ExecQueryParamSP(string spName, string name, int id);

        Task<List<Users>> GetUsers();

        Task PostUser(Users entity);

        Task PutUser(Users entity);

        Task DeleteUser(Guid id);

        Task<Users> GetUserDetail(Guid id);

        #endregion

    }
}
