using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dinner.Dapper.Entities;
using Dinner.Dapper.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetUsers()
        {
            List<Users> list = await _userRepository.GetUsers();
            return Json(list);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task PostUser(Users entity)
        {
            entity.Password = Dapper.Helpers.Encrypt.Md5(entity.Password).ToUpper();
            await _userRepository.PostUser(entity);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task PutUser(Users entity)
        {
            try
            {
                entity.Password = Dapper.Helpers.Encrypt.Md5(entity.Password).ToUpper();
                await _userRepository.PutUser(entity);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task DeleteUser(Guid id)
        {
            try
            {
                await _userRepository.DeleteUser(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}