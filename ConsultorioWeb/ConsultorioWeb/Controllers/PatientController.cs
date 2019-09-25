using System;
using ConsultorioWeb.Database;
using ConsultorioWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioWeb.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            return View(DbContext.patient);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient p)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                DbContext.patient.Add(p);
                TempData["notification"] = "Novo paciente cadastrado com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(Guid id)
        {
            Patient currentPatient = GetContact(id);
            return View(currentPatient);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Patient p)
        {
            try
            {
                Patient currentPatient = GetContact(id);
                currentPatient.Name = p.Name;
                TempData["notification"] = "Paciente alterado com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(Guid id)
        {
            Patient currentPatient = GetContact(id);
            return View(currentPatient);
        }

        private Patient GetContact(Guid id)
        {
            return DbContext.patient.Find(c => c.Id == id);
        }

        // POST: Patient/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, Patient p)
        {
            try
            {
                DbContext.patient.Remove(GetContact(id));
                TempData["notification"] = "Paciente deletado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}