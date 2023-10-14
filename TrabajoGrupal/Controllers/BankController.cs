using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoGrupal.Models;

namespace TrabajoGrupal.Controllers
{
    public class BankController : Controller
    {
        private static List<ClsBank> bankList = new List<ClsBank>();
        private static List<string> _History = new List<string>();
        public bool addErrorTop(List<string> message)
        {

            for (int i = 0; i <= ((message.Count() - 1) >= 9 ? 9 : (message.Count() - 1)); i++)
            {
                ModelState.AddModelError("", message[0]);
            }
            return true;
        }
        

        public ActionResult ProcessTransaction(ClsBank model = null)
        {
            if (Session["UserId"] == null)
            {
                TempData["ErrorMessage"] = "Debe iniciar sesion para acceder a esta pagina";
                return RedirectToAction("Index", "Default");
            }
            if (model != null)
            {
                var result = bankList.FirstOrDefault(b => b.fullNameCustomer != null && model.fullNameCustomer != null && b.fullNameCustomer.Contains(model.fullNameCustomer));
                
                if (result != null)
                {
                    if (model.typeOperation == 0 && model.amount > 0)
                    {
                     
                        result.totalBalance += model.amount;
                        result.depositHistory.Add(model.amount);
                        result.totalDeposit = result.depositHistory.Sum();
                    }
                    else if(model.typeOperation == 1 && result.totalBalance >= model.amount && model.amount > 0)
                    {
                        result.totalBalance -= model.amount;
                        result.withdrawalHistory.Add(model.amount);
                        result.totalWithdrawwal = result.withdrawalHistory.Sum();
                    }
                    else {
                        ModelState.AddModelError("", "El monto es mayor que el saldo");

                        model.totalBalance = result.totalBalance;
                        model.totalDeposit = result.totalDeposit;
                        model.totalWithdrawwal = result.totalWithdrawwal;
                        model.depositHistory = result.depositHistory;
                        model.withdrawalHistory = result.withdrawalHistory;

                        return View(model);
                    }
                    model.totalBalance = result.totalBalance;
                    model.totalDeposit = result.totalDeposit;
                    model.totalWithdrawwal = result.totalWithdrawwal;
                    model.depositHistory = result.depositHistory;
                    model.withdrawalHistory = result.withdrawalHistory;
                    return View(model);
                }
                else
                {
                    if (model.typeOperation == 0 && model.amount > 0)
                    {
                        model.depositHistory.Add(model.amount);
                        model.totalBalance = model.amount;
                        model.totalDeposit = model.amount;
                    }
                    else
                    {
                        if (model.totalBalance <= model.amount && model.amount > 0)
                        {
                            ModelState.AddModelError("", "El monto es mayor que el saldo");
                            return View(model);
                        }
                        model.withdrawalHistory.Add(model.amount);
                        model.totalBalance = -model.amount;
                        model.totalWithdrawwal = -model.amount;
                    }
                    
                    bankList.Add(model);

                    return View(model);
                }
            }
            else
            {
                return View(new ClsBank());
            }
        }
    }
}