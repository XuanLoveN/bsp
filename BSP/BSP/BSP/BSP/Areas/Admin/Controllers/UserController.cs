using BSP.Controllers;
using BSP.Filters;
using BSP.Model;
using BSP.Mvc;
using BSP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSP.Areas.Admin.Controllers
{
    [Authorize, AdminAuthorization]
    public class UserController : _BaseController
    {
        public ActionResult List()
        {
            var model = base.Facade.User.GetAllUsers();
            UserTicket ticket = UserTicketManager.CurrentUserTicket;
            return View(model.Where(c => c.Id != ticket.ID).ToList<User>());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = base.Facade.User.GetUserById(id);
            return View(model);
        }

        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {

            }

            return View(user);
        }

        public ActionResult ListStates()
        {
            var model = base.Facade.User.GetAllUsers();
            UserTicket ticket = UserTicketManager.CurrentUserTicket;
            return View(model.Where(c => c.Id != ticket.ID).ToList<User>());
            //var userState = base.Facade.User.GetAllUserStates();
            
            //foreach (var usermodel in userModel)
            //{
            //    usermodel.UserState = userState.FirstOrDefault(r=>r.Id==usermodel.UserStateId);
            //    //var id = usermodel.UserStateId;     
            //    //foreach (var userstate in userState)
            //    //{
            //    //    if (id==userstate.Id)
            //    //    {
            //    //        usermodel.UserState.Id = userstate.Id;
            //    //        usermodel.UserState.Name = userstate.Name;
            //    //    }
            //    //}
            //}
            //return View();
        }
        public ActionResult UserStateListItem(User user)
        {
            UserStateListViewModel model = new UserStateListViewModel();
            model.User = user;
            model.Roles = new SelectList(base.Facade.UserRole.GetAllUserRole(),"Id","Name",user.UserRoleId);
            model.States = new SelectList(base.Facade.UserStates.GetAllUserState(), "Id", "Name", user.UserRoleId);
            return PartialView("_UserStateListItem",model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveUserStateAndRole(User user)
        {
            return View();
        }
    }
}