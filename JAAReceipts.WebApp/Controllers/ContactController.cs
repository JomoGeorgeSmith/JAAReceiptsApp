using Invoicer.Helpers;
using JAAReceipts.WebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JAAReceipts.WebApp.Controllers
{
    public class ContactController : Controller
    {
        EmailHelper emailHelper = new EmailHelper();



        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel vm)
        {

            emailHelper.SendFromContactPage(vm.Details, vm.Name, vm.Email);
            return View("ThankYou");
        }
    }
}