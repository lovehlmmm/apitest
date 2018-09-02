using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Helper;
using Models;
using POPAPI.Models;
using Repositories;
using Services;

namespace POPAPI.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IBaseRepository<User> _repositoryUser;
        private readonly IUserService _userService;

        public LoginController(IBaseRepository<User> repositoryUser)
        {
            _repositoryUser = repositoryUser;
            _userService = new UserService(repositoryUser);
        }
        // GET api/values 
        [System.Web.Http.Authorize(Roles = "admin")]
        public HttpResponseMessage Post([FromBody] UserModel model)
        {
            try
            {
                User user = _userService.CheckLogin(model.Username, model.Password);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception e)
            {

            }   
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Bab Request");
        }
    }
}
