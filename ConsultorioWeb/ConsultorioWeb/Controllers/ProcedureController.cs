using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultorioWeb.Database;
using ConsultorioWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioWeb.Controllers
{
    public class ProcedureController : Controller
    {
        // GET: Procedure
        public ActionResult Index()
        {
            if(DbContext.procedures.Count == 0) CreateProcedure();

            return View(DbContext.procedures);
        }

        public static void CreateProcedure()
        {
            Procedure p1 = new Procedure("Clareamento dental");
            Procedure p2 = new Procedure("Tratamento Ortodôntico");
            Procedure p3 = new Procedure("Implante");
            Procedure p4 = new Procedure("Extração");
            Procedure p5 = new Procedure("Enxerto gengival");
            Procedure p6 = new Procedure("Restauração");
            Procedure p7 = new Procedure("Canal");

            DbContext.procedures.Add(p1);
            DbContext.procedures.Add(p2);
            DbContext.procedures.Add(p3);
            DbContext.procedures.Add(p4);
            DbContext.procedures.Add(p5);
            DbContext.procedures.Add(p6);
            DbContext.procedures.Add(p7);
        }
    }
}