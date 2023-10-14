using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoGrupal.Models;

namespace TrabajoGrupal.Controllers
{
    public class NumberController : Controller
    {
        public ActionResult ConvertNumberToLetters(ClsNumber model)
        {
            string[] unidades = { "cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
            string[] decenas = { "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };
            string[] decenas2 = { "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
            string[] centenas = { "cien", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };
            string[] miles = { "", "mil", "millón", "mil millones", "billón", "mil billones" };

            string letras = "";

            if (model.Numero == 0)
            {
                letras = "cero";
            }
            else
            {
                int numeroActual = model.Numero;
                int indiceMiles = 0;

                do
                {
                    int millares = numeroActual % 1000;
                    numeroActual /= 1000;

                    if (millares == 0)
                    {
                        indiceMiles++;
                        continue;
                    }

                    string millaresEnLetras = "";

                    int centenasMiles = millares / 100;
                    int decenasMiles = (millares % 100) / 10;
                    int unidadesMiles = millares % 10;

                    if (centenasMiles > 0)
                    {
                        millaresEnLetras = centenas[centenasMiles - 1] + " ";
                    }

                    if (decenasMiles > 0)
                    {
                        if (decenasMiles == 1 && unidadesMiles > 0)
                        {
                            millaresEnLetras += decenas[unidadesMiles] + " ";
                            unidadesMiles = 0;
                        }
                        else
                        {
                            millaresEnLetras += decenas2[decenasMiles - 2] + " ";
                        }
                    }

                    if (unidadesMiles > 0)
                    {
                        if (decenasMiles > 0)
                        {
                            millaresEnLetras += "y ";
                        }
                        millaresEnLetras += unidades[unidadesMiles] + " ";
                    }

                    if (indiceMiles > 0 && millares > 0)
                    {
                        millaresEnLetras += miles[indiceMiles] + " ";
                    }

                    letras = millaresEnLetras + letras;
                    indiceMiles++;
                } while (numeroActual > 0);
            }
            letras = letras.TrimEnd();

            int index = letras.IndexOf("uno");

            if (index == 0)
            {
                letras = letras.Remove(0, 3);
            }

            ViewBag.Letras = letras.TrimEnd();
            return View(model);
        }

        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                TempData["ErrorMessage"] = "Debe iniciar sesion para acceder a esta pagina";
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}