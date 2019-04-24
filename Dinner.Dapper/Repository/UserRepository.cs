using Dapper;
using Dinner.Dapper.Entities;
using Dinner.Dapper.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Dapper.Repository
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        public async Task DeleteUser(Guid id)
        {
            string deleteSql = "DELETE FROM [dbo].[Users] WHERE Id = @id";
            await Delete(id, deleteSql);
        }

        public string ExecQueryParamSP(string spName, string name, int id)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", name, DbType.String, ParameterDirection.Output, 100);
                parameters.Add("@Id", id, DbType.String, ParameterDirection.Input);
                conn.Execute(spName, parameters, null, null, CommandType.StoredProcedure);
                string strUserName = parameters.Get<string>("@UserName");
                return strUserName;
            }
        }

        public async Task<Users> GetUserDetail(Guid id)
        {
            string detailSql = @"SELECT Id,UserName,Password,Gender,Birthday,CreateDate,IsDelete FROM [dbo].[Users]";
            return await Detail(id, detailSql);
        }

        public async Task<List<Users>> GetUsers()
        {
            string selectSql = @"SELECT Id,UserName,Password,Gender,Birthday,CreateDate,IsDelete FROM [dbo].[Users]";
            return await Select(selectSql);
        }

        public async Task PostUser(Users entity)
        {
            string insertSql = @"INSERT INTO [dbo].[Users](Id,UserName,Password,Gender,Birthday,CreateDate,IsDelete) VALUES(@Id,@UserName,@Password,@Gender,@Birthday,@CreateDate,@IsDelete)";
            await Insert(entity, insertSql);
        }

        public async Task PutUser(Users entity)
        {
            string updateSql = "UPDATE [dbo].[Users] SET UserName=@UserName,Password=@Password,Gender=@Gender,Birthday=@Birthday,CreateDate=@CreateDate,IsDelete=@IsDelete WHERE Id=@Id";
            await Update(entity, updateSql);
        }
    }
}
