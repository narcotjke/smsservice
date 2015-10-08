using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using UI.Models.RoleModels;

namespace UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        private SmsServiceRoleManager RoleManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<SmsServiceRoleManager>(); }
        }

        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateRoleModel role)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateRoleModel, SmsServiceRole>();
                IdentityResult result = await RoleManager.CreateAsync(Mapper.Map<CreateRoleModel, SmsServiceRole>(role));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(String.Empty, "Ошибка сохранения роли");
            }

            return View(role);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(String id)
        {
            SmsServiceRole role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                Mapper.CreateMap<SmsServiceRole, EditRoleModel>();

                return View(Mapper.Map<SmsServiceRole, EditRoleModel>(role));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditRoleModel model)
        {
            if (ModelState.IsValid)
            {
                SmsServiceRole role = await RoleManager.FindByIdAsync(model.Id);
                if (role != null)
                {
                    role.Description = model.Description;
                    role.Name = model.Name;

                    IdentityResult result = await RoleManager.UpdateAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                    ModelState.AddModelError(String.Empty, "Не удалось обновить роль");
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(String id)
        {
            SmsServiceRole role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                await RoleManager.DeleteAsync(role);
            }

            return RedirectToAction("Index");
        }
    }
}