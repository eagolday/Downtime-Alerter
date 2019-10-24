using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DowntimeAlerter.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DowntimeAlerter.UI.Controllers
{
    public class BaseController : Controller
    {
        private UserManager<AppUser> _userManager;

        public UserManager<AppUser> UserManager => _userManager ?? (UserManager<AppUser>)HttpContext?.RequestServices.GetService(typeof(UserManager<AppUser>));


        public Guid UserId
        {
            get
            {
                var userId = UserManager.GetUserId(User);

                return userId != null ? Guid.Parse(userId) : new Guid();
            }
        }

    }
}