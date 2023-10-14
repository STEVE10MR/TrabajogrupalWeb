using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoGrupal.Models;

namespace TrabajoGrupal.Controllers
{
    public class WarCasinoController : Controller
    {
   
        private static Random random = new Random();

        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                TempData["ErrorMessage"] = "Debe iniciar sesion para acceder a esta pagina";
                return RedirectToAction("Index", "Default");
            }
            var model = new ClsWarCasino
            {
                PlayerCards = new List<int> { },
                DealerCards = new List<int> { },
                PlayerScore = 0,
                DealerScore = 0,
                Result = "",
                IsWar = false,
                WarCards = new List<int> { }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Play(ClsWarCasino model)
        {
            if (model == null)
            {
                model = new ClsWarCasino();
            }

            if (model.PlayerCards == null)
            {
                model.PlayerCards = new List<int>();
            }

            if (model.DealerCards == null)
            {
                model.DealerCards = new List<int>();
            }

            if (Session["PlayerScore"] == null)
            {
                Session["PlayerScore"] = 0;
            }

            if (Session["DealerScore"] == null)
            {
                Session["DealerScore"] = 0;
            }

            model.PlayerScore = (int)Session["PlayerScore"];
            model.DealerScore = (int)Session["DealerScore"];

            if (!model.IsWar)
            {
                model.PlayerCards.Add(random.Next(1, 14));
                model.DealerCards.Add(random.Next(1, 14));

                if (model.PlayerCards.Last() > model.DealerCards.Last())
                {
                    model.PlayerScore++;
                    model.Result = "Ganaste!";
                }
                else if (model.DealerCards.Last() > model.PlayerCards.Last())
                {
                    model.DealerScore++;
                    model.Result = "Perdiste.";
                }
                else
                {
                    model.Result = "Guerra!";
                    model.IsWar = true;
                }
            }
            else
            {
                if (model.WarCards == null)
                {
                    model.WarCards = new List<int>();
                }

                model.WarCards.Add(random.Next(1, 14));
                model.WarCards.Add(random.Next(1, 14));

                if (model.WarCards[0] > model.WarCards[1])
                {
                    model.PlayerScore++;
                    model.Result = "Ganaste la guerra!";
                }
                else
                {
                    model.DealerScore++;
                    model.Result = "Perdiste la guerra.";
                }

                model.IsWar = false;
            }

            Session["PlayerScore"] = model.PlayerScore;
            Session["DealerScore"] = model.DealerScore;

            return View("Index", model);
        }
    }
}